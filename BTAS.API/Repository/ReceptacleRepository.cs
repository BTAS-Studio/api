using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Models.Links;
using BTAS.API.Repository.Interface;
using BTAS.API.Repository.SearchRepository;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class ReceptacleRepository : SRepository, IRepository<tbl_receptacleDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;
        public ReceptacleRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }

        /// <summary>
        /// Retrieves all Receptacle
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_receptacleDto>> GetAllAsync()
        {
            IEnumerable<tbl_receptacle> _list = await _context.tbl_receptacles
                .OrderByDescending(r => r.idtbl_receptacle)
                //.Include(r => r.shipments)
                .ToListAsync();
            _list = _list.Take(200);
            return _mapper.Map<List<tbl_receptacleDto>>(_list);
        }
        public async Task<IEnumerable<tbl_receptacleDto>> GetAllAsyncWithChildren()
        {
            try
            {
                IEnumerable<tbl_receptacle> _list = await _context.tbl_receptacles
                .OrderByDescending(x => x.idtbl_receptacle)
                .Include(r => r.shipments)
                .Take(40)
                .ToListAsync();

                return _mapper.Map<List<tbl_receptacleDto>>(_list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Added by HS on 22/05/2023
        /// <summary>
        /// Retrieves a specified number of receptacles according to input conditions(>, >=, <, <=, ==, !=, and contains)
        /// </summary>
        /// <returns> A list of receptacle objects including their linked parent houses</returns>
        public async Task<IEnumerable<tbl_receptacleDto>> GetFilteredAsync(CustomFilters<tbl_receptacleDto> customFilters)
        {
            try
            {
                var qList = _context.tbl_receptacles.Include(r => r.house)
                    .AsNoTracking()
                    .OrderByDescending(r => r.idtbl_receptacle).AsQueryable();
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

                        if (filter.tableName.ToUpper() == "RECEPTACLE")
                        {
                            filter.tableName = "receptacle";
                            bool containsDateTime = false;
                            //used for searching Contains DateTime type's columns
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeReceptacleJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = 
                                GetPropertyInfo<tbl_receptacleDto, tbl_receptacle>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
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

                            (propertyInfo, filter.fieldValue, containsDateTime) = 
                                GetParentPropertyInfo<tbl_receptacle, tbl_house, tbl_houseDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
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

                        Expression<Func<tbl_receptacle, bool>> propertyLambda = null;
                        propertyLambda = GetPropertyLambda<tbl_receptacle>(propertyInfo, filter, parent);

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
                return _mapper.Map<IEnumerable<tbl_receptacleDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves a single Receptacle based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_receptacleDto> GetByIdAsync(int id)
        {

            tbl_receptacle result = await _context.tbl_receptacles
                .Include(c => c.shipments)
                .FirstOrDefaultAsync(x => x.idtbl_receptacle == id);
                
            return _mapper.Map<tbl_receptacleDto>(result);

        }

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild = false)
        {
            try
            {
                tbl_receptacle result = new();

                if (includeChild)
                {
                    result = await _context.tbl_receptacles
                        .Include(x => x.shipments)
                        .FirstOrDefaultAsync(x => x.tbl_receptacle_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_receptacles
                        .FirstOrDefaultAsync(x => x.tbl_receptacle_code == referenceNumber);
                }
                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_receptacle_code,
                    DisplayMessage = "Success",
                    Result = _mapper.Map<tbl_receptacleDto>(result)
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

        public async Task<ResponseDto> GetByHouseBillNo(string houseBillNo)
        {
            try
            {
                var houseResult = await _context.tbl_houses.OrderByDescending(x => x.idtbl_house)
                    .FirstOrDefaultAsync(y => y.tbl_house_billNumber == houseBillNo);
                //Edited by HS on 01/02/2023
                tbl_receptacle result = await _context.tbl_receptacles.OrderByDescending(x => x.idtbl_receptacle)
                    .FirstOrDefaultAsync(y => y.HouseCode == houseResult.tbl_house_code);
                return new ResponseDto
                {
                    IsSuccess = true,
                    DisplayMessage = "Successfully retrieved House by reference" + houseBillNo,
                    Result = _mapper.Map<tbl_receptacleDto>(result),
                    ReferenceNumber = result.tbl_receptacle_code
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
        //Added by HS on 01/02/2023
        public async Task<ResponseDto> GetDummyByMasterBillNo(string referenceNumber)
        {
            try
            {
                tbl_master masterResult = await _context.tbl_masters.OrderByDescending(x => x.idtbl_master)
                    .FirstOrDefaultAsync(y => y.tbl_master_billNumber == referenceNumber);
                var masterReference = masterResult.tbl_master_code;
                tbl_house houseResult = await _context.tbl_houses.OrderByDescending(x => x.idtbl_house)
                    .FirstOrDefaultAsync(y => (y.MasterCode == masterReference && y.tbl_house_billNumber == "DUMMY"));
                var houseReference = houseResult.tbl_house_code;
                tbl_receptacle receptacleResult = await _context.tbl_receptacles.OrderByDescending(x => x.idtbl_receptacle)
                    .FirstOrDefaultAsync(y => y.HouseCode == houseReference);

                return new ResponseDto
                {
                    IsSuccess = true,
                    DisplayMessage = "Successfully retrieved Dummy Receptacle by master bill number" + referenceNumber,
                    Result = _mapper.Map<tbl_receptacleDto>(receptacleResult),
                    ReferenceNumber = receptacleResult.tbl_receptacle_code
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = "Error retrieving dummy receptacle. " + ex.Message,
                };
            }
        }

        /// <summary>
        /// Creates/updates a Receptacle record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_receptacleDto> CreateUpdateAsync(tbl_receptacleDto entity)
        {
            try
            {
                tbl_receptacle mapped = _mapper.Map<tbl_receptacleDto, tbl_receptacle>(entity);


                _context.tbl_receptacles.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_receptacle, tbl_receptacleDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a Receptacle record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_receptacleDto entity)
        {
            try
            {

                string referenceNumber = await GetNextId();
                entity.tbl_receptacle_code = referenceNumber;
                entity.tbl_receptacle_status = "ACTIVE";
                entity.tbl_receptacle_createdDate = DateTime.Now;

                tbl_receptacle result = _mapper.Map<tbl_receptacleDto, tbl_receptacle>(entity);

                if (result.idtbl_receptacle > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate receptacle record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (result.HouseCode != null && result.HouseCode != "")
                    {
                        tbl_house house = await _context.tbl_houses.FirstOrDefaultAsync(x => x.tbl_house_code == result.HouseCode);
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
                                DisplayMessage = "Provided HOUSE code was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    
                    await _context.tbl_receptacles.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        Result = _mapper.Map<tbl_receptacleDto>(result),
                        ReferenceNumber = result.tbl_receptacle_code,
                        DisplayMessage = "Receptacle successfully created.",
                        IsSuccess = true
                    };
                }
                
            }
            catch (Exception ex)
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
        /// Updates a Receptacle record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_receptacleDto entity)
        {
            try
            {
                var result = await _context.tbl_receptacles
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_receptacle_code == entity.tbl_receptacle_code);

                if (result != null)
                {
                    _mapper.Map<tbl_receptacleDto, tbl_receptacle>(entity, result);
                    if (entity.HouseCode != "" && entity.HouseCode != null)
                    {
                        var parent = await _context.tbl_houses
                        .SingleOrDefaultAsync(x => x.tbl_house_code == entity.HouseCode);

                        if (parent != null)
                        {
                            result.tbl_house_id = parent.idtbl_house;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to receptacle. Invalid HOUSE id or code.",
                                IsSuccess = false
                            };
                        }
                    }
                    _context.ChangeTracker.Clear();
                    _context.tbl_receptacles.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Receptacle does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    DisplayMessage = "Receptacle successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_receptacle_code
                };
            }
            catch(Exception ex)
            {
                return new ResponseDto
                {
                    DisplayMessage = ex.StackTrace.ToString(),
                    IsSuccess = false
                };
            }
        }

        public async Task<ResponseDto> LinkToHouseAsync(LinkToHouseRequest request)
        {
            try
            {
                var parent = await _context.tbl_houses.FirstOrDefaultAsync(x => x.tbl_house_code == request.parentReference);
                if (parent != null)
                {
                    List<string> failed = new();
                    foreach (var reference in request.ReferencesToLink)
                    {
                        var entity = await _context.tbl_receptacles.FirstOrDefaultAsync(x => x.tbl_receptacle_code == reference);
                        if (entity != null)
                        {
                            entity.tbl_house_id = parent.idtbl_house;
                            entity.HouseCode = parent.tbl_house_code;
                            _context.tbl_receptacles.Update(entity);

                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            failed.Add(reference);
                        }
                    }

                    return new ResponseDto
                    {
                        IsSuccess = true,
                        Result = failed,
                        DisplayMessage = failed.Count > 0 ? "failed" : "Receptacle successfully updated with HOUSE #" + request.parentReference,
                        ReferenceNumber = request.parentReference
                    };
                }

                return new ResponseDto
                {
                    IsSuccess = false,
                    Result = request.ReferencesToLink,
                    DisplayMessage = "Unable to link to receptacle. Invalid HOUSE number."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Result = request,
                    ErrorMessages = new List<string>() { ex.Message }
                };
            }

        }

        public async Task<List<tbl_receptacleDto>> CreateRangeAsync(List<tbl_receptacleDto> entities)
        {
            List<tbl_receptacle> result = _mapper.Map<List<tbl_receptacleDto>, List<tbl_receptacle>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_receptacles.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_receptacle>, List<tbl_receptacleDto>>(result);
        }

        /// <summary>
        /// Deletes existing receptacle record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_receptacle result = await _context.tbl_receptacles.FirstOrDefaultAsync(x => x.idtbl_receptacle == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_receptacles.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

  
        public async Task<string> GetNextId()
        {

            tbl_receptacle result = await _context.tbl_receptacles.OrderByDescending(x => x.idtbl_receptacle).FirstOrDefaultAsync();

            string referenceCode = "RC" + String.Format("{0:000000000}", (result != null ? result.idtbl_receptacle + count : 1));
            count++;
            return referenceCode;
        }


    }
}
