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
    public class SettingsRepository : IRepository<tbl_default_settingDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public SettingsRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all default settings
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_default_settingDto>> GetAllAsync()
        {
            var _list = await _context.tbl_default_settings.ToListAsync();
            return _mapper.Map<List<tbl_default_settingDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single default settings based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_default_settingDto> GetByIdAsync(int id)
        {

            var manifest = await _context.tbl_default_settings.FirstOrDefaultAsync(x => x.idtbl_default_settings == id);
            return _mapper.Map<tbl_default_settingDto>(manifest);

        }

        /// <summary>
        /// Creates/updates a default settings record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_default_settingDto> CreateUpdateAsync(tbl_default_settingDto entity)
        {
            var carrier = _mapper.Map<tbl_default_settingDto, tbl_default_setting>(entity);
            if (carrier.idtbl_default_settings > 0)
            {
                _context.tbl_default_settings.Update(carrier);
            }
            else
            {
                _context.tbl_default_settings.Add(carrier);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<tbl_default_setting, tbl_default_settingDto>(carrier);
        }

        /// <summary>
        /// Deletes existing default settings record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var manifest = await _context.tbl_default_settings.FirstOrDefaultAsync(x => x.idtbl_default_settings == id);
                if (manifest == null)
                {
                    return false;
                }
                _context.tbl_default_settings.Remove(manifest);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<IEnumerable<tbl_default_settingDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_default_settingDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_default_settingDto>> GetAllAsyncWithChildren(searchFilter<tbl_default_settingDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
