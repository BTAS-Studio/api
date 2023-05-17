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
    public class HouseIncotermsRepository : IRepository<tbl_incotermDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public HouseIncotermsRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all HOUSE incoterm
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_incotermDto>> GetAllAsync()
        {
            var _list = await _context.tbl_incoterms.ToListAsync();
            return _mapper.Map<List<tbl_incotermDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single HOUSE incoterm based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_incotermDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_incoterms.FirstOrDefaultAsync(x => x.idtbl_incoterm == id);
            return _mapper.Map<tbl_incotermDto>(result);

        }

        /// <summary>
        /// Creates/updates a HOUSE incoterm record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_incotermDto> CreateUpdateAsync(tbl_incotermDto entity)
        {
            try
            {
                var mapped = _mapper.Map<tbl_incotermDto, tbl_incoterm>(entity);


                _context.tbl_incoterms.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_incoterm, tbl_incotermDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a HOUSE incoterm record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_incotermDto entity)
        {
            try
            {
                var result = _mapper.Map<tbl_incotermDto, tbl_incoterm>(entity);
                if (result.idtbl_incoterm > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate HOUSE incoterm record",
                        IsSuccess = false
                    };
                }
                else
                {
                    _context.tbl_incoterms.Add(result);
                }
                await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "HOUSE incoterm successfully added.",
                    IsSuccess = true
                };
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
        /// Updates a HOUSE incoterm record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_incotermDto entity)
        {
            try
            {
                var mapped = _mapper.Map<tbl_incoterm>(entity);

                var incoterms = await _context.tbl_incoterms
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.idtbl_incoterm == mapped.idtbl_incoterm || x.tbl_incoterm_code == mapped.tbl_incoterm_code);

                if (incoterms != null)
                {
                    mapped.idtbl_incoterm = incoterms.idtbl_incoterm;
                    mapped.tbl_incoterm_code = incoterms.tbl_incoterm_code;

                    _context.tbl_incoterms.Update(mapped);
                    await _context.SaveChangesAsync();

                    return new ResponseDto
                    {
                        Result = _mapper.Map<tbl_incotermDto>(mapped),
                        DisplayMessage = "HOUSE Incoterms successfully updated.",
                        IsSuccess = true
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "HOUSE Incoterms successfully updated.",
                    IsSuccess = true
                };
            }
            catch(Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.StackTrace.ToString(),
                    IsSuccess = false
                };
            }
            
        }

        public async Task<List<tbl_incotermDto>> CreateRangeAsync(List<tbl_incotermDto> entities)
        {
            var result = _mapper.Map<List<tbl_incotermDto>, List<tbl_incoterm>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_incoterms.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_incoterm>, List<tbl_incotermDto>>(result);
        }

        /// <summary>
        /// Deletes existing HOUSE incoterm record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _context.tbl_incoterms.FirstOrDefaultAsync(x => x.idtbl_incoterm == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_incoterms.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetByReference(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_incoterms
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.tbl_incoterm_code == referenceNumber);

                return new ResponseDto
                {
                    Result = _mapper.Map<tbl_incoterm>(result)
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

        public Task<IEnumerable<tbl_incotermDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_incotermDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_incotermDto>> GetAllAsyncWithChildren(searchFilter<tbl_incotermDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
