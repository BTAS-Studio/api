using Microsoft.AspNetCore.Mvc;
using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [ApiController]
    [Area("Maintenance")]
    [Route("api/address")]
    [Authorize]
    public class AddressController : GenericController<tbl_addressDto>
    {
        private AddressRepository _repository;
        public AddressController(AddressRepository repository) : base(repository)
        {
            _repository = repository;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] tbl_addressDto request)
        {
            try
            {
                if (request == null)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 400,
                        responseDescription = "Failed to create Address. Request is null."
                    });
                }
                if (request.idtbl_address > 0)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 400,
                        responseDescription = "Failed to create Address. Id is not allowed."
                    });
                }
                try
                {
                    var result = await _repository.CreateAsync(request);
                    if (result.IsSuccess == false)
                    {
                        return new JsonResult(new GeneralResponse
                        {
                            success = false,
                            response = 502,
                            responseDescription = result.DisplayMessage
                        });
                    }
                    return Ok(new GeneralResponse
                    {
                        success = true,
                        response = 200,
                        referenceNumber = result.ReferenceNumber,
                        responseDescription = result.DisplayMessage
                    });

                }
                catch (Exception ex)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = ex.Message.ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new GeneralResponse
                {
                    success = false,
                    response = 400,
                    responseDescription = ex.Message.ToString()
                });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_addressDto request)
        {
            ResponseDto result = new();
            try
            {
                if (request.idtbl_address > 0 || !String.IsNullOrEmpty(request.tbl_address_code))
                {
                    result = await _repository.UpdateAsync(request);

                    if (result.IsSuccess)
                    {
                        return Ok(new GeneralResponse
                        {
                            success = true,
                            response = 200,
                            responseDescription = "Address # " + request.tbl_address_code + " successfully updated."
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
                    response = 400,
                    responseDescription = "Missing/Invalid Address id or code."
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


        //Added by HS on 22/03/2023
        //This function is used for generating address code when address data is imported in bunch
        [HttpPut]
        [Route("makecode")]
        public async Task<IActionResult> MakeCodeAsync()
        {
            var result = await _repository.MakeCode();
            return Ok(new GeneralResponse
            {
                success = true
            });
        }
    }
}