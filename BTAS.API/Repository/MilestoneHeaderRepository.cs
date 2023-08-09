//Added by HS on 06/06/2023

using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Repository.Interface;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class MilestoneHeaderRepository : IRepository<tbl_milestone_headerDto>
    {
        private MainDbContext _context;
        private readonly IMapper _mapper;
        private MilestoneLinkRepository _milestoneLinkRepository;

        public MilestoneHeaderRepository(MainDbContext context, IMapper mapper, MilestoneLinkRepository milestoneLinkRepository) 
        { 
            _context = context;
            _mapper = mapper;
            _milestoneLinkRepository = milestoneLinkRepository;
        }

        public async Task<IEnumerable<tbl_milestone_headerDto>> GetAllAsync()
        {
            IEnumerable<tbl_milestone_header> _list = await _context.tbl_milestone_headers
                .OrderByDescending(p => p.idtbl_milestone_header).ToListAsync();
            return _mapper.Map<List<tbl_milestone_headerDto>>(_list);
        }

        public async Task<IEnumerable<tbl_milestone_headerDto>> GetAllAsyncWithChildren()
        {
            IEnumerable<tbl_milestone_header> _list = await _context.tbl_milestone_headers
                .OrderByDescending(p => p.idtbl_milestone_header)
                .Include(p => p.milestoneLinks)
                .ToListAsync();
            return _mapper.Map<List<tbl_milestone_headerDto>>(_list);
        }

        public async Task<tbl_milestone_headerDto> GetByIdAsync(int id)
        {
            var result = await _context.tbl_milestone_headers.FirstOrDefaultAsync(p => p.idtbl_milestone_header == id);
            return _mapper.Map<tbl_milestone_headerDto>(result);
        }

        public async Task<ResponseDto> GetByReference(string reference, bool includeChild = false)
        {
            try
            {
                tbl_milestone_header result = new();
                if (includeChild)
                {
                     result = await _context.tbl_milestone_headers.Include(p => p.milestoneLinks)
                    .FirstOrDefaultAsync(x => x.tbl_milestone_header_code == reference);
                }
                else
                {
                    result = await _context.tbl_milestone_headers.FirstOrDefaultAsync(x => x.tbl_milestone_header_code == reference);
                }

                if (result == null)
                {
                    return new ResponseDto 
                    {
                        IsSuccess = false,
                        DisplayMessage = "No match found."
                    };
                }
                var mapped = _mapper.Map<tbl_milestone_headerDto>(result);

                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = mapped,
                    ReferenceNumber = result.tbl_milestone_header_code
                };
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

        public async Task<ResponseDto> CreateAsync(tbl_milestone_headerDto entity)
        {
            try
            {
                entity.tbl_milestone_header_createdDate = DateTime.Now;
                var result = _mapper.Map<tbl_milestone_headerDto, tbl_milestone_header>(entity);
                result.tbl_milestone_header_code = await GetNextId();

                if (result.idtbl_milestone_header > 0)
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Unable to create duplicate milestone header",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (result.milestoneLinks != null)
                    {
                        foreach (var msl in result.milestoneLinks)
                        {
                            msl.tbl_milestone_link_code = await _milestoneLinkRepository.GetNextId();
                            msl.tbl_milestone_header_id = result.idtbl_milestone_header;
                            msl.MilestoneHeaderCode = result.tbl_milestone_header_code;
                        }
                    }
                    result.tbl_milestone_header_createdDate = DateTime.Now;
                    await _context.tbl_milestone_headers.AddAsync(result);
                    await _context.SaveChangesAsync();
                }
                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_milestone_header_code,
                    DisplayMessage = "Milestone Header successfully added."
                };
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
        public Task<tbl_milestone_headerDto> CreateUpdateAsync(tbl_milestone_headerDto entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto> UpdateAsync(tbl_milestone_headerDto entity)
        {
            try
            {
                var result = await _context.tbl_milestone_headers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.tbl_milestone_header_code == entity.tbl_milestone_header_code);
                if (result != null)
                {
                    _context.ChangeTracker.Clear();
                    _context.tbl_milestone_headers.Update(result);
                    await _context.SaveChangesAsync();

                    return new ResponseDto
                    {
                        IsSuccess = true,
                        DisplayMessage = "Milestone Header successfully updated.",
                        //Result = _mapper.Map<tbl_milestone_headerDto>(mapped)
                    };
                }
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = "Missing/Invalid code."
                };
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

        internal async Task<ResponseDto> GetByNameAsync(string headerName)
        {
            var result = await _context.tbl_milestone_headers.OrderBy(p => p.tbl_milestone_header_name)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.tbl_milestone_header_name == headerName);
            if (result == null)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = "No match Milestone Header found."
                };
            }
            return new ResponseDto
            {
                IsSuccess = true,
                Id = result.idtbl_milestone_header,
                ReferenceNumber = result.tbl_milestone_header_code,
                Result = result
            };
        }
        public async Task<string> GetNextId()
        {
            var result = await _context.tbl_milestone_headers.OrderByDescending(p => p.idtbl_milestone_header).FirstOrDefaultAsync();
            string code = "MH" + String.Format("{0:0000000}", (result != null ? result.idtbl_milestone_header + 1 : 1));
            return code;
        }


    }
}
