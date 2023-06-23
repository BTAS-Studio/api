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
    public class VoyageRepository : SRepository, IRepository<tbl_voyageDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private MasterRepository _masterRepo;
        private ContainerRepository _containerRepo;
        private HouseRepository _houseRepo;
        private ReceptacleRepository _receptacleRepo;

        public VoyageRepository(MainDbContext context, IMapper mapper, MasterRepository masterRepo, ContainerRepository containerRepo, HouseRepository houseRepo, ReceptacleRepository receptacleRepo)
        {
            _context = context;
            _mapper = mapper;
            _masterRepo = masterRepo;
            _containerRepo = containerRepo;
            _houseRepo = houseRepo;
            _receptacleRepo = receptacleRepo;
        }

        /// <summary>
        /// Retrieves all voyage
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_voyageDto>> GetAllAsync()
        {
            var _list = await _context.tbl_voyages.OrderByDescending(v => v.idtbl_voyage).ToListAsync();
            return _mapper.Map<List<tbl_voyageDto>>(_list);
        }

        public async Task<IEnumerable<tbl_voyageDto>> GetAllAsyncWithChildren()
        {
            var _list = await _context.tbl_voyages.OrderByDescending(v=> v.idtbl_voyage)
                .Include(v => v.masters)
                .Include(v => v.houses)
                .ToListAsync();
            return _mapper.Map<List<tbl_voyageDto>>(_list);
        }

        //Added by HS on 24/05/2023
        /// <summary>
        /// Retrieves a specified number of voyages according to input conditions(>, >=, <, <=, ==, !=, and contains)
        /// </summary>
        /// <returns> A list of voyage objects</returns>
        public async Task<IEnumerable<tbl_voyageDto>> GetFilteredAsync(CustomFilters<tbl_voyageDto> customFilters)
        {
            try
            {
                var qList = _context.tbl_voyages
                    //.AsNoTracking()
                    .OrderByDescending(h => h.idtbl_voyage).AsQueryable();
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

                        if (filter.tableName.ToUpper() == "VOYAGE")
                        {
                            filter.tableName = "voyage";
                            bool containsDateTime = false;
                            //used for searching Contains DateTime type's columns
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeVoyageJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetPropertyInfo<tbl_voyageDto, tbl_voyage>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
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

                        Expression<Func<tbl_voyage, bool>> propertyLambda = null;
                        propertyLambda = GetPropertyLambda<tbl_voyage>(propertyInfo, filter, parent);

                        if (propertyLambda != null)
                        {
                            //qList = qList.Provider.CreateQuery<tbl_voyage>(Expression.Call(
                            //           typeof(Queryable),
                            //           "Where",
                            //           new[] { elementType },
                            //           qList.Expression,
                            //           propertyLambda
                            //       ));
                            qList = qList.Where(propertyLambda);
                        }
                    }
                }

                if (qList.Count() == 0)
                {
                    return null;
                }
                var filtered = await qList.Skip(customFilters.Page * customFilters.PageSize).Take(customFilters.PageSize).ToListAsync();
                return _mapper.Map<IEnumerable<tbl_voyageDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves a single voyage based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_voyageDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_voyages
                .Include(c => c.masters)
                .Include(p => p.houses)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.idtbl_voyage == id);
            return _mapper.Map<tbl_voyageDto>(result);

        }

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild = false)
        {
            try
            {
                tbl_voyage result = new();
                if (includeChild)
                {
                    result = await _context.tbl_voyages
                        .Include(v => v.masters)
                        .Include(c => c.houses)
                        .FirstOrDefaultAsync(v => v.tbl_voyage_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_voyages.FirstOrDefaultAsync(v => v.tbl_voyage_code == referenceNumber);
                }
                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = _mapper.Map<tbl_voyageDto>(result),
                    ReferenceNumber = result.tbl_voyage_code,
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
        /// Creates/updates a voyage record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_voyageDto> CreateUpdateAsync(tbl_voyageDto entity)
        {
            try
            {
                var mapped = _mapper.Map<tbl_voyageDto, tbl_voyage>(entity);


                _context.tbl_voyages.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_voyage, tbl_voyageDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a voyage record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_voyageDto entity, string shipperId)
        {
            if (entity == null) throw new ArgumentNullException();
            try
            {
                //Edited by HS on 13/12/2022
                //tbl_voyage result = _mapper.Map<tbl_voyageDto, tbl_voyage>(entity);
                var result = _mapper.Map<tbl_voyage>(entity);

                string referenceNumber = await GetNextId();
                result.tbl_voyage_code = referenceNumber;
                result.tbl_voyage_status = "OPEN";

                if (result.idtbl_voyage > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate voyage record",
                        IsSuccess = false
                    };
                }

                //Added by HS on 01/02/2023 
                if (result.masters.Count != 0)
                {
                    foreach (var master in result.masters)
                    {
                        //Generate master reference
                        master.tbl_master_code = await _masterRepo.GetNextId();
                        //link master to voyage
                        master.VoyageCode = referenceNumber;
                        //Master Sea
                        if (master.containers.Count != 0)
                        {
                            foreach (var container in master.containers)
                            {
                                container.tbl_container_code = await _containerRepo.GetNextId();
                                container.MasterCode = master.tbl_master_code;
                                if (container.houses.Count != 0)
                                {
                                    foreach (var house in container.houses)
                                    {
                                        house.tbl_house_code = await _houseRepo.GetNextId();
                                        house.ContainerCode = container.tbl_container_code;
                                        house.tbl_master_id = container.tbl_master_id;
                                        house.MasterCode = container.MasterCode;
                                        //if (house.receptacles.Count != 0)
                                        //{
                                        //    foreach (var receptacle in house.receptacles)
                                        //    {
                                        //        receptacle.tbl_receptacle_code = await _receptacleRepo.GetNextId(shipperId);
                                        //        receptacle.HouseCode = house.tbl_house_code;
                                        //    }
                                        //}
                                    }
                                }
                            }
                        }
                        //Master Air
                        else if (master.houses.Count != 0)
                        {
                            foreach (var house in master.houses)
                            {
                                house.tbl_house_code = await _houseRepo.GetNextId();
                                house.MasterCode = master.tbl_master_code;
                                //if (house.receptacles.Count != 0)
                                //{
                                //    foreach (var receptacle in house.receptacles) 
                                //    {
                                //        receptacle.tbl_receptacle_code = await _receptacleRepo.GetNextId(shipperId);
                                //        receptacle.HouseCode = house.tbl_house_code;
                                //    }
                                //}
                            }
                        }
                    }
                }

                await _context.tbl_voyages.AddAsync(result);
                await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Voyage successfully created.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_voyage_code
                };
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
        /// Updates a voyage record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_voyageDto entity)
        {
            try
            {
                var result = await _context.tbl_voyages
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_voyage_code == entity.tbl_voyage_code);
                //.FirstOrDefaultAsync(x => x.idtbl_voyage == mapped.idtbl_voyage || x.tbl_voyage_number == mapped.tbl_voyage_number);

                if (result != null)
                {
                    //mapped.idtbl_voyage = voyage.idtbl_voyage;
                    //mapped.tbl_voyage_number = address.tbl_voyage_number;
                    _mapper.Map<tbl_voyageDto, tbl_voyage>(entity, result);

                    _context.ChangeTracker.Clear();
                    _context.tbl_voyages.Update(result);
                    await _context.SaveChangesAsync();

                    return new ResponseDto
                    {
                        DisplayMessage = "Voyage successfully updated.",
                        IsSuccess = true,
                        ReferenceNumber = result.tbl_voyage_code
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Voyage does not exists.",
                        IsSuccess = false
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
                    ErrorCode = ex.HResult,
                    DisplayMessage = ex.StackTrace.ToString(),
                    IsSuccess = false
                };
            }

        }

        public async Task<List<tbl_voyageDto>> CreateRangeAsync(List<tbl_voyageDto> entities)
        {
            var result = _mapper.Map<List<tbl_voyageDto>, List<tbl_voyage>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_voyages.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_voyage>, List<tbl_voyageDto>>(result);
        }

        /// <summary>
        /// Deletes existing voyage record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _context.tbl_voyages.FirstOrDefaultAsync(x => x.idtbl_voyage == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_voyages.Remove(result);
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
            var result = await _context.tbl_voyages.OrderByDescending(x => x.idtbl_voyage).FirstOrDefaultAsync();

            string referenceCode = "VY" + String.Format("{0:0000000}", (result != null ? result.idtbl_voyage + 1 : 1));
            return referenceCode;
        }
    }
}
