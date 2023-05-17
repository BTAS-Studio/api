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
    public class ApiResponseRepository : IRepository<tbl_carrier_api_responseDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public ApiResponseRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all carrier info
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_carrier_api_responseDto>> GetAllAsync()
        {
            try
            {
                var result = await _context.tbl_carrier_infos.ToListAsync();
                return _mapper.Map<List<tbl_carrier_api_responseDto>>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves a single API Response based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_carrier_api_responseDto> GetByIdAsync(int id)
        {
            try
            {
                var result = await _context.tbl_carrier_api_responses.FirstOrDefaultAsync(x => x.idtbl_carrier_api_response == id);

                return _mapper.Map<tbl_carrier_api_responseDto>(result);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// Creates/updates a API response record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_carrier_api_responseDto> CreateUpdateAsync(tbl_carrier_api_responseDto entity)
        {
            try
            {
                var result = _mapper.Map<tbl_carrier_api_response>(entity);
                if (result.idtbl_carrier_api_response > 0)
                {
                    _context.tbl_carrier_api_responses.Update(result);
                }
                else
                {
                    _context.tbl_carrier_api_responses.Add(result);
                }
                await _context.SaveChangesAsync();

                return _mapper.Map<tbl_carrier_api_responseDto>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes existing API response record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _context.tbl_carrier_api_responses.FirstOrDefaultAsync(x => x.idtbl_carrier_api_response == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_carrier_api_responses.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<IEnumerable<tbl_carrier_api_responseDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_carrier_api_responseDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_carrier_api_responseDto>> GetAllAsyncWithChildren(searchFilter<tbl_carrier_api_responseDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
