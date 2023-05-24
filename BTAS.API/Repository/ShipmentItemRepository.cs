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
    public class ShipmentItemRepository : SRepository, IRepository<tbl_shipment_itemDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public ShipmentItemRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all Parcel Item
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_shipment_itemDto>> GetAllAsync()
        {
            var _list = await _context.tbl_shipment_items.OrderByDescending(si => si.idtbl_shipment_item)
                .ToListAsync();
            return _mapper.Map<List<tbl_shipment_itemDto>>(_list);
        }

        public async Task<IEnumerable<tbl_shipment_itemDto>> GetAllAsyncWithChildren()
        {
            var _list = await _context.tbl_shipment_items.OrderByDescending(si => si.idtbl_shipment_item)
                .Include(si => si.itemSkus)
                .ToListAsync();
            return _mapper.Map<List<tbl_shipment_itemDto>>(_list);
        }

        //Added by HS on 22/05/2023
        /// <summary>
        /// Retrieves a specified number of shipmentItems according to input conditions(>, >=, <, <=, ==, !=, and contains)
        /// </summary>
        /// <returns> A list of shipmentItem objects including their linked parent shipments</returns>
        public async Task<IEnumerable<tbl_shipment_itemDto>> GetFilteredAsync(CustomFilters<tbl_shipment_itemDto> customFilters)
        {
            try
            {
                var qList = _context.tbl_shipment_items.Include(hi => hi.shipment)
                    //.AsNoTracking()
                    .OrderByDescending(h => h.idtbl_shipment_item).AsQueryable();
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

                        if (filter.tableName.ToUpper() == "SHIPMENTITEM")
                        {
                            filter.tableName = "shipment_item";
                            bool containsDateTime = false;
                            //used for searching Contains DateTime type's columns
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                //(containsDateTime, jsonString) = MakeShipmentItemJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = 
                                GetPropertyInfo<tbl_shipment_itemDto, tbl_shipment_item>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "SHIPMENT")
                        {
                            filter.tableName = "shipment";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeShipmentJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = 
                                GetParentPropertyInfo<tbl_shipment_item, tbl_shipment, tbl_shipmentDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
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

                        Expression<Func<tbl_shipment_item, bool>> propertyLambda = null;
                        propertyLambda = GetPropertyLambda<tbl_shipment_item>(propertyInfo, filter, parent);

                        if (propertyLambda != null)
                        {
                            //qList = qList.Where(propertyLambda);
                            qList = qList.Provider.CreateQuery<tbl_shipment_item>(Expression.Call(
                                       typeof(Queryable),
                                       "Where",
                                       new[] { elementType },
                                       qList.Expression,
                                       propertyLambda
                                   ));
                        }
                    }
                }

                if (qList.Count() == 0)
                {
                    return null;
                }
                var filtered = await qList.Skip(customFilters.Page * customFilters.PageSize).Take(customFilters.PageSize).ToListAsync();
                return _mapper.Map<IEnumerable<tbl_shipment_itemDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves a single Parcel Item based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_shipment_itemDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_shipment_items.FirstOrDefaultAsync(x => x.idtbl_shipment_item == id);
            return _mapper.Map<tbl_shipment_itemDto>(result);

        }

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild = false)
        {
            try
            {
                tbl_shipment_item result = new();
                if (includeChild)
                {
                    result = await _context.tbl_shipment_items
                        .Include(c => c.itemSkus)
                        .FirstOrDefaultAsync(x => x.tbl_shipment_item_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_shipment_items
                        .FirstOrDefaultAsync(x => x.tbl_shipment_item_code == referenceNumber);
                }

                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_shipment_item_code,
                    DisplayMessage = "Success",
                    Result = _mapper.Map<tbl_shipment_itemDto>(result)
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
        /// Creates/updates a Parcel Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_shipment_itemDto> CreateUpdateAsync(tbl_shipment_itemDto entity)
        {
            try
            {
                var mapped = _mapper.Map<tbl_shipment_itemDto, tbl_shipment_item>(entity);


                _context.tbl_shipment_items.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_shipment_item, tbl_shipment_itemDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a Parcel Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_shipment_itemDto entity)
        {
            try
            {
                var result = _mapper.Map<tbl_shipment_itemDto, tbl_shipment_item>(entity);

                if (result.idtbl_shipment_item > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate shipment item record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if ((result.tbl_shipment_item_code != null && result.tbl_shipment_item_code != "") || result.tbl_shipment_id.HasValue)
                    {
                        var shipment = await _context.tbl_shipments
                            .FirstOrDefaultAsync(x => x.idtbl_shipment == result.tbl_shipment_id || x.tbl_shipment_code == result.ShipmentCode);
                        if (shipment != null)
                        {
                            result.tbl_shipment_id = shipment.idtbl_shipment;
                            result.ShipmentCode = shipment.tbl_shipment_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link item. Provided parcel info reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                        
                    await _context.tbl_shipment_items.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Shipment Item successfully added.",
                        IsSuccess = true
                    };
                }
                
            }
            catch (Exception ex)
            {
                if(ex.GetBaseException().ToString().IndexOf("Duplicate") > -1)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to save record. Possible duplicate SKU code.",
                        IsSuccess = false
                    };
                }
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.Message.ToString(),
                    IsSuccess = false
                };
            }
            
        }

        /// <summary>
        /// Updates a Parcel Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_shipment_itemDto entity)
        {
            try
            {
                var result = await _context.tbl_shipment_items
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.idtbl_shipment_item == entity.idtbl_shipment_item);
                if (result != null)
                {
                    if (entity.tbl_shipment_id.HasValue || (entity.ShipmentCode != "" && entity.ShipmentCode != null))
                    {
                        var shipment = await _context.tbl_shipments
                        .FirstOrDefaultAsync(x => x.idtbl_shipment == entity.tbl_shipment_id || x.tbl_shipment_code == entity.ShipmentCode);

                        if (shipment != null)
                        {
                            result.tbl_shipment_id = shipment.idtbl_shipment;
                            result.ShipmentCode = shipment.tbl_shipment_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link. Invalid shipment id or code.",
                                IsSuccess = false
                            };
                        }
                    }


                    _context.tbl_shipment_items.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Shipment does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Shipment successfully updated.",
                    IsSuccess = true
                };
            }
            catch(Exception ex)
            {
                if (ex.GetBaseException().ToString().IndexOf("Duplicate") > -1)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to save record. Possible duplicate SKU code.",
                        IsSuccess = false
                    };
                }
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.StackTrace.ToString(),
                    IsSuccess = false
                };
            }
            
        }

        public async Task<List<tbl_shipment_itemDto>> CreateRangeAsync(List<tbl_shipment_itemDto> entities)
        {
            var result = _mapper.Map<List<tbl_shipment_itemDto>, List<tbl_shipment_item>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_shipment_items.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_shipment_item>, List<tbl_shipment_itemDto>>(result);
        }

        /// <summary>
        /// Deletes existing Parcel Item record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
               var result = await _context.tbl_shipment_items.FirstOrDefaultAsync(x => x.idtbl_shipment_item == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_shipment_items.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetShipment(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_shipment_items.Where(x => x.ShipmentCode == referenceNumber).ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_shipment_item>>(result)
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
    }
}
