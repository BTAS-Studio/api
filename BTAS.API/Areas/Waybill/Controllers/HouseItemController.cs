using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Waybill.Controllers
{
    [ApiController]
    [Area("Waybill")]
    [Route("api/houseitem")]
    [Authorize]
    public class HouseItemController : GenericController<tbl_house_itemDto>
    {
        private HouseItemRepository _repository;
        private readonly IAuthenticationRepository _authRepo;

        public HouseItemController(HouseItemRepository repository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _authRepo = authRepo;
        }

        [HttpGet("getfiltered")]
        public async Task<IActionResult> GetFiltered([FromBody] CustomFilters<tbl_house_itemDto> customFilters)
        {
            try
            {
                var response = await _repository.GetFilteredAsync(customFilters);
                if (response != null)
                {
                    return Ok(new GeneralResponse
                    {
                        success = true,
                        responseDescription = response.ToArray().Length.ToString(),
                        result = response
                    });
                }
                else
                {
                    return new JsonResult(new GeneralResponse
                    {
                        response = 500,
                        responseDescription = "No matching result",
                        success = false
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetByReference")]
        public async Task<IActionResult> GetByReferenceAsync(string referenceNumber)
        {
            try
            {
                ResponseDto result = new();
                var response = await _repository.GetByReference(referenceNumber);

                return Ok(new GeneralResponse
                {
                    success = response.IsSuccess,
                    referenceNumber = response.ReferenceNumber,
                    responseDescription = response.DisplayMessage,
                    result = response.Result
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

        [HttpPost]
        [Route("postrange")]
        public async Task<object> PostAsync([FromBody] List<tbl_house_itemDto> entities)
        {
            try
            {
                List<tbl_house_itemDto> postedEntity = await _repository.CreateRangeAsync(entities);

                _response.result = postedEntity;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.errorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] tbl_house_itemDto request)
        {
            try
            {
                ResponseDto result = new();

                try
                {
                    result = await _repository.CreateAsync(request);

                    if (result.IsSuccess)
                    {
                        return Ok(new GeneralResponse
                        {
                            success = true,
                            response = 200,
                            referenceNumber = result.ReferenceNumber,
                            responseDescription = result.DisplayMessage
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
            catch (Exception ex)
            {
                return new JsonResult(new GeneralResponse
                {
                    response = 300,
                    responseDescription = ex.Message.ToString(),
                    success = false
                });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_house_itemDto request)
        {
            try
            {
                ResponseDto result = new();

                try
                {
                    if (request.idtbl_house_item > 0)
                    {
                        result = await _repository.UpdateAsync(request);

                        if (result.IsSuccess)
                        {
                            return Ok(new GeneralResponse
                            {
                                success = true,
                                referenceNumber = result.ReferenceNumber,
                                responseDescription = result.DisplayMessage,
                                result = result.Result
                            });
                        }

                        return Ok(new GeneralResponse
                        {
                            success = false,
                            response = 500,
                            responseDescription = result.DisplayMessage
                        });
                    }

                    return new JsonResult(new GeneralResponse
                    {
                        response = 500,
                        responseDescription = "Unable to update parcel info record.",
                        success = false
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
            catch (Exception ex)
            {
                return new JsonResult(new GeneralResponse
                {
                    response = 300,
                    responseDescription = ex.Message.ToString(),
                    success = false
                });
            }
        }
    }
}
