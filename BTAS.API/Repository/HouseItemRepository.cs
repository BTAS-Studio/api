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
    public class HouseItemRepository : IRepository<tbl_house_itemDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public HouseItemRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all HOUSE Item
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_house_itemDto>> GetAllAsync()
        {
            var _list = await _context.tbl_house_items.ToListAsync();
            return _mapper.Map<List<tbl_house_itemDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single HOUSE Item based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_house_itemDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_house_items.FirstOrDefaultAsync(x => x.idtbl_house_item == id);
            return _mapper.Map<tbl_house_itemDto>(result);

        }

        /// <summary>
        /// Creates/updates a HOUSE Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_house_itemDto> CreateUpdateAsync(tbl_house_itemDto entity)
        {
            try
            {
                var mapped = _mapper.Map<tbl_house_itemDto, tbl_house_item>(entity);


                _context.tbl_house_items.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_house_item, tbl_house_itemDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a HOUSE Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_house_itemDto entity)
        {
            try
            {
                var result = _mapper.Map<tbl_house_itemDto, tbl_house_item>(entity);
                if (result.idtbl_house_item > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate HOUSE Item record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if ((result.HouseCode != null && result.HouseCode != "") || result.tbl_house_id.HasValue)
                    {
                        var house = await _context.tbl_houses
                            .FirstOrDefaultAsync(x => x.idtbl_house == result.tbl_house_id || x.tbl_house_code == result.HouseCode);
                        if (house != null)
                        {
                            result.tbl_house_id = house.idtbl_house;
                            result.HouseCode = house.tbl_house_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link item. Provided HOUSE code was not found.",
                                IsSuccess = false
                            };
                        }
                    }

                    await _context.tbl_house_items.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "HOUSE Item successfully added.",
                        IsSuccess = true
                    };
                }
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
        /// Updates a HOUSE Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_house_itemDto entity)
        {
            try
            {
                if (entity.idtbl_house_item > 0)
                {
                    var result = await _context.tbl_house_items
                        .SingleOrDefaultAsync(x => x.idtbl_house_item == entity.idtbl_house_item);
                    if (result != null)
                    {
                        var house = await _context.tbl_houses
                            .SingleOrDefaultAsync(x => x.idtbl_house == entity.tbl_house_id || x.tbl_house_code == entity.HouseCode);
                        if (house != null)
                        {
                            result.tbl_house_id = house.idtbl_house;
                            result.HouseCode = house.tbl_house_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link item. Provided HOUSE code was not found.",
                                IsSuccess = false
                            };
                        }
                        _context.tbl_house_items.Update(result);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return new ResponseDto
                        {
                            Result = _mapper.Map<tbl_house_itemDto>(result),
                            DisplayMessage = "HOUSE Item does not exists.",
                            IsSuccess = false
                        };
                    }

                    return new ResponseDto
                    {
                        Result = _mapper.Map<tbl_house_itemDto>(result),
                        DisplayMessage = "HOUSE Item successfully updated.",
                        IsSuccess = true
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Invalid HOUSE Item Id.",
                        IsSuccess = false
                    };
                }

               
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

        public async Task<List<tbl_house_itemDto>> CreateRangeAsync(List<tbl_house_itemDto> entities)
        {
            var result = _mapper.Map<List<tbl_house_itemDto>, List<tbl_house_item>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_house_items.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_house_item>, List<tbl_house_itemDto>>(result);
        }

        /// <summary>
        /// Deletes existing HOUSE Item record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _context.tbl_house_items.FirstOrDefaultAsync(x => x.idtbl_house_item == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_house_items.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetByHouse(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_house_items.Where(x => x.HouseCode == referenceNumber).ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_house_item>>(result)
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

        public Task<IEnumerable<tbl_house_itemDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_house_itemDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_house_itemDto>> GetAllAsyncWithChildren(searchFilter<tbl_house_itemDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
