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
    public class DocumentRepository : IRepository<tbl_documentDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;

        public DocumentRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }
        public async Task<ResponseDto> CreateAsync(tbl_documentDto entity)
        {
            try
            {
                entity.tbl_document_createdDate = DateTime.Now;
                entity.tbl_document_status = true;
                var result = _mapper.Map<tbl_documentDto, tbl_document>(entity);
                result.tbl_document_code = await GetNextId();

                if (result.idtbl_document > 0)
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Unable to create duplicate note",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (!String.IsNullOrEmpty(result.NoteCode))
                    {
                        var parent = await _context.tbl_notes
                            .FirstOrDefaultAsync(p => p.tbl_note_code == result.NoteCode);
                        if (parent != null)
                        {
                            result.tbl_note_id = parent.idtbl_note;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to Note. Provided Document reference was not found.", IsSuccess = false };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.MasterCode))
                    {
                        var parent = await _context.tbl_masters
                            .FirstOrDefaultAsync(p => p.tbl_master_code == result.MasterCode);
                        if (parent != null)
                        {
                            result.tbl_master_id = parent.idtbl_master;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to Master. Provided Document reference was not found.", IsSuccess = false };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.HouseCode))
                    {
                        var parent = await _context.tbl_houses
                            .FirstOrDefaultAsync(p => p.tbl_house_code == result.HouseCode);
                        if (parent != null)
                        {
                            result.tbl_house_id = parent.idtbl_house;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to House. Provided Document reference was not found.", IsSuccess = false };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.ShipmentCode))
                    {
                        var parent = await _context.tbl_shipments
                            .FirstOrDefaultAsync(p => p.tbl_shipment_code == result.ShipmentCode);
                        if (parent != null)
                        {
                            result.tbl_shipment_id = parent.idtbl_shipment;
                        }
                        else
                        {
                            return new ResponseDto { Result = entity, DisplayMessage = "Unable to link to Shipment. Provided Document reference was not found.", IsSuccess = false };
                        }
                    }
                    result.tbl_document_createdDate = DateTime.Now;
                    await _context.tbl_documents.AddAsync(result);
                    await _context.SaveChangesAsync();
                }
                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_document_code,
                    DisplayMessage = "Document successfully added."
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


        public async Task<ResponseDto> UpdateAsync(tbl_documentDto entity)
        {
            try
            {
                var result = await _context.tbl_documents
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_document_code == entity.tbl_document_code);


                if (result != null)
                {
                    _mapper.Map(entity, result);

                    if (!String.IsNullOrEmpty(entity.NoteCode))
                    {
                        var parent = await _context.tbl_notes.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_note_code == entity.NoteCode);
                        if (parent != null)
                        {
                            result.tbl_note_id = parent.idtbl_note;
                        }
                        else
                        {
                            return new ResponseDto { DisplayMessage = "Unable to link to Note. Provided Note reference was not found.", IsSuccess = false };
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
                            return new ResponseDto { DisplayMessage = "Unable to link to Master. Provided Master reference was not found.", IsSuccess = false };
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
                            return new ResponseDto { DisplayMessage = "Unable to link to House. Provided House reference was not found.", IsSuccess = false };
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
                            return new ResponseDto { DisplayMessage = "Unable to link to Shipment. Provided Shipment reference was not found.", IsSuccess = false };
                        }
                    }
                    _context.ChangeTracker.Clear();
                    _context.tbl_documents.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Document does not exist.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    DisplayMessage = "Document successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_document_code
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

        public async Task<IEnumerable<tbl_documentDto>> GetAllAsync()
        {
            IEnumerable<tbl_document> _list = await _context.tbl_documents.OrderByDescending(p => p.idtbl_document).ToListAsync();
            return _mapper.Map<List<tbl_documentDto>>(_list);
        }

        public async Task<IEnumerable<tbl_documentDto>> GetAllAsyncWithChildren()
        {
            IEnumerable<tbl_document> _list = await _context.tbl_documents.OrderByDescending(p => p.idtbl_document).ToListAsync();
            return _mapper.Map<List<tbl_documentDto>>(_list);
        }

        public async Task<tbl_documentDto> GetByIdAsync(int id)
        {
            var result = await _context.tbl_documents.FirstOrDefaultAsync(x => x.idtbl_document == id);
            return _mapper.Map<tbl_documentDto>(result);
        }

        public async Task<ResponseDto> GetByReference(string referenceNumber)
        {
            try
            {
                tbl_document result = new();

                result = await _context.tbl_documents.FirstOrDefaultAsync(v => v.tbl_document_code == referenceNumber);

                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = _mapper.Map<tbl_documentDto>(result),
                    ReferenceNumber = result.tbl_document_code,
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

        public async Task<tbl_documentDto> CreateUpdateAsync(tbl_documentDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetNextId()
        {
            var result = await _context.tbl_documents.OrderByDescending(p => p.idtbl_document).FirstOrDefaultAsync();
            string code = "DC" + String.Format("{0:0000000}", (result != null ? result.idtbl_document + count : 1));
            return code;
        }
    }
}