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
    public class MilestoneLinkRepository : IRepository<tbl_milestone_linkDto>
    {
        private readonly MainDbContext _context;
        private readonly IMapper _mapper;
        private int count;

        public MilestoneLinkRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }
        public async Task<ResponseDto> CreateAsync(tbl_milestone_linkDto entity)
        {
            try
            {
                entity.tbl_milestone_link_createdDate = DateTime.Now;
                var result = _mapper.Map<tbl_milestone_linkDto, tbl_milestone_link>(entity);
                result.tbl_milestone_link_code = await GetNextId();

                if (result.idtbl_milestone_link > 0)
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Unable to create duplicate milestone link",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (!String.IsNullOrEmpty(result.MilestoneHeaderCode))
                    {
                        var parent = await _context.tbl_milestone_headers.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_milestone_header_code == result.MilestoneHeaderCode);
                        if (parent != null)
                        {
                            result.tbl_milestone_header_id = parent.idtbl_milestone_header;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to Milestone Header. Provided Milestone Link reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.MasterCode)) 
                    {
                        var parent = await _context.tbl_masters.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_master_code == result.MasterCode);
                        if (parent != null)
                        {
                            result.tbl_master_id = parent.idtbl_master;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to Master. Provided Milestone Link reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.HouseCode))
                    {
                        var parent = await _context.tbl_houses.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_house_code == result.HouseCode);
                        if (parent != null)
                        {
                            result.tbl_house_id = parent.idtbl_house;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to House. Provided Milestone Link reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    if (!String.IsNullOrEmpty(result.ShipmentCode))
                    {
                        var parent = await _context.tbl_shipments.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_shipment_code == result.ShipmentCode);
                        if (parent != null)
                        {
                            result.tbl_shipment_id = parent.idtbl_shipment;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to Shipment. Provided Milestone Link reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    result.tbl_milestone_link_createdDate = DateTime.Now;
                    await _context.tbl_milestone_links.AddAsync(result);
                    await _context.SaveChangesAsync();
                }
                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_milestone_link_code,
                    DisplayMessage = "MilestoneLink successfully added."
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


        public async Task<ResponseDto> UpdateAsync(tbl_milestone_linkDto entity)
        {
            try
            {
                var result = await _context.tbl_milestone_links
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_milestone_link_code == entity.tbl_milestone_link_code);

                if (result != null)
                {
                    //if (entity.tbl_milestone_link_value.Equals(DateTime.MinValue))
                    //{
                    //    entity.tbl_milestone_link_value = result.tbl_milestone_link_value;
                    //}
                    _mapper.Map(entity, result);
                    if (!String.IsNullOrEmpty(entity.MilestoneHeaderCode))
                    {
                        var parent = await _context.tbl_milestone_headers.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_milestone_header_code == entity.MilestoneHeaderCode);
                        if (parent != null)
                        {
                            result.tbl_milestone_header_id = parent.idtbl_milestone_header;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                //Result = entity,
                                DisplayMessage = "Unable to link to Milestone Header. Provided Milestone Header reference was not found.",
                                IsSuccess = false
                            };
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
                            return new ResponseDto
                            {
                                //Result = entity,
                                DisplayMessage = "Unable to link to Master. Provided Master reference was not found.",
                                IsSuccess = false
                            };
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
                            return new ResponseDto
                            {
                                //Result = entity,
                                DisplayMessage = "Unable to link to House. Provided House reference was not found.",
                                IsSuccess = false
                            };
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
                            return new ResponseDto
                            {
                                //Result = entity,
                                DisplayMessage = "Unable to link to Shipment. Provided Shipment reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    _context.ChangeTracker.Clear();
                    _context.tbl_milestone_links.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        //Result = entity,
                        DisplayMessage = "MilestoneLink does not exist.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    //Result = entity,
                    DisplayMessage = "MilestoneLink successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_milestone_link_code
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

        public async Task<IEnumerable<tbl_milestone_linkDto>> GetAllAsync()
        {
            IEnumerable<tbl_milestone_link> _list = await _context.tbl_milestone_links.OrderByDescending(p => p.idtbl_milestone_link).ToListAsync();
            return _mapper.Map<List<tbl_milestone_linkDto>>(_list);
        }

        public async Task<IEnumerable<tbl_milestone_linkDto>> GetAllAsyncWithChildren()
        {
            IEnumerable<tbl_milestone_link> _list = await _context.tbl_milestone_links.OrderByDescending(p => p.idtbl_milestone_link).ToListAsync();
            return _mapper.Map<List<tbl_milestone_linkDto>>(_list);
        }

        public async Task<tbl_milestone_linkDto> GetByIdAsync(int id)
        {
            var result = await _context.tbl_milestone_links.FirstOrDefaultAsync(x => x.idtbl_milestone_link == id);
            return _mapper.Map<tbl_milestone_linkDto>(result);
        }

        public async Task<ResponseDto> GetByReference(string referenceNumber)
        {
            try
            {
                tbl_milestone_link result = new();

                result = await _context.tbl_milestone_links.FirstOrDefaultAsync(v => v.tbl_milestone_link_code == referenceNumber);

                return new ResponseDto
                {
                    IsSuccess = true,
                    Result = _mapper.Map<tbl_milestone_linkDto>(result),
                    ReferenceNumber = result.tbl_milestone_link_code,
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

        public async Task<tbl_milestone_linkDto> CreateUpdateAsync(tbl_milestone_linkDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetNextId()
        {
            var result = await _context.tbl_milestone_links.OrderByDescending(p => p.idtbl_milestone_link).FirstOrDefaultAsync();
            string code = "ML" + String.Format("{0:0000000}", (result != null ? result.idtbl_milestone_link + count : 1));
            //count++;
            return code;
        }
    }
}