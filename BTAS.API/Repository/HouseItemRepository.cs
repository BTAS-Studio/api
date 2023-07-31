using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using BTAS.API.Repository.SearchRepository;

namespace BTAS.API.Repository
{
    public class HouseItemRepository : SRepository, IRepository<tbl_house_itemDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;

        public HouseItemRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }

        /// <summary>
        /// Retrieves all HOUSE Item
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_house_itemDto>> GetAllAsync()
        {
            var _list = await _context.tbl_house_items.OrderByDescending(hi => hi.idtbl_house_item).ToListAsync();
            return _mapper.Map<List<tbl_house_itemDto>>(_list);
        }

        public Task<IEnumerable<tbl_house_itemDto>> GetAllAsyncWithChildren()
        {
            //No children
            return null;
        }

        //Added by HS on 19/05/2023
        /// <summary>
        /// Retrieves a specified number of houseItems according to input conditions(>, >=, <, <=, ==, !=, and contains)
        /// </summary>
        /// <returns> A list of houseItem objects including their linked parent houses</returns>
        public async Task<IEnumerable<tbl_house_itemDto>> GetFilteredAsync(CustomFilters<tbl_house_itemDto> customFilters)
        {
            try
            {
                var qList = _context.tbl_house_items.Include(hi => hi.house)
                    .AsNoTracking()
                    .OrderByDescending(h => h.idtbl_house_item).AsQueryable();
                // excute each filter one by one 
                if (customFilters.Filters != null)
                {
                    foreach (var filter in customFilters.Filters)
                    {
                        PropertyInfo propertyInfo = null;
                        bool parent = false;
                        var jsonString = JsonConvert.SerializeObject(filter.searchField);
                        var jsonObj = JObject.Parse(jsonString);
                        JToken originalValue = null;

                        if (filter.tableName.ToUpper() == "HOUSEITEM")
                        {
                            filter.tableName = "house_item";
                            bool containsDateTime = false;
                            //used for searching Contains DateTime type's columns
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                //(containsDateTime, jsonString) = MakeHouseItemJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = 
                                GetPropertyInfo<tbl_house_itemDto, tbl_house_item>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "HOUSE")
                        {
                            filter.tableName = "house";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeHouseJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetParentPropertyInfo<tbl_house_item, tbl_house, tbl_houseDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid table name: {filter.tableName}");
                        }

                        Type elementType = qList.ElementType;

                        if (propertyInfo == null)
                        {
                            throw new ArgumentException($"Invalid property name: {propertyInfo.Name}");
                        }

                        Expression<Func<tbl_house_item, bool>> propertyLambda = null;
                        propertyLambda = GetPropertyLambda<tbl_house_item>(propertyInfo, filter, parent);

                        if (propertyLambda != null)
                        {
                            qList = qList.Where(propertyLambda);
                        }
                    }
                }

                if (qList.Count() == 0)
                {
                    return null;
                }
                var filtered = await qList.Skip(customFilters.Page * customFilters.PageSize).Take(customFilters.PageSize).ToListAsync();
                return _mapper.Map<IEnumerable<tbl_house_itemDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves a single HOUSE Item based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_house_itemDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_house_items.FirstOrDefaultAsync(x => x.idtbl_house_item == id);
            return _mapper.Map<tbl_house_itemDto>(result);

        }

        public async Task<ResponseDto> GetByReference(string referenceNumber)
        {
            try
            {
                tbl_house_item result = new();
                result = await _context.tbl_house_items
                    .FirstOrDefaultAsync(x => x.tbl_house_item_code == referenceNumber);

                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_house_item_code,
                    DisplayMessage = "Success",
                    Result = _mapper.Map<tbl_houseDto>(result)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.StackTrace.ToString() },
                    DisplayMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// Creates/updates a HOUSE Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_house_itemDto> CreateUpdateAsync(tbl_house_itemDto entity)
        {
            try
            {
                var mapped = _mapper.Map<tbl_house_itemDto, tbl_house_item>(entity);


                _context.tbl_house_items.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_house_item, tbl_house_itemDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a HOUSE Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_house_itemDto entity)
        {
            try
            {
                entity.tbl_house_item_code = await GetNextId();
                var result = _mapper.Map<tbl_house_itemDto, tbl_house_item>(entity);
                if (result.idtbl_house_item > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate HOUSE Item record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if ((result.HouseCode != null && result.HouseCode != "") || result.tbl_house_id.HasValue)
                    {
                        var house = await _context.tbl_houses
                            .FirstOrDefaultAsync(x => x.idtbl_house == result.tbl_house_id || x.tbl_house_code == result.HouseCode);
                        if (house != null)
                        {
                            result.tbl_house_id = house.idtbl_house;
                            result.HouseCode = house.tbl_house_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to item. Provided HOUSE code was not found.",
                                IsSuccess = false
                            };
                        }
                    }

                    await _context.tbl_house_items.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "HOUSE Item successfully added.",
                        IsSuccess = true
                    };
                }
            }
            catch(Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.Message.ToString(),
                    IsSuccess = false
                };
            }
            
        }

        /// <summary>
        /// Updates a HOUSE Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_house_itemDto entity)
        {
            try
            {
                var result = await _context.tbl_house_items
                    .SingleOrDefaultAsync(x => x.tbl_house_item_code == entity.tbl_house_item_code);
                if (result != null)
                {
                    _mapper.Map(entity, result);
                    var house = await _context.tbl_houses
                        .SingleOrDefaultAsync(x => x.idtbl_house == entity.tbl_house_id || x.tbl_house_code == entity.HouseCode);
                    if (house != null)
                    {
                        result.tbl_house_id = house.idtbl_house;
                    }
                    else
                    {
                        return new ResponseDto
                        {
                            Result = entity,
                            DisplayMessage = "Unable to link to item. Provided HOUSE code was not found.",
                            IsSuccess = false
                        };
                    }
                    _context.ChangeTracker.Clear();
                    _context.tbl_house_items.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "HOUSE Item does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    DisplayMessage = "HOUSE Item successfully updated.",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.StackTrace.ToString(),
                    IsSuccess = false
                };
            }

        }

        public async Task<List<tbl_house_itemDto>> CreateRangeAsync(List<tbl_house_itemDto> entities)
        {
            var result = _mapper.Map<List<tbl_house_itemDto>, List<tbl_house_item>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_house_items.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_house_item>, List<tbl_house_itemDto>>(result);
        }

        /// <summary>
        /// Deletes existing HOUSE Item record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _context.tbl_house_items.FirstOrDefaultAsync(x => x.idtbl_house_item == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_house_items.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetByHouse(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_house_items.Where(x => x.HouseCode == referenceNumber).ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_house_item>>(result)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = "Error retrieving record."
                };
            }
        }

        public async Task<string> GetNextId()
        {
            var result = await _context.tbl_house_items.OrderByDescending(p => p.idtbl_house_item).FirstOrDefaultAsync();
            string code = "HI" + String.Format("{0:0000000}", (result != null ? result.idtbl_house_item + count : 1));
            return code;
        }
    }
}
