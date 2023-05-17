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
    public class AddressRepository : IRepository<tbl_addressDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private ClientHeaderRepository _clientHeaderRepository;
        private ContactDetailRepository _contactDetailsRepository;
        public AddressRepository(MainDbContext context, IMapper mapper, ClientHeaderRepository clientHeaderRepository, ContactDetailRepository contactDetailsRepository)
        {
            _context = context;
            _mapper = mapper;
            _clientHeaderRepository = clientHeaderRepository;
            _contactDetailsRepository = contactDetailsRepository;
        }

        public async Task<ResponseDto> CreateAsync(tbl_addressDto entity, string shipperId)
        {
            try
            {

                tbl_address result = _mapper.Map<tbl_addressDto, tbl_address>(entity);
                //Duplication check
                var duplicateAddress = await _context.tbl_addresses.FirstOrDefaultAsync(
                    x => (x.tbl_address_address1 == result.tbl_address_address1 && x.tbl_address_postcode == result.tbl_address_postcode));
                if (duplicateAddress != null)
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        ReferenceNumber = duplicateAddress.tbl_address_postcode,
                        DisplayMessage = "Address existed, address code:" + duplicateAddress.tbl_address_postcode
                    };
                }

                string referenceNumber = await GetNextId();
                entity.tbl_address_code = referenceNumber;
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
        public Task<tbl_addressDto> UpdateAsync(tbl_addressDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<tbl_addressDto> CreateUpdateAsync(tbl_addressDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<tbl_addressDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<tbl_addressDto> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        public Task<tbl_addressDto> GetByReferenceAsync(string reference)
        {
            throw new System.NotImplementedException();
        }
        public Task<tbl_addressDto> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        public async Task<string> GetNextId()
        {
            tbl_address result = await _context.tbl_addresses.OrderByDescending(x => x.idtbl_address).FirstOrDefaultAsync();
            string referenceCode = "AD" + string.Format("{0:0000000000}", (result != null ? result.idtbl_address + 1 : 1));
            return referenceCode;
        }

        public Task<IEnumerable<tbl_addressDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_addressDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_addressDto>> GetAllAsyncWithChildren(searchFilter<tbl_addressDto> filter = null)
        {
            throw new NotImplementedException();
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
                    address.tbl_address_code = "AD" + string.Format("{0:0000000000}", (address.idtbl_address));
                    _context.tbl_addresses.Update(address);
                }
            }
            await _context.SaveChangesAsync();
            return new GeneralResponse { success = true };
        }
    }

}