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
    public class ServiceRepository : IRepository<tbl_servicesDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public ServiceRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all services
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_servicesDto>> GetAllAsync()
        {
            var _list = await _context.tbl_services.ToListAsync();
            return _mapper.Map<List<tbl_servicesDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single service based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_servicesDto> GetByIdAsync(int id)
        {

            var manifest = await _context.tbl_services.FirstOrDefaultAsync(x => x.tbl_services_id == id);
            return _mapper.Map<tbl_servicesDto>(manifest);

        }
        
        /// <summary>
        /// Creates/updates a service record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_servicesDto> CreateUpdateAsync(tbl_servicesDto entity)
        {
            var service = _mapper.Map<tbl_servicesDto, tbl_service>(entity);
            if (service.tbl_services_id > 0)
            {
                _context.tbl_services.Update(service);
            }
            else
            {
                _context.tbl_services.Add(service);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<tbl_service, tbl_servicesDto>(service);
        }

        /// <summary>
        /// Deletes existing service record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var service = await _context.tbl_services.FirstOrDefaultAsync(x => x.tbl_services_id == id);
                if (service == null)
                {
                    return false;
                }
                _context.tbl_services.Remove(service);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<IEnumerable<tbl_servicesDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_servicesDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_servicesDto>> GetAllAsyncWithChildren(searchFilter<tbl_servicesDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
