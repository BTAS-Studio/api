using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class RoutingRepository : IRepository<tbl_routingDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public RoutingRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all routing
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_routingDto>> GetAllAsync()
        {
            IEnumerable<tbl_routing> _list = await _context.tbl_routings.ToListAsync();
            return _mapper.Map<List<tbl_routingDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single routing based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_routingDto> GetByIdAsync(int id)
        {

            tbl_routing result = await _context.tbl_routings.FirstOrDefaultAsync(x => x.idtbl_routing == id);
            return _mapper.Map<tbl_routingDto>(result);

        }

        /// <summary>
        /// Creates/updates a routing record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_routingDto> CreateUpdateAsync(tbl_routingDto entity)
        {
            try
            {
                tbl_routing mapped = _mapper.Map<tbl_routingDto, tbl_routing>(entity);


                _context.tbl_routings.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_routing, tbl_routingDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a routing record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_routingDto entity)
        {
            try
            {
                tbl_routing result = _mapper.Map<tbl_routingDto, tbl_routing>(entity);

                if (result.idtbl_routing > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate routing record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if ((result.VoyageNumber != "" || result.VoyageNumber !=null) && result.tbl_voyage_id > 0)
                    {
                        tbl_voyage voyage = await _context.tbl_voyages.FirstOrDefaultAsync(x => x.idtbl_voyage == result.tbl_voyage_id || x.tbl_voyage_number == result.VoyageNumber);
                        if (voyage != null)
                        {
                            result.tbl_voyage_id = voyage.idtbl_voyage;
                            result.VoyageNumber = voyage.tbl_voyage_number;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Provided voyage reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    await _context.tbl_routings.AddAsync(result);
                }
                await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Routing successfully added.",
                    IsSuccess = true
                };
            }
            catch(Exception ex)
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
        /// Updates a routing record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_routingDto entity)
        {
            try
            {
                var result = await _context.tbl_routings
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.idtbl_routing == entity.idtbl_routing);
                if (result != null)
                {
                    if(entity.tbl_voyage_id.HasValue || (entity.VoyageNumber != "" && entity.VoyageNumber != null))
                    {
                        var voyage = await _context.tbl_voyages
                        .FirstOrDefaultAsync(x => x.idtbl_voyage == entity.tbl_voyage_id || x.tbl_voyage_number == entity.VoyageNumber);

                        if (voyage != null)
                        {
                            result.tbl_voyage_id = voyage.idtbl_voyage;
                            result.VoyageNumber = voyage.tbl_voyage_number;
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
                    

                    _context.tbl_routings.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Routing does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Routing successfully updated.",
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

        public async Task<List<tbl_routingDto>> CreateRangeAsync(List<tbl_routingDto> entities)
        {
            List<tbl_routing> result = _mapper.Map<List<tbl_routingDto>, List<tbl_routing>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_routings.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_routing>, List<tbl_routingDto>>(result);
        }

        /// <summary>
        /// Deletes existing routing record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_routing result = await _context.tbl_routings.FirstOrDefaultAsync(x => x.idtbl_routing == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_routings.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<IEnumerable<tbl_routingDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_routingDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_routingDto>> GetAllAsyncWithChildren(searchFilter<tbl_routingDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
