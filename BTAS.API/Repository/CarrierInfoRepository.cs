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
    public class CarrierInfoRepository : IRepository<tbl_carrier_infoDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public CarrierInfoRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all carrier info
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_carrier_infoDto>> GetAllAsync()
        {
            IEnumerable<tbl_carrier_info> _list = await _context.tbl_carrier_infos.ToListAsync();
            return _mapper.Map<List<tbl_carrier_infoDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single carrier info based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_carrier_infoDto> GetByIdAsync(int id)
        {

            tbl_carrier_info manifest = await _context.tbl_carrier_infos.FirstOrDefaultAsync(x => x.idtbl_carrier_info == id);
            return _mapper.Map<tbl_carrier_infoDto>(manifest);

        }
        
        /// <summary>
        /// Creates/updates a manifest record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_carrier_infoDto> CreateUpdateAsync(tbl_carrier_infoDto entity)
        {
            tbl_carrier_info carrier = _mapper.Map<tbl_carrier_infoDto, tbl_carrier_info>(entity);
            if (carrier.idtbl_carrier_info > 0)
            {
                _context.tbl_carrier_infos.Update(carrier);
            }
            else
            {
                _context.tbl_carrier_infos.Add(carrier);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<tbl_carrier_info, tbl_carrier_infoDto>(carrier);
        }

        /// <summary>
        /// Deletes existing manifested record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_carrier_info manifest = await _context.tbl_carrier_infos.FirstOrDefaultAsync(x => x.idtbl_carrier_info == id);
                if (manifest == null)
                {
                    return false;
                }
                _context.tbl_carrier_infos.Remove(manifest);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<IEnumerable<tbl_carrier_infoDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_carrier_infoDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_carrier_infoDto>> GetAllAsyncWithChildren(searchFilter<tbl_carrier_infoDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
