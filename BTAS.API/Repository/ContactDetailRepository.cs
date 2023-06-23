using AutoMapper;
using Azure.Core;
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
    public class ContactDetailRepository : IRepository<tbl_client_contact_detailDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;
        public ContactDetailRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }

        /// <summary>
        /// Retrieves all Contact Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_client_contact_detailDto>> GetAllAsync()
        {
            var _list = await _context.tbl_client_contact_details.ToListAsync();
            return _mapper.Map<List<tbl_client_contact_detailDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single Contact Details based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_client_contact_detailDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_client_contact_details.FirstOrDefaultAsync(x => x.idtbl_client_contact_detail == id);
            return _mapper.Map<tbl_client_contact_detailDto>(result);

        }

        /// <summary>
        /// Creates/updates a Contact Details record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_client_contact_detailDto> CreateUpdateAsync(tbl_client_contact_detailDto entity)
        {
            try
            {
                var mapped = _mapper.Map<tbl_client_contact_detailDto, tbl_client_contact_detail>(entity);


                _context.tbl_client_contact_details.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_client_contact_detailDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a Contact Details record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_client_contact_detailDto entity)
        {
            try
            {
                entity.tbl_client_contact_detail_isActive = true;
                //Edited by HS on 01/02/2023
                var result = _mapper.Map<tbl_client_contact_detailDto, tbl_client_contact_detail>(entity);
                result.tbl_client_contact_details_code = await GetNextId();
     
                if (result.idtbl_client_contact_detail > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate Contact Details record",
                        IsSuccess = false
                    };
                }
                else
                // Edited by HS on 25/01/2023 to auto connect client_header to client_contact details
                {
                    if (!String.IsNullOrEmpty(result.ClientHeaderCode))
                    {
                        var parent = await _context.tbl_client_headers
                            .FirstOrDefaultAsync(x => x.tbl_client_header_code == result.ClientHeaderCode);
                        if (parent != null)
                        {
                            result.tbl_client_header_id = parent.idtbl_client_header;
                            //result.tbl_client_header_code = cheader.tbl_client_header_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to Client Header. Provided Contact Detail reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.AddressCode))
                    {
                        var parent = await _context.tbl_addresses
                            .FirstOrDefaultAsync(p => p.tbl_address_code == result.AddressCode);
                        if(parent != null)
                        {
                            result.tbl_address_id = parent.idtbl_address;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to Address. Provided Contact Detail reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    await _context.tbl_client_contact_details.AddAsync(result);
                    await _context.SaveChangesAsync();
                }

                return new ResponseDto
                {
                    //Edited by HS on 01/02/2023
                    //Result = _mapper.Map<tbl_client_contact_detailDto>(result),
                    Result = entity,
                    Id = entity.idtbl_client_contact_detail,
                    ReferenceNumber = entity.tbl_client_contact_detail_code,
                    DisplayMessage = "Contact Detail successfully added.",
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
        /// Updates a Contact Details record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_client_contact_detailDto entity)
        {
            try
            {
                var result = await _context.tbl_client_contact_details.AsNoTracking()
                    .SingleOrDefaultAsync(x => x.idtbl_client_contact_detail == entity.idtbl_client_contact_detail 
                    || x.tbl_client_header_id == entity.tbl_client_header_id);

                if (result != null)
                {
                    _mapper.Map(entity, result);

                    if (!String.IsNullOrEmpty(entity.ClientHeaderCode))
                    {
                        var parent = await _context.tbl_client_headers.AsNoTracking()
                            .SingleOrDefaultAsync(x => x.tbl_client_header_code == entity.ClientHeaderCode);
                        if (parent != null)
                        {
                            result.tbl_client_header_id = parent.idtbl_client_header;
                            //result.tbl_client_header_code = cheader.tbl_client_header_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to Client Header. Provided Contact Detail reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    if (!String.IsNullOrEmpty(entity.AddressCode))
                    {
                        var parent = await _context.tbl_addresses.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_address_code == entity.AddressCode);
                        if (parent != null)
                        {
                            result.tbl_address_id = parent.idtbl_address;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to Address. Provided Contact Detail reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    _context.ChangeTracker.Clear();
                    _context.tbl_client_contact_details.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Contact Details does not exists.",
                        IsSuccess = false
                    };
                };

                return new ResponseDto
                {
                    DisplayMessage = "Contact Details successfully updated.",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    DisplayMessage = ex.StackTrace.ToString(),
                    IsSuccess = false
                };
            }

        }

        public async Task<List<tbl_client_contact_detailDto>> CreateRangeAsync(List<tbl_client_contact_detailDto> entities)
        {
            var result = _mapper.Map<List<tbl_client_contact_detail>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_client_contact_details.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_client_contact_detailDto>>(result);
        }

        /// <summary>
        /// Deletes existing Contact Details record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _context.tbl_client_contact_details.FirstOrDefaultAsync(x => x.idtbl_client_contact_detail == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_client_contact_details.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> GetNextId()
        {
            
            var result = await _context.tbl_client_contact_details.OrderByDescending(x => x.idtbl_client_contact_detail).FirstOrDefaultAsync();

            string referenceCode = "CD" + String.Format("{0:0000000}", (result != null ? result.idtbl_client_contact_detail + count : 1));
            count++;
            return referenceCode;
        }

        public Task<IEnumerable<tbl_client_contact_detailDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_client_contact_detailDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_client_contact_detailDto>> GetAllAsyncWithChildren(searchFilter<tbl_client_contact_detailDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
