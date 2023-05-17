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
    public class BarcodeRepository : IRepository<tbl_barcodeDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public BarcodeRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all barcodes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_barcodeDto>> GetAllAsync()
        {
           var _list = await _context.tbl_barcodes.ToListAsync();
            return _mapper.Map<List<tbl_barcodeDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single barcode based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_barcodeDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_barcodes.FirstOrDefaultAsync(x => x.tbl_barcodes_id == id);
            return _mapper.Map<tbl_barcodeDto>(result);

        }

        /// <summary>
        /// Creates/updates a barcode record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_barcodeDto> CreateUpdateAsync(tbl_barcodeDto entity)
        {
            var mapped = _mapper.Map<tbl_barcode>(entity);
            if (mapped.tbl_barcodes_id > 0)
            {
                _context.tbl_barcodes.Update(mapped);
            }
            else
            {
                _context.tbl_barcodes.Add(mapped);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<tbl_barcodeDto>(mapped);
        }

        public Task<IEnumerable<tbl_barcodeDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_barcodeDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_barcodeDto>> GetAllAsyncWithChildren(searchFilter<tbl_barcodeDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
