using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class AddressRepository : IRepository<tbl_addressDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;

        public AddressRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }

        public async Task<ResponseDto> CreateAsync(tbl_addressDto entity)
        {
            try
            {
                tbl_address result = _mapper.Map<tbl_addressDto, tbl_address>(entity);

                string referenceNumber = await GetNextId();
                result.tbl_address_code = referenceNumber;
                await _context.tbl_addresses.AddAsync(result);
                await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_address_code,
                    DisplayMessage = "Address successfully added."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = ex.Message
                };
            }
        }
        public async Task<ResponseDto> UpdateAsync(tbl_addressDto entity)
        {
            try
            {
                var result = await _context.tbl_addresses
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_address_code == entity.tbl_address_code);

                if (result != null)
                {
                    _mapper.Map(entity, result);
                    _context.ChangeTracker.Clear();
                    _context.tbl_addresses.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Address does not exist.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    DisplayMessage = "Address successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_address_code
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

        public async Task<IEnumerable<tbl_addressDto>> GetAllAsync()
        {
            IEnumerable<tbl_address> _list = await _context.tbl_addresses.OrderByDescending(p => p.idtbl_address).ToListAsync();
            return _mapper.Map<List<tbl_addressDto>>(_list);
        }

        public async Task<IEnumerable<tbl_addressDto>> GetAllAsyncWithChildren()
        {
            IEnumerable<tbl_address> _list = await _context.tbl_addresses
                .OrderByDescending(p => p.idtbl_address)
                .Include(p => p.clientHeaders)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<tbl_addressDto>>(_list);
        }

        public async Task<tbl_addressDto> GetByIdAsync(int id)
        {
            var result = await _context.tbl_addresses.FirstOrDefaultAsync(x => x.idtbl_address == id);
            return _mapper.Map<tbl_addressDto>(result);
        }

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild)
        {
            try
            {
                tbl_address result = new();
                if (includeChild)
                {
                    result = await _context.tbl_addresses
                        //.Include(p => p.contactDetails)
                        .FirstOrDefaultAsync(v => v.tbl_address_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_addresses.FirstOrDefaultAsync(v => v.tbl_address_code == referenceNumber);
                }
                

                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = _mapper.Map<tbl_addressDto>(result),
                    ReferenceNumber = result.tbl_address_code,
                    DisplayMessage = "Success."
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

        public async Task<tbl_addressDto> CreateUpdateAsync(tbl_addressDto entity)
        {
            throw new NotImplementedException();
        }
        public Task<tbl_addressDto> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        public async Task<string> GetNextId()
        {
            tbl_address result = await _context.tbl_addresses.OrderByDescending(x => x.idtbl_address).FirstOrDefaultAsync();
            string referenceCode = "AD" + string.Format("{0:0000000}", (result != null ? result.idtbl_address + count : 1));
            return referenceCode;
        }


        //Added by HS on 22/03/2023
        //This function is used for generating address code when address data is imported in bunch
        public async Task<GeneralResponse> MakeCode()
        {
            var addressList = _context.tbl_addresses.ToList();
            foreach (var address in addressList)
            {
                if (address.tbl_address_code == null)
                {
                    address.tbl_address_code = "AD" + string.Format("{0:0000000}", (address.idtbl_address));
                    _context.tbl_addresses.Update(address);
                }
            }
            await _context.SaveChangesAsync();
            return new GeneralResponse { success = true };
        }
    }

}