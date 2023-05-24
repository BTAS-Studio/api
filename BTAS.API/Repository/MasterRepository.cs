using AutoMapper;
using AutoMapper.Internal;
using BTAS.API.Dto;
using BTAS.API.Extensions;
using BTAS.API.Models;
using BTAS.API.Models.Links;
using BTAS.API.Repository.Interface;
using BTAS.API.Repository.SearchRepository;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NJsonSchema.References;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace BTAS.API.Repository
{
    public class MasterRepository : SRepository, IRepository<tbl_masterDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        int count;
        /*1234*/
        public MasterRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }

        /// <summary>
        /// Retrieves all MASTER
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_masterDto>> GetAllAsync()
        {
            IEnumerable<tbl_master> _list = await _context.tbl_masters.OrderByDescending(m => m.idtbl_master).ToListAsync();
            return _mapper.Map<List<tbl_masterDto>>(_list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_masterDto>> GetAllAsyncWithChildren()
        {
            try
            {
                IEnumerable<tbl_master> _list = await _context.tbl_masters.OrderByDescending(x => x.idtbl_master)
                .Include(x => x.voyage)
                .Include(x => x.originAgent)
                .Include(x => x.destinationAgent)
                .Include(x => x.carrierAgent)
                .Include(x => x.creditorAgent)
                .Include(x => x.containers)
                .Include(x => x.houses)
                .ToListAsync();
                //_list = _list.Take(20);
                return _mapper.Map<List<tbl_masterDto>>(_list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Added by HS on 01/05/2023
        /// <summary>
        /// Retrieves a specified number of masters according to input conditions(>, >=, <, <=, ==, !=, and contains)
        /// </summary>
        /// <returns> A list of master objects including their linked parent voyages</returns>
        public async Task<IEnumerable<tbl_masterDto>> GetFilteredAsync(CustomFilters<tbl_masterDto> customFilters)
        {
            try
            {               
                // Achieve the latest record first.
                var qList = _context.tbl_masters.OrderByDescending(m => m.idtbl_master).AsQueryable();
                qList = qList.Include(p => p.voyage);
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
                        if (filter.tableName.ToUpper() == "CONSOLIDATION")
                        {
                            filter.tableName = "master";
                            bool containsDateTime = false;
                            //used for searching Contains DateTime type's columns
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                //if (filter.fieldName == "CreatedDate" )
                                //{
                                //    containsDateTime = true;
                                //    //propertyInfo = typeof(tbl_master).GetProperty(filter.fieldName);
                                //    tbl_masterDto dateCreated = new tbl_masterDto();
                                //    dateCreated.tbl_master_createdDate = new DateTime(1000,01,01); 
                                //    jsonString = JsonConvert.SerializeObject(dateCreated);
                                //}
                                (containsDateTime, jsonString) = MakeMasterJsonString(filter, containsDateTime, jsonString);
                            }

                            var masterFields = JsonConvert.DeserializeObject<tbl_masterDto>(jsonString);
                            var properties = masterFields.GetType().GetProperties();
                            //propertyInfo: get the data table column name from JsonProperty
                            foreach (var property in properties)
                            {
                                var value = property.GetValue(masterFields, null);
                                if (property != null && (value != null && !value.Equals(0) && !value.Equals(new DateTime(0001, 1, 1, 0, 0, 0))))
                                {
                                    propertyInfo = typeof(tbl_master).GetProperty(property.Name);
                                    filter.fieldValue = value;

                                    if (containsDateTime)
                                    {
                                        propertyInfo = typeof(tbl_master).GetProperty(property.Name);
                                        filter.fieldValue = originalValue;
                                    }
                                    break;
                                }
                            }
                        }
                        else if (filter.tableName.ToUpper() == "VOYAGE")
                        {
                            filter.tableName = "voyage";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                //if (filter.fieldName == "ETA")
                                //{
                                //    containsDateTime = true;
                                //    tbl_voyageDto eta = new tbl_voyageDto();
                                //    eta.tbl_voyage_eta = new DateTime(1000, 01, 01);
                                //    jsonString = JsonConvert.SerializeObject(eta);
                                //}
                                //else if (filter.fieldName == "ETD")
                                //{
                                //    containsDateTime = true;
                                //    tbl_voyageDto etd= new tbl_voyageDto();
                                //    etd.tbl_voyage_etd = new DateTime(1000, 01, 01);
                                //    jsonString = JsonConvert.SerializeObject(etd);
                                //}
                                //else if (filter.fieldName == "ATA")
                                //{
                                //    containsDateTime = true;
                                //    tbl_voyageDto ata = new tbl_voyageDto();
                                //    ata.tbl_voyage_ata = new DateTime(1000, 01, 01);
                                //    jsonString = JsonConvert.SerializeObject(ata);
                                //}
                                //else if (filter.fieldName == "ATD")
                                //{
                                //    containsDateTime = true;
                                //    tbl_voyageDto atd = new tbl_voyageDto();
                                //    atd.tbl_voyage_ata = new DateTime(1000, 01, 01);
                                //    jsonString = JsonConvert.SerializeObject(atd);
                                //}
                                //else if (filter.fieldName == "ETADischarge")
                                //{
                                //    containsDateTime = true;
                                //    tbl_voyageDto etaDischarge = new tbl_voyageDto();
                                //    etaDischarge.tbl_voyage_etaDischarge = new DateTime(1000, 01, 01);
                                //    jsonString = JsonConvert.SerializeObject(etaDischarge);
                                //}
                                (containsDateTime, jsonString) = MakeVoyageJsonString(filter, containsDateTime, jsonString);
                            }
                            //var voyageFields = JsonConvert.DeserializeObject<tbl_voyageDto>(jsonString);
                            //var properties = voyageFields.GetType().GetProperties();

                            //foreach (var property in properties)
                            //{
                            //    var value = property.GetValue(voyageFields, null);
                            //    if (property != null && (value != null && !value.Equals(0) && !value.Equals(new DateTime(0001, 1, 1, 0, 0, 0))))
                            //    {
                            //        var masterProperty = typeof(tbl_master).GetProperty(filter.tableName);
                            //        propertyInfo = masterProperty.PropertyType.GetProperty(property.Name);
                            //        filter.fieldValue = value;

                            //        if (containsDateTime == true)
                            //        {
                            //            propertyInfo = typeof(tbl_voyage).GetProperty(property.Name);
                            //            filter.fieldValue = originalValue;
                            //        }
                            //        break; 
                            //    }
                            //}
                            (propertyInfo, filter.fieldValue, containsDateTime) = GetParentPropertyInfo<tbl_master, tbl_voyage, tbl_voyageDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
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

                        Expression<Func<tbl_master, bool>> propertyLambda = null;
                        propertyLambda = GetPropertyLambda<tbl_master>(propertyInfo, filter, parent);

                        if (propertyLambda != null)
                        {
                            qList = qList.Provider.CreateQuery<tbl_master>(Expression.Call(
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
                return _mapper.Map<IEnumerable<tbl_masterDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves a single MASTER based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_masterDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_masters.FirstOrDefaultAsync(x => x.idtbl_master == id);
            return _mapper.Map<tbl_masterDto>(result);

        }
        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild = false)
        {
            try
            {
                tbl_master result = new();
                if (includeChild)
                {
                    result = await _context.tbl_masters
                        .Include(m => m.voyage)
                        .Include(m => m.houses)
                        //Added by HS on 17/05/2023
                        .Include(m => m.containers)
                        //.AsNoTracking()
                        .FirstOrDefaultAsync(m => m.tbl_master_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_masters.FirstOrDefaultAsync(m => m.tbl_master_code == referenceNumber);
                }


                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = _mapper.Map<tbl_masterDto>(result),
                    ReferenceNumber = result.tbl_master_code,
                    DisplayMessage = "Success."

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
        /// Creates/updates a MASTER record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_masterDto> CreateUpdateAsync(tbl_masterDto entity)
        {
            try
            {
                var mappedMaster = _mapper.Map<tbl_masterDto, tbl_master>(entity);


                _context.tbl_masters.Add(mappedMaster);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_master, tbl_masterDto>(mappedMaster);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a MASTER record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_masterDto entity, string shipperId)
        {
            try
            {
                string referenceNumber = await GetNextId(shipperId);
                entity.tbl_master_code = referenceNumber;
                entity.tbl_master_status = "OPEN";

                var result = _mapper.Map<tbl_master>(entity);

                if (result.idtbl_master > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate Master record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (result.VoyageCode != null && result.VoyageCode != "")
                    {
                        var parent = await _context.tbl_voyages.FirstOrDefaultAsync(x => x.tbl_voyage_code == result.VoyageCode);
                        if (parent != null)
                        {
                            result.tbl_voyage_id = parent.idtbl_voyage;
                            result.VoyageCode = parent.tbl_voyage_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link Master. Provided Voyage reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }

                    await _context.tbl_masters.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Master successfully created.",
                        IsSuccess = true,
                        ReferenceNumber = result.tbl_master_code
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
        /// Updates a MASTER record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_masterDto entity)
        {
            try
            {
                var result = await _context.tbl_masters
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_master_code == entity.tbl_master_code);

                _mapper.Map<tbl_masterDto, tbl_master>(entity, result);
                if (result != null)
                {
                    if (entity.VoyageCode != "" && entity.VoyageCode != null)
                    {
                        var parent = await _context.tbl_voyages
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.tbl_voyage_code == entity.VoyageCode);

                        if (parent != null)
                        {
                            result.tbl_voyage_id = parent.idtbl_voyage;
                            result.VoyageCode = parent.tbl_voyage_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Invalid voyage id or number.",
                                IsSuccess = false
                            };
                        }
                    }

                    _context.ChangeTracker.Clear();
                    _context.tbl_masters.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "MASTER does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "MASTER successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_master_code
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

        public async Task<ResponseDto> LinkToVoyageAsync(LinkToVoyageRequest request)
        {
            try
            {
                var parent = await _context.tbl_voyages.FirstOrDefaultAsync(x => x.tbl_voyage_code == request.parentReference);
                if (parent != null)
                {
                    List<string> failed = new();
                    foreach (var reference in request.ReferencesToLink)
                    {
                        var entity = await _context.tbl_masters.FirstOrDefaultAsync(x => x.tbl_master_code == reference && x.tbl_master_code.Contains(request.shipperId));
                        if (entity != null)
                        {
                            entity.tbl_voyage_id = parent.idtbl_voyage;
                            entity.VoyageCode = parent.tbl_voyage_code;

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
                        DisplayMessage = failed.Count > 0 ? "failed" : "MASTER successfully updated with Voyage # " + request.parentReference,
                        ReferenceNumber = request.parentReference
                    };
                }

                return new ResponseDto
                {
                    IsSuccess = false,
                    Result = request.ReferencesToLink,
                    DisplayMessage = "Invalid voyage number."
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

        /// <summary>
        /// Deletes existing MASTER record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_master result = await _context.tbl_masters.FirstOrDefaultAsync(x => x.idtbl_master == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_masters.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetByVoyage(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_masters.Where(x => x.VoyageCode == referenceNumber).ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_masterDto>>(result)
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

        public async Task<string> GetNextId(string shipperId)
        {
            tbl_master result = await _context.tbl_masters.OrderByDescending(x => x.idtbl_master).FirstOrDefaultAsync();

            string referenceCode = "MS" + shipperId + String.Format("{0:0000000000}", (result != null ? result.idtbl_master + count : 1));
            count++;
            return referenceCode;
        }
    }
}
