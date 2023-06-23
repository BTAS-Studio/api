//Added by HS on 09/06/2023

using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [ApiController]
    [Area("Maintenance")]
    [Route("api/notecategory")]
    [Authorize]
    public class NoteCategoryController : GenericController<tbl_note_categoryDto>
    {
        private NoteCategoryRepository _repository;
        private readonly IAuthenticationRepository _authRepo;

        public NoteCategoryController(NoteCategoryRepository repository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _authRepo = authRepo;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] tbl_note_categoryDto request)
        {
            ResponseDto result = new();
            try
            {
                string referenceNumber = await _repository.GetNextId();
                request.tbl_note_category_code = referenceNumber;

                result = await _repository.CreateAsync(request);

                if (result.IsSuccess)
                {
                    return Ok(new GeneralResponse
                    {
                        success = true,
                        response = 200,
                        responseDescription = result.DisplayMessage,
                        referenceNumber = result.ReferenceNumber
                    });
                }

                return Ok(new GeneralResponse
                {
                    success = false,
                    response = 500,
                    responseDescription = result.DisplayMessage
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new GeneralResponse
                {
                    response = 500,
                    responseDescription = ex.Message.ToString(),
                    success = false
                });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_note_categoryDto request)
        {
            ResponseDto result = new();
            try
            {
                if (request.idtbl_note_category > 0 || !String.IsNullOrEmpty(request.tbl_note_category_code))
                {
                    result = await _repository.UpdateAsync(request);

                    if (result.IsSuccess)
                    {
                        return Ok(new GeneralResponse
                        {
                            success = true,
                            response = 200,
                            responseDescription = "NoteCategory # " + request.tbl_note_category_code + " successfully updated."
                        });
                    }

                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = result.DisplayMessage
                    });
                }

                return new JsonResult(new GeneralResponse
                {
                    success = false,
                    response = 500,
                    responseDescription = "Missing/Invalid MilestoneHeader id or code."
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new GeneralResponse
                {
                    response = 500,
                    responseDescription = ex.Message.ToString(),
                    success = false
                });
            }
        }

        [HttpGet]
        [Route("GetByReference")]
        public async Task<IActionResult> GetByReferenceAsync(string referenceNumber, bool includeChild = false)
        {
            ResponseDto result = new();
            try
            {

                result = await _repository.GetByReference(referenceNumber, includeChild);
                if (!result.IsSuccess)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = result.DisplayMessage
                    });
                }
                return Ok(new GeneralResponse
                {
                    success = true,
                    response = 200,
                    responseDescription = result.DisplayMessage,
                    result = result.Result
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new GeneralResponse
                {
                    response = 500,
                    responseDescription = ex.Message.ToString(),
                    success = false
                });
            }
        }
    }
}
