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
using System.Threading.Tasks;

namespace BTAS.API.Areas.Waybill.Controllers
{
    [ApiController]
    [Area("Waybill")]
    [Route("api/routing")]
    [Authorize]
    public class RoutingController : GenericController<tbl_routingDto>
    {
        private RoutingRepository _repository;
        private readonly IAuthenticationRepository _authRepo;

        public RoutingController(RoutingRepository repository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _authRepo = authRepo;
        }

        [HttpPost]
        [Route("postrange")]
        public async Task<object> PostAsync([FromBody] List<tbl_routingDto> entities)
        {
            try
            {
                List<tbl_routingDto> postedEntity = await _repository.CreateRangeAsync(entities);

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
        public async Task<IActionResult> CreateAsync([FromBody] tbl_routingDto request, int isWeb = 0)
        {
            try
            {
                ResponseDto result = new();

                //Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
                //foreach (var header in Request.Headers)
                //{
                //    requestHeaders.Add(header.Key, header.Value);
                //}

                //if (isWeb == 0)
                //{
                //    GeneralResponse apiResponse = JsonConvert.DeserializeObject<GeneralResponse>(await _authRepo.ValidateTokenAsync(requestHeaders["apikey"], requestHeaders["apiToken"], requestHeaders["shipperId"]));
                //    if (apiResponse.success == false)
                //    {
                //        return NotFound(apiResponse);
                //    }
                //}

                try
                {
                    result = await _repository.CreateAsync(request);

                    if (isWeb == 1)
                    {
                        var response = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        });
                        return Ok(response);
                    }
                    else
                    {
                        if (result.IsSuccess)
                        {
                            return Ok(new GeneralResponse
                            {
                                success = true,
                                response = 200,
                                responseDescription = "Routing successfully saved."
                            });
                        }

                        return Ok(new GeneralResponse
                        {
                            success = false,
                            response = 500,
                            responseDescription = result.DisplayMessage
                        });
                    }
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
                    response = 500,
                    responseDescription = ex.Message.ToString(),
                    success = false
                });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_routingDto request)
        {
            try
            {
                ResponseDto result = new();

                //Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
                //foreach (var header in Request.Headers)
                //{
                //    requestHeaders.Add(header.Key, header.Value);
                //}

                //GeneralResponse apiResponse = JsonConvert.DeserializeObject<GeneralResponse>(await _authRepo.ValidateTokenAsync(requestHeaders["apikey"], requestHeaders["apiToken"], requestHeaders["shipperId"]));
                //if (apiResponse.success == false)
                //{
                //    return NotFound(apiResponse);
                //}

                try
                {
                    if (request.idtbl_routing > 0)
                    {
                        result = await _repository.UpdateAsync(request);

                        if (result.IsSuccess)
                        {
                            //var response = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
                            //{
                            //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                            //});
                            return Ok(new GeneralResponse
                            {
                                success = true,
                                response = 200,
                                responseDescription = "Routing # " + request.idtbl_routing + " successfully updated."
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
                        responseDescription = "Missing/Invalid routing id or number."
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
