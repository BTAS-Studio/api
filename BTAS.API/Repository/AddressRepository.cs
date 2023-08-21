using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BTAS.API.Repository.SearchRepository;

namespace BTAS.API.Repository
{
    public class AddressRepository : SRepository, IRepository<tbl_addressDto>
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
                if (result.tbl_address_code ==  null)
                {
                    string referenceNumber = await GetNextId();
                    result.tbl_address_code = referenceNumber;
                }
                
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
                var result = await _context.tbl_addresses.OrderBy(p => p.idtbl_address)
                    .SingleOrDefaultAsync(x => x.idtbl_address == entity.idtbl_address);

                if (result == null)
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Address does not exist.",
                        IsSuccess = false
                    };
                }

                _mapper.Map(entity, result);
                _context.ChangeTracker.Clear();
                _context.tbl_addresses.Update(result);
                await _context.SaveChangesAsync();
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
            IEnumerable<tbl_address> _list = await _context.tbl_addresses.OrderByDescending(p => p.idtbl_address).AsNoTracking().ToListAsync();
            return _mapper.Map<List<tbl_addressDto>>(_list);
        }

        public async Task<IEnumerable<tbl_addressDto>> GetAllAsyncWithChildren()
        {
            IEnumerable<tbl_address> _list = await _context.tbl_addresses.OrderByDescending(p => p.idtbl_address)
                .AsNoTracking().Include(p => p.clientHeaders).ToListAsync();
            return _mapper.Map<List<tbl_addressDto>>(_list);
        }

        public async Task<tbl_addressDto> GetByIdAsync(int id)
        {
            var result = await _context.tbl_addresses.AsNoTracking().FirstOrDefaultAsync(x => x.idtbl_address == id);
            return _mapper.Map<tbl_addressDto>(result);
        }

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild)
        {
            try
            {
                tbl_address result = new();
                if (includeChild)
                {
                    result = await _context.tbl_addresses.AsNoTracking()
                        .Include(p => p.clientHeaders)
                        .FirstOrDefaultAsync(v => v.tbl_address_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_addresses.AsNoTracking()
                        .FirstOrDefaultAsync(v => v.tbl_address_code == referenceNumber);
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

        //Added by HS on 11/08/2023
        /// <summary>
        /// Retrieves a specified number of addresses according to input conditions(>, >=, <, <=, ==, !=, and contains)
        /// </summary>
        /// <returns> A list of address objects</returns>
        public async Task<IEnumerable<tbl_addressDto>> GetFilteredAsync(CustomFilters<tbl_addressDto> customFilters)
        {
            try
            {
                var qList = _context.tbl_addresses
                    //.AsNoTracking()
                    .OrderByDescending(h => h.tbl_address_postcode).AsQueryable();
                // excute each filter one by one 
                if (customFilters.Filters != null)
                {
                    foreach (var filter in customFilters.Filters)
                    {
                        PropertyInfo propertyInfo = null;
                        bool parent = false;
                        var jsonString = JsonConvert.SerializeObject(filter.searchField);
                        var jsonObj = JObject.Parse(jsonString);
                        JToken originalValue = null;

                        if (filter.tableName.ToUpper() == "ADDRESS")
                        {
                            //filter.tableName = "address";
                            bool containsDateTime = false;
                            //used for searching Contains DateTime type's columns
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeAddressJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) = GetPropertyInfo<tbl_addressDto, tbl_address>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid table name: {filter.tableName}");
                        }

                        Type elementType = qList.ElementType;

                        if (propertyInfo == null)
                        {
                            throw new ArgumentException($"Invalid property name: {propertyInfo.Name}");
                        }

                        Expression<Func<tbl_address, bool>> propertyLambda = null;
                        propertyLambda = GetPropertyLambda<tbl_address>(propertyInfo, filter, parent);

                        if (propertyLambda != null)
                        {
                            qList = qList.Where(propertyLambda);
                        }
                    }
                }

                if (qList.Count() == 0)
                {
                    return null;
                }
                var filtered = await qList.Skip(customFilters.Page * customFilters.PageSize).Take(customFilters.PageSize).ToListAsync();
                return _mapper.Map<IEnumerable<tbl_addressDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
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

        internal async Task<ResponseDto> DuplicationCheck(tbl_addressDto entity)
        {
            try
            {
                //unique constrain check
                if (String.IsNullOrEmpty(entity.tbl_address_companyName)
                    || String.IsNullOrEmpty(entity.tbl_address_postcode)
                    || String.IsNullOrEmpty(entity.tbl_address_address1))
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        DisplayMessage = "Missing mandatory fields."
                    };
                }
                var result = _mapper.Map<tbl_addressDto>(entity);
                //duplicate if a same company name with the same postcode and address1
                var duplicate = await _context.tbl_addresses.OrderBy(p => p.tbl_address_companyName)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(
                      p => (p.tbl_address_companyName == result.tbl_address_companyName
                      && p.tbl_address_postcode == result.tbl_address_postcode
                      && p.tbl_address_address1 == result.tbl_address_address1
                     ));
                if (duplicate == null)
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        DisplayMessage = "New Address",
                        ReferenceNumber = "1"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        IsSuccess = true,
                        DisplayMessage = "Duplicate Address",
                        ReferenceNumber = duplicate.tbl_address_code
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = ex.Message.ToString()
                };
            }
        }
        internal async Task<int> GetIdAsync(tbl_addressDto address)
        {
            try
            {
                var result = await _context.tbl_addresses.OrderBy(p => p.tbl_address_companyName)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(p => p.tbl_address_companyName == address.tbl_address_companyName
                    && p.tbl_address_postcode == address.tbl_address_postcode
                    && p.tbl_address_address1 == address.tbl_address_address1);
                return result.idtbl_address;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<string> GetNextId()
        {
            tbl_address result = await _context.tbl_addresses.OrderByDescending(x => x.idtbl_address).FirstOrDefaultAsync();
            string referenceCode = "AD" + string.Format("{0:0000000}", (result != null ? result.idtbl_address + count : 1));
            return referenceCode;
        }
    }

}