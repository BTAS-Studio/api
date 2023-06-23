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
    public class ItemSkuRepository : IRepository<tbl_item_skuDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public ItemSkuRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all Item SKU
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_item_skuDto>> GetAllAsync()
        {
            IEnumerable<tbl_item_sku> _list = await _context.tbl_item_skus.ToListAsync();
            return _mapper.Map<List<tbl_item_skuDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single Item SKU based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_item_skuDto> GetByIdAsync(int id)
        {

            tbl_item_sku result = await _context.tbl_item_skus.FirstOrDefaultAsync(x => x.idtbl_item_sku == id);
            return _mapper.Map<tbl_item_skuDto>(result);

        }

        /// <summary>
        /// Retrieves a single Item SKU based on code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<tbl_item_skuDto> GetByReferenceAsync(string code)
        {
            try
            {
                var result = await _context.tbl_item_skus.FirstOrDefaultAsync(x => x.tbl_item_sku_code.Equals(code));
                return _mapper.Map<tbl_item_skuDto>(result);
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

        /// <summary>
        /// Creates/updates a Item SKU record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_item_skuDto> CreateUpdateAsync(tbl_item_skuDto entity)
        {
            try
            {
                tbl_item_sku mapped = _mapper.Map<tbl_item_skuDto, tbl_item_sku>(entity);


                _context.tbl_item_skus.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_item_sku, tbl_item_skuDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a Item SKU record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_item_skuDto entity)
        {
            try
            {
                tbl_item_sku result = _mapper.Map<tbl_item_skuDto, tbl_item_sku>(entity);

                if (result.idtbl_item_sku > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate SKU record",
                        IsSuccess = false
                    };
                }

                await _context.tbl_item_skus.AddAsync(result);

                await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "SKU successfully added.",
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
        /// Updates a Item SKU record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_item_skuDto entity)
        {
            try
            {
                var result = await _context.tbl_item_skus.AsNoTracking()
                        .SingleOrDefaultAsync(x => x.idtbl_item_sku == entity.idtbl_item_sku);
                if (result != null)
                {
                    _mapper.Map(entity, result);
                    _context.ChangeTracker.Clear();
                    _context.tbl_item_skus.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Item SKU does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Item SKU successfully updated.",
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

        public async Task<List<tbl_item_skuDto>> CreateRangeAsync(List<tbl_item_skuDto> entities)
        {
            List<tbl_item_sku> result = _mapper.Map<List<tbl_item_skuDto>, List<tbl_item_sku>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_item_skus.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_item_sku>, List<tbl_item_skuDto>>(result);
        }

        /// <summary>
        /// Deletes existing Item SKU record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_item_sku result = await _context.tbl_item_skus.FirstOrDefaultAsync(x => x.idtbl_item_sku == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_item_skus.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<IEnumerable<tbl_item_skuDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_item_skuDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_item_skuDto>> GetAllAsyncWithChildren(searchFilter<tbl_item_skuDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
