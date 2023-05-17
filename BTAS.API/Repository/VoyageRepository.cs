using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class VoyageRepository : IRepository<tbl_voyageDto>
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
            var _list = await _context.tbl_voyages
                .Include(c => c.masters)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<tbl_voyageDto>>(_list);
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
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.idtbl_voyage == id);
            return _mapper.Map<tbl_voyageDto>(result);

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

                string referenceNumber = await GetNextId(shipperId);
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
                        master.tbl_master_code = await _masterRepo.GetNextId(shipperId);
                        //link master to voyage
                        master.VoyageCode = referenceNumber;
                        //Master Sea
                        if (master.containers.Count != 0)
                        {
                            foreach (var container in master.containers)
                            {
                                container.tbl_container_code = await _containerRepo.GetNextId(shipperId);
                                container.MasterCode = master.tbl_master_code;
                                if (container.houses.Count != 0)
                                {
                                    foreach (var house in container.houses)
                                    {
                                        house.tbl_house_code = await _houseRepo.GetNextId(shipperId);
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
                                house.tbl_house_code = await _houseRepo.GetNextId(shipperId);
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
                var voyage = await _context.tbl_voyages
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.tbl_voyage_code == entity.tbl_voyage_code);
                //.FirstOrDefaultAsync(x => x.idtbl_voyage == mapped.idtbl_voyage || x.tbl_voyage_number == mapped.tbl_voyage_number);

                if (voyage != null)
                {
                    //mapped.idtbl_voyage = voyage.idtbl_voyage;
                    //mapped.tbl_voyage_number = address.tbl_voyage_number;
                    _mapper.Map<tbl_voyageDto, tbl_voyage>(entity, voyage);

                    _context.ChangeTracker.Clear();
                    _context.tbl_voyages.Update(voyage);
                    await _context.SaveChangesAsync();

                    return new ResponseDto
                    {
                        Result = _mapper.Map<tbl_voyageDto>(voyage),
                        DisplayMessage = "Voyage successfully updated.",
                        IsSuccess = true,
                        ReferenceNumber = voyage.tbl_voyage_code
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

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild = false)
        {
            try
            {
                var result = new tbl_voyage();
                //if (includeChild)
                //{
                //    result = await _context.tbl_voyage
                //        .Include(c => c.masters)
                //        .FirstOrDefaultAsync(x => x.tbl_voyage_number == referenceNumber);
                //}
                //else
                //{
                //    result = await _context.tbl_voyages.FirstOrDefaultAsync(x => x.tbl_voyage_number == referenceNumber);
                //}
                result = await _context.tbl_voyages
                    .Include(c => c.masters)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.tbl_voyage_code == referenceNumber);

                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_voyage_code,
                    DisplayMessage = "Success",
                    Result = _mapper.Map<tbl_voyageDto>(result)
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
            var result = await _context.tbl_voyages.OrderByDescending(x => x.idtbl_voyage).FirstOrDefaultAsync();

            string referenceCode = "VY" + shipperId + String.Format("{0:0000000000}", (result != null ? result.idtbl_voyage + 1 : 1));
            return referenceCode;
        }

        public Task<IEnumerable<tbl_voyageDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_voyageDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_voyageDto>> GetAllAsyncWithChildren(searchFilter<tbl_voyageDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
