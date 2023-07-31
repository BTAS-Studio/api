using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Models.Links;
using BTAS.API.Repository.Interface;
using BTAS.API.Repository.SearchRepository;
using BTAS.Data;
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
    public class ContainerRepository : SRepository, IRepository<tbl_containerDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;

        public ContainerRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }

        /// <summary>
        /// Retrieves all container
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_containerDto>> GetAllAsync()
        {
            IEnumerable<tbl_container> _list = await _context.tbl_containers.OrderByDescending(c => c.idtbl_container).ToListAsync();
            return _mapper.Map<List<tbl_containerDto>>(_list);
        }

        public async Task<IEnumerable<tbl_containerDto>> GetAllAsyncWithChildren()
        {
            IEnumerable<tbl_container> _list = await _context.tbl_containers.OrderByDescending(c => c.idtbl_container)
                .Include(c => c.houses)
                .ToListAsync();
            return _mapper.Map<List<tbl_containerDto>>(_list);
        }

        //Added by HS on 19/05/2023
        /// <summary>
        /// Retrieves a specified number of containers according to input conditions(>, >=, <, <=, ==, !=, and contains)
        /// </summary>
        /// <returns> A list of container objects including their linked parent masters and containers</returns>
        public async Task<IEnumerable<tbl_containerDto>> GetFilteredAsync(CustomFilters<tbl_containerDto> customFilters)
        {
            try
            {
                var qList = _context.tbl_containers.Include(h => h.master)
                    .AsNoTracking()
                    .OrderByDescending(h => h.idtbl_container).AsQueryable();
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

                        if (filter.tableName.ToUpper() == "CONTAINER")
                        {
                            filter.tableName = "container";
                            bool containsDateTime = false;
                            //used for searching Contains DateTime type's columns
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeContainerJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetPropertyInfo<tbl_containerDto, tbl_container>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "CONSOLIDATION")
                        {
                            filter.tableName = "master";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeMasterJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetParentPropertyInfo<tbl_container, tbl_master, tbl_masterDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
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

                        Expression<Func<tbl_container, bool>> propertyLambda = null;
                        propertyLambda = GetPropertyLambda<tbl_container>(propertyInfo, filter, parent);

                        if (propertyLambda != null)
                        {
                            qList = qList.Provider.CreateQuery<tbl_container>(Expression.Call(
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
                return _mapper.Map<IEnumerable<tbl_containerDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves a single container based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_containerDto> GetByIdAsync(int id)
        {

            tbl_container result = await _context.tbl_containers.FirstOrDefaultAsync(x => x.idtbl_container == id);
            return _mapper.Map<tbl_containerDto>(result);

        }

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild = false)
        {
            try
            {

                tbl_container result = new();

                if (includeChild)
                {
                    result = await _context.tbl_containers
                        .Include(c => c.houses)
                        .FirstOrDefaultAsync(x => x.tbl_container_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_containers
                        .FirstOrDefaultAsync(x => x.tbl_container_code == referenceNumber);
                }

                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_container_code,
                    DisplayMessage = "Success",
                    Result = _mapper.Map<tbl_containerDto>(result)
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
        /// Creates/updates a container record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_containerDto> CreateUpdateAsync(tbl_containerDto entity)
        {
            try
            {
                tbl_container mappedHouse = _mapper.Map<tbl_containerDto, tbl_container>(entity);


                _context.tbl_containers.Add(mappedHouse);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_container, tbl_containerDto>(mappedHouse);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a container record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_containerDto entity)
        {
            try
            {   
                string referenceNumber = await GetNextId();
                entity.tbl_container_code = referenceNumber;
                entity.tbl_container_status = "OPEN";
                entity.tbl_container_createdDate = DateTime.Now;
                tbl_container result = _mapper.Map<tbl_containerDto, tbl_container>(entity);

                if (result.idtbl_container > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate container record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (!String.IsNullOrEmpty(result.MasterCode))
                    {
                        var parent = await _context.tbl_masters.FirstOrDefaultAsync(x => x.tbl_master_code == result.MasterCode);
                        if (parent != null)
                        {
                            result.tbl_master_id = parent.idtbl_master;
                            //result.MasterCode = parent.tbl_master_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to item. Provided MASTER reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }

                    await _context.tbl_containers.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Container successfully created.",
                        IsSuccess = true,
                        ReferenceNumber = result.tbl_container_code
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.Message,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Updates a container record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_containerDto entity)
        {
            try
            {
                var result = await _context.tbl_containers
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_container_code == entity.tbl_container_code);

                if (result != null)
                {
                    _mapper.Map(entity, result);
                    if (!String.IsNullOrEmpty(entity.MasterCode))
                    {
                        var master = await _context.tbl_masters.AsNoTracking()
                        .SingleOrDefaultAsync(x => x.tbl_master_code == entity.MasterCode);

                        if (master != null)
                        {
                            result.tbl_master_id = master.idtbl_master;
                            //result.MasterCode = master.tbl_master_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Invalid MASTER id or code.",
                                IsSuccess = false
                            };
                        }
                    }
                    _context.ChangeTracker.Clear();
                    _context.tbl_containers.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Container does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    DisplayMessage = "Container successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_container_code
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.Message,
                    IsSuccess = false
                };
            }
        }

        public async Task<ResponseDto> LinkToMasterAsync(LinkToMasterRequest request)
        {
            try
            {
                var parent = await _context.tbl_masters.FirstOrDefaultAsync(x => x.tbl_master_code == request.parentReference);
                if (parent != null)
                {
                    List<string> failed = new();
                    foreach (var reference in request.ReferencesToLink)
                    {
                        var entity = await _context.tbl_containers.FirstOrDefaultAsync(x => x.tbl_container_code == reference && x.tbl_container_code.Contains(request.shipperId));
                        if (entity != null)
                        {
                            entity.tbl_master_id = parent.idtbl_master;
                            entity.MasterCode = parent.tbl_master_code;
                            _context.tbl_containers.Update(entity);

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
                        DisplayMessage = failed.Count > 0 ? "failed" : "Container successfully updated with MASTER # " + request.parentReference,
                        ReferenceNumber = request.parentReference
                    };
                }

                return new ResponseDto
                {
                    IsSuccess = false,
                    Result = request.ReferencesToLink,
                    DisplayMessage = "Invalid MASTER code."
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

        public async Task<List<tbl_containerDto>> CreateRangeAsync(List<tbl_containerDto> entities)
        {
            List<tbl_container> result = _mapper.Map<List<tbl_containerDto>, List<tbl_container>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_containers.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_container>, List<tbl_containerDto>>(result);
        }

        /// <summary>
        /// Deletes existing container record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_container result = await _context.tbl_containers.FirstOrDefaultAsync(x => x.idtbl_container == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_containers.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetByMaster(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_containers.Where(x => x.MasterCode == referenceNumber).ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_containerDto>>(result)
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
            tbl_container result = await _context.tbl_containers.OrderByDescending(x => x.idtbl_container).FirstOrDefaultAsync();

            string referenceCode = "CT" + String.Format("{0:0000000}", (result != null ? result.idtbl_container + count : 1));
            return referenceCode;
        }
    }
}
