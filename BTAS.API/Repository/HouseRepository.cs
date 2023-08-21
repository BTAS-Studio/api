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
    public class HouseRepository : SRepository, IRepository<tbl_houseDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;
        public HouseRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }

        /// <summary>
        /// Retrieves all house
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_houseDto>> GetAllAsync()
        {
            IEnumerable<tbl_house> _list = await _context.tbl_houses.OrderByDescending(h => h.idtbl_house).ToListAsync();
            _list = _list.Take(40);
            return _mapper.Map<List<tbl_houseDto>>(_list);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_houseDto>> GetAllAsyncWithChildren()
        {
            try
            {
                IEnumerable<tbl_house> _list = await _context.tbl_houses
                //.Include(x => x.master)
                //.Include(x => x.container)
                .Include(x => x.consignor)
                .Include(x => x.consignee)
                .Include(x => x.houseItems)
                .Include(x => x.receptacles)
                //.AsNoTracking()
                .OrderByDescending(x => x.idtbl_house).Take(40)
                .ToListAsync();

                return _mapper.Map<List<tbl_houseDto>>(_list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Added by HS on 19/05/2023
        /// <summary>
        /// Retrieves a specified number of houses according to input conditions(>, >=, <, <=, ==, !=, and contains)
        /// </summary>
        /// <returns> A list of house objects including their linked parent masters</returns>
        public async Task<IEnumerable<tbl_houseDto>> GetFilteredAsync(CustomFilters<tbl_houseDto> customFilters)
        {
            try
            {
                var qList = _context.tbl_houses
                    .Include(h => h.voyage)
                    .Include(h => h.master)
                    .Include(h => h.container)
                    .Include(p => p.consignee)
                    .Include(p => p.consignor)
                    .AsNoTracking()
                    .OrderByDescending(h => h.idtbl_house)
                    .AsQueryable();
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

                        if (filter.tableName.ToUpper() == "HOUSE")
                        {
                            filter.tableName = "house";
                            bool containsDateTime = false;
                            //used for searching Contains DateTime type's columns
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeHouseJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = 
                                GetPropertyInfo<tbl_houseDto, tbl_house>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
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

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetParentPropertyInfo<tbl_house, tbl_master, tbl_masterDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "CONTAINER")
                        {
                            filter.tableName = "container";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeContainerJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetParentPropertyInfo<tbl_house, tbl_container, tbl_containerDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "VOYAGE")
                        {
                            filter.tableName = "voyage";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeVoyageJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetParentPropertyInfo<tbl_house, tbl_voyage, tbl_voyageDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "INCOTERM")
                        {
                            filter.tableName = "incoterm";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) =
                                GetParentPropertyInfo<tbl_shipment, tbl_incoterm, tbl_incotermDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "CONSIGNEE")
                        {
                            filter.tableName = "consignee";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeClientHeaderJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetParentPropertyInfo<tbl_house, tbl_client_header, tbl_client_headerDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "CONSIGNOR")
                        {
                            filter.tableName = "consignor";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeClientHeaderJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetParentPropertyInfo<tbl_house, tbl_client_header, tbl_client_headerDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
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

                        Expression<Func<tbl_house, bool>> propertyLambda = null;
                        propertyLambda = GetPropertyLambda<tbl_house>(propertyInfo, filter, parent);

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
                return _mapper.Map<IEnumerable<tbl_houseDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves a single house based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_houseDto> GetByIdAsync(int id)
        {

            tbl_house result = await _context.tbl_houses
                .Include(c => c.houseItems)
                //.Include(c => c.receptacles)
                .FirstOrDefaultAsync(x => x.idtbl_house == id);
            return _mapper.Map<tbl_houseDto>(result);

        }

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild = false)
        {
            try
            {

                tbl_house result = new();

                if (includeChild)
                {
                    result = await _context.tbl_houses
                        .Include(c => c.houseItems)
                        .Include(c => c.receptacles)
                        .Include(c => c.consignee)
                        .Include(c => c.consignor)
                        .Include(c => c.notes)
                        .Include(c => c.documents)
                        .Include(c => c.milestoneLinks)
                        .FirstOrDefaultAsync(x => x.tbl_house_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_houses
                        .FirstOrDefaultAsync(x => x.tbl_house_code == referenceNumber);
                }

                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_house_code,
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
        //Added by HS on 13/01/2023
        //Get consignee reference by house bill number
        public async Task<ResponseDto> GetByBillNumber(string billNumber)
        {
            try
            {

                tbl_house result = new();
                //Edited by HS on 06/02/2023
                result = await _context.tbl_houses.OrderByDescending(x => x.idtbl_house)
                    .FirstOrDefaultAsync(x => x.tbl_house_billNumber == billNumber);

                return new ResponseDto
                {
                    ReferenceNumber = result.ConsigneeCode,
                    DisplayMessage = "success",
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

        public async Task<ResponseDto> GetByMaster(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_houses.Where(x => x.MasterCode == referenceNumber).ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_houseDto>>(result)
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

        public async Task<ResponseDto> GetByContainer(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_houses.Where(x => x.ContainerCode == referenceNumber).ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_houseDto>>(result)
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

        /// <summary>
        /// Creates/updates a house record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_houseDto> CreateUpdateAsync(tbl_houseDto entity)
        {
            try
            {
                tbl_house mappedHouse = _mapper.Map<tbl_houseDto, tbl_house>(entity);


                _context.tbl_houses.Add(mappedHouse);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_house, tbl_houseDto>(mappedHouse);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a house record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_houseDto entity)
        {
            try
            {
                entity.tbl_house_createdDate = DateTime.Now;
                entity.tbl_house_status = "OPEN";
                string referenceNumber = await GetNextId();
                entity.tbl_house_code = referenceNumber;

                var result = _mapper.Map<tbl_houseDto, tbl_house>(entity);

                if (result.idtbl_house > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate HOUSE record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (!String.IsNullOrEmpty(result.VoyageCode))
                    {
                        var master = await _context.tbl_voyages
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.tbl_voyage_code == result.VoyageCode);
                        if (master != null)
                        {
                            result.tbl_master_id = master.idtbl_voyage;
                            //result.MasterCode = master.tbl_master_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to HOUSE. Provided Voyage code was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.MasterCode))
                    {
                        var master = await _context.tbl_masters
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.tbl_master_code == result.MasterCode);
                        if (master != null)
                        {
                            result.tbl_master_id = master.idtbl_master;
                            //result.MasterCode = master.tbl_master_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to HOUSE. Provided MASTER code was not found.",
                                IsSuccess = false
                            };
                        }
                    }

                    if (!String.IsNullOrEmpty(result.ContainerCode))
                    {
                        var parent = await _context.tbl_containers
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.tbl_container_code == entity.ContainerCode);

                        if (parent != null)
                        {
                            result.tbl_container_id = parent.idtbl_container;
                            //result.ContainerCode = parent.tbl_container_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to HOUSE. Provided container reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }

                    if (!string.IsNullOrEmpty(entity.ConsigneeCode))
                    {
                        var consignee = await _context.tbl_client_headers
                            .FirstOrDefaultAsync(p => p.tbl_client_header_code == entity.ConsigneeCode);

                        if (consignee != null)
                        {
                            result.tbl_consignee_id = consignee.idtbl_client_header;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to HOUSE. Invalid Client Header code.",
                                IsSuccess = false
                            };
                        }
                    }

                    if (!string.IsNullOrEmpty(entity.ConsigneeCode))
                    {
                        var consignee = await _context.tbl_client_headers
                            .FirstOrDefaultAsync(p => p.tbl_client_header_code == entity.ConsigneeCode);

                        if (consignee != null)
                        {
                            result.tbl_consignee_id = consignee.idtbl_client_header;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to HOUSE. Invalid Client Header code.",
                                IsSuccess = false
                            };
                        }
                    }

                    if (!string.IsNullOrEmpty(entity.IncotermCode))
                    {
                        var incoterm = await _context.tbl_incoterms
                            .FirstOrDefaultAsync(p => p.tbl_incoterm_code == entity.IncotermCode);
                        if (incoterm != null)
                        {
                            result.tbl_incoterm_id = incoterm.idtbl_incoterm;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to HOUSE. Invalid Incoterm code.",
                                IsSuccess = false
                            };
                        }
                    }

                    await _context.tbl_houses.AddAsync(result);
                    await _context.SaveChangesAsync();

                    return new ResponseDto
                    {
                        Result = _mapper.Map<tbl_houseDto>(result),
                        DisplayMessage = "HOUSE successfully created.",
                        IsSuccess = true,
                        ReferenceNumber = result.tbl_house_code
                    };
                }
                
            }
            catch (Exception ex)
            {
                //if (ex.GetBaseException().ToString().IndexOf("Duplicate") > -1)
                //{
                //    return new ResponseDto
                //    {
                //        Result = entity,
                //        DisplayMessage = "Unable to save record. Possible duplicate SKU code.",
                //        IsSuccess = false
                //    };
                //}
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.Message.ToString(),
                    IsSuccess = false
                };
            }

        }

        /// <summary>
        /// Updates a house record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_houseDto entity)
        {
            try
            {
                var result = await _context.tbl_houses
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_house_code == entity.tbl_house_code);

                if (result != null)
                {
                    _mapper.Map(entity, result);

                    if (!String.IsNullOrEmpty(entity.VoyageCode))
                    {
                        var voyage = await _context.tbl_voyages
                            .AsNoTracking()
                            .SingleOrDefaultAsync(x => x.tbl_voyage_code == entity.VoyageCode);
                        if (voyage != null)
                        {
                            result.tbl_voyage_id = voyage.idtbl_voyage;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to Voyage. Invalid Voyage code.",
                                IsSuccess = false
                            };
                        }
                    }

                    if (entity.MasterCode != "" && entity.MasterCode != null)
                    {
                        var master = await _context.tbl_masters
                        .SingleOrDefaultAsync(x => x.tbl_master_code == entity.MasterCode);

                        if (master != null)
                        {
                            result.tbl_master_id = master.idtbl_master;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to Master. Invalid Master code.",
                                IsSuccess = false
                            };
                        }
                    }

                    if (entity.ContainerCode != "" && entity.ContainerCode != null)
                    {
                        var container = await _context.tbl_containers
                        .SingleOrDefaultAsync(x => x.tbl_container_code == entity.ContainerCode);

                        if (container != null)
                        {
                            result.tbl_container_id = container.idtbl_container;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to Container. Invalid container code.",
                                IsSuccess = false
                            };
                        }
                    }

                    if (!string.IsNullOrEmpty(entity.ConsigneeCode)) 
                    { 
                        var consignee = await _context.tbl_client_headers
                            .SingleOrDefaultAsync(p => p.tbl_client_header_code == entity.ConsigneeCode);

                        if (consignee != null)
                        {
                            result.tbl_consignee_id = consignee.idtbl_client_header;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to Client Header. Invalid Client Header code.",
                                IsSuccess = false
                            };
                        }
                    }

                    if (!string.IsNullOrEmpty(entity.ConsigneeCode))
                    {
                        var consignee = await _context.tbl_client_headers
                            .SingleOrDefaultAsync(p => p.tbl_client_header_code == entity.ConsigneeCode);

                        if (consignee != null)
                        {
                            result.tbl_consignee_id = consignee.idtbl_client_header;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to HOUSE. Invalid Client Header code.",
                                IsSuccess = false
                            };
                        }
                    }

                    if (!string.IsNullOrEmpty(entity.IncotermCode))
                    {
                        var incoterm = await _context.tbl_incoterms
                            .SingleOrDefaultAsync(p => p.tbl_incoterm_code == entity.IncotermCode);
                        if (incoterm != null)
                        {
                            result.tbl_incoterm_id = incoterm.idtbl_incoterm;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to HOUSE. Invalid Incoterm code.",
                                IsSuccess = false
                            };
                        }
                    }
                    _context.ChangeTracker.Clear();
                    _context.tbl_houses.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "HOUSE does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    DisplayMessage = "HOUSE successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = entity.tbl_house_code
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    DisplayMessage = ex.StackTrace.ToString(),
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
                        var entity = await _context.tbl_houses.FirstOrDefaultAsync(x => x.tbl_house_code == reference && x.tbl_house_code.Contains(request.shipperId));
                        if (entity != null)
                        {
                            entity.tbl_master_id = parent.idtbl_master;
                            entity.MasterCode = parent.tbl_master_code;
                            _context.tbl_houses.Update(entity);

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
                        DisplayMessage = failed.Count > 0 ? "failed" : "HOUSE successfully updated with MASTER # " + request.parentReference,
                        ReferenceNumber = request.parentReference
                    };
                }

                return new ResponseDto
                {
                    IsSuccess = false,
                    Result = request.ReferencesToLink,
                    DisplayMessage = "Invalid MASTER number."
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

        public async Task<ResponseDto> LinkToContainerAsync(LinkToContainerRequest request)
        {
            try
            {
                var parent = await _context.tbl_containers.FirstOrDefaultAsync(x => x.tbl_container_code == request.parentReference);
                if (parent != null)
                {
                    List<string> failed = new();
                    foreach (var reference in request.ReferencesToLink)
                    {
                        var entity = await _context.tbl_houses.FirstOrDefaultAsync(x => x.tbl_house_code == reference && x.tbl_house_code.Contains(request.shipperId));
                        if (entity != null)
                        {
                            entity.ContainerCode = parent.tbl_container_code;
                            _context.tbl_houses.Update(entity);

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
                        DisplayMessage = failed.Count > 0 ? "failed" : "HOUSE successfully updated with Container # " + request.parentReference,
                        ReferenceNumber = request.parentReference
                    };
                }

                return new ResponseDto
                {
                    IsSuccess = false,
                    Result = request.ReferencesToLink,
                    DisplayMessage = "Invalid container number."
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

        public async Task<List<tbl_houseDto>> CreateRangeAsync(List<tbl_houseDto> entities)
        {
            List<tbl_house> result = _mapper.Map<List<tbl_houseDto>, List<tbl_house>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_houses.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_house>, List<tbl_houseDto>>(result);
        }

        /// <summary>
        /// Deletes existing house record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_house result = await _context.tbl_houses.FirstOrDefaultAsync(x => x.idtbl_house == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_houses.Remove(result);
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
            //Edited by HS on 01/02/2023
            
            tbl_house result = await _context.tbl_houses.OrderByDescending(x => x.idtbl_house).FirstOrDefaultAsync();

            string referenceCode = "HS" + String.Format("{0:0000000}", (result != null ? result.idtbl_house + count : 1));
            count++;
            return referenceCode;
        }

    }
}
