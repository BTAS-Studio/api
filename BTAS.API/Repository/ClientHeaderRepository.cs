using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Extensions;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class ClientHeaderRepository : IRepository<tbl_client_headerDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private ContactDetailRepository _contactDetailsRepo;

        public ClientHeaderRepository(MainDbContext context, IMapper mapper, ContactDetailRepository contactDetailsRepo)
        {
            _context = context;
            _mapper = mapper;
            _contactDetailsRepo = contactDetailsRepo;
        }

        /// <summary>
        /// Retrieves all client header
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_client_headerDto>> GetAllAsync()
        {
            IEnumerable<tbl_client_header> _list = await _context.tbl_client_headers.AsNoTracking().ToListAsync();
            return _mapper.Map<List<tbl_client_headerDto>>(_list);
        }

        public async Task<PagedList<tbl_client_headerDto>> GetAllAsync(PagingParameters paging)
        {
            // var _list = await _context.tbl_client_headers.AsNoTracking()
            //.OrderBy(paging.OrderBy)
            //.ToListAsync();

            return PagedList<tbl_client_headerDto>
                .ToPagedList(await FindAll(), paging.PageNumber, paging.PageSize);

            //IEnumerable<tbl_client_header> _list = await _context.tbl_client_headers.AsNoTracking().ToListAsync();
            //return _mapper.Map<List<tbl_client_headerDto>>(_list);
        }



        public async Task<IQueryable<tbl_client_headerDto>> FindAll()
        {
            return _mapper.Map<IQueryable<tbl_client_headerDto>>(await _context.tbl_client_headers.AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Retrieves a single client header based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_client_headerDto> GetByIdAsync(int id)
        {

            tbl_client_header result = await _context.tbl_client_headers.AsNoTracking().FirstOrDefaultAsync(x => x.idtbl_client_header == id);
            return _mapper.Map<tbl_client_headerDto>(result);

        }

        /// <summary>
        /// Creates/updates a client header record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_client_headerDto> CreateUpdateAsync(tbl_client_headerDto entity)
        {
            try
            {
                tbl_client_header mapped = _mapper.Map<tbl_client_headerDto, tbl_client_header>(entity);


                _context.tbl_client_headers.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_client_header, tbl_client_headerDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a client header record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_client_headerDto entity, string shipperId)
        {
            try
            {
                tbl_client_header result = _mapper.Map<tbl_client_headerDto, tbl_client_header>(entity);
                //Added by HS on 22/03/2023
                result.tbl_client_header_code = await GetCHCode(result.tbl_client_header_companyName);

                if (result.idtbl_client_header > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate client header record",
                        IsSuccess = false
                    };
                }
                else
                {
                    //Added by HS on 01/02/2023
                    if (result.contactDetails != null)
                    {
                        foreach (var ctd in result.contactDetails)
                        {
                            ctd.tbl_client_contact_details_code = await _contactDetailsRepo.GetNextId(shipperId);
                            ctd.ClientHeaderCode = result.tbl_client_header_code;
                        }
                    }

                    await _context.tbl_client_headers.AddAsync(result);
                    await _context.SaveChangesAsync();
                }
                return new ResponseDto
                {
                    //Edited by HS on 07/02/2023
                    //Result = entity,
                    //Id = entity.idtbl_client_header,
                    ReferenceNumber = result.tbl_client_header_code,
                    DisplayMessage = "client header successfully added.",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
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
        /// Updates a client header record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_client_headerDto entity)
        {
            try
            {
                //var result = await _context.tbl_client_header
                //.FirstOrDefaultAsync(x => x.idtbl_client_header == entity.idtbl_client_header || x.tbl_client_header_code == entity.tbl_client_header_code);

                var mapped = _mapper.Map<tbl_client_header>(entity);

                var address = await _context.tbl_client_headers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.idtbl_client_header == mapped.idtbl_client_header || x.tbl_client_header_code == mapped.tbl_client_header_code);

                if (address != null)
                {
                    mapped.idtbl_client_header = address.idtbl_client_header;
                    mapped.tbl_client_header_code = address.tbl_client_header_code;

                    _context.tbl_client_headers.Update(mapped);
                    await _context.SaveChangesAsync();

                    return new ResponseDto
                    {
                        Result = _mapper.Map<tbl_client_headerDto>(mapped),
                        DisplayMessage = "Address successfully updated.",
                        IsSuccess = true
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Missing/Invalid address id or code.",
                    IsSuccess = false
                };

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.StackTrace.ToString(),
                    IsSuccess = false
                };
            }

        }

        public async Task<List<tbl_client_headerDto>> CreateRangeAsync(List<tbl_client_headerDto> entities)
        {
            List<tbl_client_header> result = _mapper.Map<List<tbl_client_headerDto>, List<tbl_client_header>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_client_headers.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_client_header>, List<tbl_client_headerDto>>(result);
        }

        /// <summary>
        /// Deletes existing client header record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_client_header result = await _context.tbl_client_headers.FirstOrDefaultAsync(x => x.idtbl_client_header == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_client_headers.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetByReference(string reference)
        {
            try
            {
                tbl_client_header result = new();

                result = await _context.tbl_client_headers
                    .FirstOrDefaultAsync(x => x.tbl_client_header_code == reference);

                var mapped = _mapper.Map<tbl_client_headerDto>(result);

                return new ResponseDto
                {
                    Result = mapped,
                    ReferenceNumber = result.tbl_client_header_code
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

        public async Task<ResponseDto> GetByName(string reference)
        {
            try
            {
                var result = await _context.tbl_client_headers
                    .Where(x => x.tbl_client_header_companyName.Contains(reference))
                    .ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_client_headerDto>>(result)
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
        //Edited by HS on 22/03/2023
        //public async Task<string> GetNextId(string shipperId)
        public async Task<string> GetNextId()
        {
            tbl_client_header result = await _context.tbl_client_headers.OrderByDescending(x => x.idtbl_client_header).FirstOrDefaultAsync();
            //Edited by HS on 22/03/2023
            //string referenceCode = "A" + shipperId + String.Format("{0:0000000000}", (result != null ? result.idtbl_client_header + 1 : 1));
            string referenceCode = "CH" + String.Format("{0:00000}", (result != null ? result.idtbl_client_header + 1 : 1));
            return referenceCode;
        }

        public Task<IEnumerable<tbl_client_headerDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_client_headerDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<tbl_client_headerDto>> GetAllAsyncWithChildren(searchFilter<tbl_client_headerDto> filter = null)
        {
            throw new NotImplementedException();
        }

        //Added by HS on 22/03/2023
        private async Task<string> GetCHCode(string companyName)
        {
            string code = "";
            //int stringLength = 0;
            bool codeExisted = true;
            try
            {
                string trimString = companyName.Trim().ToUpper();
                if (trimString == "THE")
                {
                    code = "THE";
                }
                trimString = StripStartTHE(trimString);
                //Remove special characters, keep only letters, numbers and whitespaces
                trimString = Regex.Replace(trimString, @"[^\w+( \w+)*$]", "");
                //oneWordString is used for duplication check.
                //Remove all whitespaces
                var oneWordString = Regex.Replace(trimString, @"\s+", "");
                //split into multiple word, and remove empty word alongside.
                string[] words = trimString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //One word case
                if (words.Length == 1)
                {
                    code = words[0].Length > 3 ? words[0].Substring(0, 3) : words[0];
                }
                //At least two words case
                else
                {
                    if (words[0].Length == 1)
                    {
                        //D CARGO => CARD  D CA => DCA
                        code = words[1].Length >= 3 ? (words[1].Substring(0, 3) + words[0]) : (words[0] + words[1]);
                    }
                    else if (words[0].Length == 2)
                    {
                        code = words[1].Length >= 4 ? (words[0] + words[1].Substring(0, 4)) : (words[0] + words[1]);
                    }
                    else if (words[0].Length == 3)
                    {
                        code = words[1].Length >= 3 ? (words[0].Substring(0, 3) + words[1].Substring(0, 3)) : (words[0].Substring(0, 3) + words[1]);
                    }
                    else if (words[0].Length == 4)
                    {
                        code = words[1].Length >= 3 ? (words[0].Substring(0, 3) + words[1].Substring(0, 3)) : (words[0].Substring(0, 4) + words[1]);
                    }
                    else if (words[0].Length >= 5)
                    {
                        if (words[1].Length >= 3)
                        {
                            code = words[0].Substring(0, 3) + words[1].Substring(0, 3);
                        }
                        else if (words[1].Length == 2)
                        {
                            code = words[0].Substring(0, 4) + words[1];
                        }
                        else //words[1] 1 character
                        {
                            code = words[0].Substring(0, 5) + words[1];
                        }
                    }
                    else
                    {
                        code = await GetNextId();
                        Console.WriteLine("Default case.");
                    }
                }

                //Duplication check
                codeExisted = await CodeExisted(code);
                var oneWordLength = oneWordString.Length;
                while (codeExisted && oneWordLength > 0)
                {
                    code += oneWordString.Last();
                    oneWordString = oneWordString.Remove(oneWordLength - 1);
                    oneWordLength--;
                    codeExisted = await CodeExisted(code);
                }
                if (codeExisted && oneWordLength == 0)
                {
                    code = await GetNextId();
                }
                Console.WriteLine($"Code:{code}");
                return code;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        //Added by HS on 22/03/2023
        private static string StripStartTHE(string inputString)
        {
            if (inputString.StartsWith("THE "))
            {
                inputString = inputString.Substring(4);
            }
            return inputString;
        }
        //Added by HS on 22/03/2023
        private async Task<bool> CodeExisted(string code)
        {
            var codeExisted = await _context.tbl_client_headers.FirstOrDefaultAsync(x => x.tbl_client_header_code == code);
            if (codeExisted == null)
                return false;
            return true;
        }

    }
}