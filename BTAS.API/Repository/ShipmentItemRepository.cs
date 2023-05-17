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
    public class ShipmentItemRepository : IRepository<tbl_shipment_itemDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public ShipmentItemRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all Parcel Item
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_shipment_itemDto>> GetAllAsync()
        {
            var _list = await _context.tbl_shipment_items
                .ToListAsync();
            return _mapper.Map<List<tbl_shipment_itemDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single Parcel Item based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_shipment_itemDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_shipment_items.FirstOrDefaultAsync(x => x.idtbl_shipment_item == id);
            return _mapper.Map<tbl_shipment_itemDto>(result);

        }

        /// <summary>
        /// Creates/updates a Parcel Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_shipment_itemDto> CreateUpdateAsync(tbl_shipment_itemDto entity)
        {
            try
            {
                var mapped = _mapper.Map<tbl_shipment_itemDto, tbl_shipment_item>(entity);


                _context.tbl_shipment_items.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_shipment_item, tbl_shipment_itemDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a Parcel Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_shipment_itemDto entity)
        {
            try
            {
                var result = _mapper.Map<tbl_shipment_itemDto, tbl_shipment_item>(entity);

                if (result.idtbl_shipment_item > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate shipment item record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if ((result.tbl_shipment_item_code != null && result.tbl_shipment_item_code != "") || result.tbl_shipment_id.HasValue)
                    {
                        var shipment = await _context.tbl_shipments
                            .FirstOrDefaultAsync(x => x.idtbl_shipment == result.tbl_shipment_id || x.tbl_shipment_code == result.ShipmentCode);
                        if (shipment != null)
                        {
                            result.tbl_shipment_id = shipment.idtbl_shipment;
                            result.ShipmentCode = shipment.tbl_shipment_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link item. Provided parcel info reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                        
                    await _context.tbl_shipment_items.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Shipment Item successfully added.",
                        IsSuccess = true
                    };
                }
                
            }
            catch (Exception ex)
            {
                if(ex.GetBaseException().ToString().IndexOf("Duplicate") > -1)
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
                    DisplayMessage = ex.Message.ToString(),
                    IsSuccess = false
                };
            }
            
        }

        /// <summary>
        /// Updates a Parcel Item record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_shipment_itemDto entity)
        {
            try
            {
                var result = await _context.tbl_shipment_items
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.idtbl_shipment_item == entity.idtbl_shipment_item);
                if (result != null)
                {
                    if (entity.tbl_shipment_id.HasValue || (entity.ShipmentCode != "" && entity.ShipmentCode != null))
                    {
                        var shipment = await _context.tbl_shipments
                        .FirstOrDefaultAsync(x => x.idtbl_shipment == entity.tbl_shipment_id || x.tbl_shipment_code == entity.ShipmentCode);

                        if (shipment != null)
                        {
                            result.tbl_shipment_id = shipment.idtbl_shipment;
                            result.ShipmentCode = shipment.tbl_shipment_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link. Invalid shipment id or code.",
                                IsSuccess = false
                            };
                        }
                    }


                    _context.tbl_shipment_items.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Shipment does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Shipment successfully updated.",
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

        public async Task<List<tbl_shipment_itemDto>> CreateRangeAsync(List<tbl_shipment_itemDto> entities)
        {
            var result = _mapper.Map<List<tbl_shipment_itemDto>, List<tbl_shipment_item>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_shipment_items.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_shipment_item>, List<tbl_shipment_itemDto>>(result);
        }

        /// <summary>
        /// Deletes existing Parcel Item record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
               var result = await _context.tbl_shipment_items.FirstOrDefaultAsync(x => x.idtbl_shipment_item == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_shipment_items.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetShipment(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_shipment_items.Where(x => x.ShipmentCode == referenceNumber).ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_shipment_item>>(result)
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

        public Task<IEnumerable<tbl_shipment_itemDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_shipment_itemDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_shipment_itemDto>> GetAllAsyncWithChildren(searchFilter<tbl_shipment_itemDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
