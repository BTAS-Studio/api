//Added by HS on 09/06/2023

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
    public class NoteCategoryRepository : IRepository<tbl_note_categoryDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private NoteRepository _noteRepository;
        private int count;

        public NoteCategoryRepository(MainDbContext context, IMapper mapper, NoteRepository noteRepository)
        {
            _context = context;
            _mapper = mapper;
            _noteRepository = noteRepository;
            count = 1;
        }

        public async Task<ResponseDto> CreateAsync(tbl_note_categoryDto entity)
        {
            try
            {
                entity.tbl_note_category_status = true;
                var result = _mapper.Map<tbl_note_categoryDto, tbl_note_category>(entity);
                result.tbl_note_category_code = await GetNextId();

                if (result.idtbl_note_category > 0)
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Unable to create duplicate Note Category",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (result.notes != null)
                    {
                        foreach (var note in result.notes)
                        {
                            note.tbl_note_code = await _noteRepository.GetNextId();
                            note.tbl_note_category_id = result.idtbl_note_category;
                            note.NoteCategoryCode = result.tbl_note_category_code;
                        }
                    }
                    
                    await _context.tbl_note_categories.AddAsync(result);
                    await _context.SaveChangesAsync();
                }
                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_note_category_code,
                    DisplayMessage = "Note Category successfully added."
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
    

        public async Task<ResponseDto> GetByReference(string reference, bool includeChild)
        {
            try
            {
                tbl_note_category result = new();
                if (includeChild)
                {
                    result = await _context.tbl_note_categories.Include(p => p.notes)
                   .SingleOrDefaultAsync(x => x.tbl_note_category_code == reference);
                }
                else
                {
                    result = await _context.tbl_note_categories.SingleOrDefaultAsync(x => x.tbl_note_category_code == reference);
                }

                if (result == null)
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        DisplayMessage = "No match found."
                    };
                }
                var mapped = _mapper.Map<tbl_note_categoryDto>(result);

                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = mapped,
                    ReferenceNumber = result.tbl_note_category_code
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

        public async Task<ResponseDto> UpdateAsync(tbl_note_categoryDto entity)
        {
            try
            {
                var result = await _context.tbl_note_categories.AsNoTracking()
                    .SingleOrDefaultAsync(p => p.tbl_note_category_code == entity.tbl_note_category_code);
                if (result != null)
                {
                    _mapper.Map(entity, result);
                    _context.ChangeTracker.Clear();
                    _context.tbl_note_categories.Update(result);
                    await _context.SaveChangesAsync();

                    return new ResponseDto
                    {
                        IsSuccess = true,
                        DisplayMessage = "Note Category successfully updated.",
                        //Result = _mapper.Map<tbl_note_categoryDto>(mapped)
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

        public async Task<IEnumerable<tbl_note_categoryDto>> GetAllAsync()
        {
            IEnumerable<tbl_note_category> _list = await _context.tbl_note_categories
                .OrderByDescending(p => p.idtbl_note_category).ToListAsync();
            return _mapper.Map<List<tbl_note_categoryDto>>(_list);
        }

        public async Task<IEnumerable<tbl_note_categoryDto>> GetAllAsyncWithChildren()
        {
            IEnumerable<tbl_note_category> _list = await _context.tbl_note_categories
                .OrderByDescending(p => p.idtbl_note_category)
                .Include(p => p.notes)
                .ToListAsync();
            return _mapper.Map<List<tbl_note_categoryDto>>(_list);
        }

        public async Task<tbl_note_categoryDto> GetByIdAsync(int id)
        {
            var result = await _context.tbl_note_categories.FirstOrDefaultAsync(p => p.idtbl_note_category == id);
            return _mapper.Map<tbl_note_categoryDto>(result);
        }

        public Task<tbl_note_categoryDto> CreateUpdateAsync(tbl_note_categoryDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetNextId()
        {
            var result = await _context.tbl_note_categories.OrderByDescending(p => p.idtbl_note_category).FirstOrDefaultAsync();
            string code = "NC" + String.Format("{0:0000000}", (result != null ? result.idtbl_note_category + count : 1));
            return code;
        }
    }
}
