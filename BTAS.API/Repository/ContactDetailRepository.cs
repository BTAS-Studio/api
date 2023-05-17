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
                var result = _mapper.Map<tbl_client_contact_detailDto, tbl_client_contact_detail>(entity);
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
                    if (result.ClientHeaderCode != null && result.ClientHeaderCode != "")
                    {
                        var cheader = await _context.tbl_client_headers
                            .FirstOrDefaultAsync(x => x.tbl_client_header_code == result.ClientHeaderCode);
                        if (cheader != null)
                        {
                            result.tbl_client_header_id = cheader.idtbl_client_header;
                            //result.tbl_client_header_code = cheader.tbl_client_header_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link Client Header. Provided Client Header reference was not found.",
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
                    DisplayMessage = "Contact Details successfully added.",
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
                if (entity.idtbl_client_contact_detail > 0)
                {
                    var result = await _context.tbl_client_contact_details
                        .SingleOrDefaultAsync(x => x.idtbl_client_contact_detail == entity.idtbl_client_contact_detail && x.tbl_client_header_id==entity.tbl_client_header_id);
                    if (result != null)
                    {

                        _context.tbl_client_contact_details.Update(_mapper.Map(entity, result));
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return new ResponseDto
                        {
                            Result = entity,
                            DisplayMessage = "Contact Details does not exists.",
                            IsSuccess = false
                        };
                    }
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Contact Details does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Contact Details successfully updated.",
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

        public async Task<string> GetNextId(string shipperId)
        {
            
            var result = await _context.tbl_client_contact_details.OrderByDescending(x => x.idtbl_client_contact_detail).FirstOrDefaultAsync();

            string referenceCode = "CD" + shipperId + String.Format("{0:0000000000}", (result != null ? result.idtbl_client_contact_detail + count : 1));
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
