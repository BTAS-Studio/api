//Added by HS on 13/06/2023

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
    public class NoteRepository : IRepository<tbl_noteDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;

        public NoteRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }
        public async Task<ResponseDto> CreateAsync(tbl_noteDto entity)
        {
            try
            {
                entity.tbl_note_createdDate = DateTime.Now;
                entity.tbl_note_status = true;
                var result = _mapper.Map<tbl_noteDto, tbl_note>(entity);
                result.tbl_note_code = await GetNextId();

                if (result.idtbl_note > 0)
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Unable to create duplicate Note",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (!String.IsNullOrEmpty(result.NoteCategoryCode))
                    {
                        var parent = await _context.tbl_note_categories.AsNoTracking()
                            .FirstOrDefaultAsync(p => p.tbl_note_category_code == result.NoteCategoryCode);
                        if (parent != null)
                        {
                            result.tbl_note_category_id = parent.idtbl_note_category;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to Note Category. Provided Note reference was not found.", IsSuccess = false };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.MasterCode))
                    {
                        var parent = await _context.tbl_masters.AsNoTracking()
                            .FirstOrDefaultAsync(p => p.tbl_master_code == result.MasterCode);
                        if (parent != null)
                        {
                            result.tbl_master_id = parent.idtbl_master;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to Master. Provided Note reference was not found.", IsSuccess = false };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.HouseCode))
                    {
                        var parent = await _context.tbl_houses.AsNoTracking()
                            .FirstOrDefaultAsync(p => p.tbl_house_code == result.HouseCode);
                        if (parent != null)
                        {
                            result.tbl_house_id = parent.idtbl_house;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to House. Provided Note reference was not found.", IsSuccess = false };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.ShipmentCode))
                    {
                        var parent = await _context.tbl_shipments.AsNoTracking()
                            .FirstOrDefaultAsync(p => p.tbl_shipment_code == result.ShipmentCode);
                        if (parent != null)
                        {
                            result.tbl_shipment_id = parent.idtbl_shipment;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to Shipment. Provided Note reference was not found.", IsSuccess = false };
                        }
                    }
                    result.tbl_note_createdDate = DateTime.Now;
                    await _context.tbl_notes.AddAsync(result);
                    await _context.SaveChangesAsync();
                }
                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_note_code,
                    DisplayMessage = "Note successfully added."
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


        public async Task<ResponseDto> UpdateAsync(tbl_noteDto entity)
        {
            try
            {
                var result = await _context.tbl_notes.AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_note_code == entity.tbl_note_code);

                if (result != null)
                {
                    //_mapper.Map<tbl_noteDto, tbl_note>(entity, result);
                    _mapper.Map(entity, result);

                    if (!String.IsNullOrEmpty(entity.NoteCategoryCode))
                    {
                        var parent = await _context.tbl_note_categories.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_note_category_code == entity.NoteCategoryCode);
                        if (parent != null)
                        {
                            result.tbl_note_category_id = parent.idtbl_note_category;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to Note Category. Provided Note Category reference was not found.", IsSuccess = false };
                        }
                    }
                    if (!String.IsNullOrEmpty(entity.MasterCode))
                    {
                        var parent = await _context.tbl_masters.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_master_code == entity.MasterCode);
                        if (parent != null)
                        {
                            result.tbl_master_id = parent.idtbl_master;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to Master. Provided Master reference was not found.", IsSuccess = false };
                        }
                    }
                    if (!String.IsNullOrEmpty(entity.HouseCode))
                    {
                        var parent = await _context.tbl_houses.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_house_code == entity.HouseCode);
                        if (parent != null)
                        {
                            result.tbl_house_id = parent.idtbl_house;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to House. Provided House reference was not found.", IsSuccess = false };
                        }
                    }
                    if (!String.IsNullOrEmpty(entity.ShipmentCode))
                    {
                        var parent = await _context.tbl_shipments.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_shipment_code == entity.ShipmentCode);
                        if (parent != null)
                        {
                            result.tbl_shipment_id = parent.idtbl_shipment;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to Shipment. Provided Shipment reference was not found.", IsSuccess = false };
                        }
                    }

                    _context.ChangeTracker.Clear();
                    _context.tbl_notes.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Note does not exist.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    DisplayMessage = "Note successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_note_code
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

        public async Task<IEnumerable<tbl_noteDto>> GetAllAsync()
        {
            IEnumerable<tbl_note> _list = await _context.tbl_notes.OrderByDescending(p => p.idtbl_note).ToListAsync();
            return _mapper.Map<List<tbl_noteDto>>(_list);
        }

        public async Task<IEnumerable<tbl_noteDto>> GetAllAsyncWithChildren()
        {
            IEnumerable<tbl_note> _list = await _context.tbl_notes
                .OrderByDescending(p => p.idtbl_note)
                .Include(p => p.documents)
                .ToListAsync();
            return _mapper.Map<List<tbl_noteDto>>(_list);
        }

        public async Task<tbl_noteDto> GetByIdAsync(int id)
        {
            var result = await _context.tbl_notes.FirstOrDefaultAsync(x => x.idtbl_note == id);
            return _mapper.Map<tbl_noteDto>(result);
        }

        public async Task<ResponseDto> GetByReference(string referenceNumber)
        {
            try
            {
                tbl_note result = new();

                result = await _context.tbl_notes.FirstOrDefaultAsync(v => v.tbl_note_code == referenceNumber);

                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = _mapper.Map<tbl_noteDto>(result),
                    ReferenceNumber = result.tbl_note_code,
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

        public async Task<tbl_noteDto> CreateUpdateAsync(tbl_noteDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetNextId()
        {
            var result = await _context.tbl_notes.OrderByDescending(p => p.idtbl_note).FirstOrDefaultAsync();
            string code = "NT" + String.Format("{0:0000000}", (result != null ? result.idtbl_note + count : 1));
            return code;
        }
    }
}