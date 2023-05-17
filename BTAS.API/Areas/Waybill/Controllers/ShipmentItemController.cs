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
    [Route("api/shipmentitem")]
    [Authorize]
    public class ShipmentItemController : GenericController<tbl_shipment_itemDto>
    {
        private ShipmentItemRepository _repository;
        private readonly IAuthenticationRepository _authRepo;

        public ShipmentItemController(ShipmentItemRepository repository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _authRepo = authRepo;
        }

        [HttpPost]
        [Route("postrange")]
        public async Task<object> PostAsync([FromBody] List<tbl_shipment_itemDto> entities)
        {
            try
            {
                List<tbl_shipment_itemDto> postedEntity = await _repository.CreateRangeAsync(entities);

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
        public async Task<IActionResult> CreateAsync([FromBody] tbl_shipment_itemDto request, int isWeb = 0)
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
                            //Edited by HS on 06/03/2023
                            //var jsonString = JsonConvert.SerializeObject(result.Result, new JsonSerializerSettings { ContractResolver = CustomDataContractResolver.Instance });
                            //var model = JsonConvert.DeserializeObject<tbl_shipment_itemDto>(jsonString);

                            //return Ok(new ResponseDto
                            //{
                            //    IsSuccess = true,
                            //    Result = model,
                            //    DisplayMessage = result.DisplayMessage
                            //});
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
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_shipment_itemDto request, int isWeb = 0)
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
                    if (request.idtbl_shipment_item > 0)
                    {
                        result = await _repository.UpdateAsync(request);

                        if (isWeb == 1)
                        {
                            //var response = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
                            //{
                            //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                            //});
                            return Ok(new GeneralResponse
                            {
                                success = true,
                                response = 200,
                                responseDescription = "Parcel Item # " + request.idtbl_shipment_item + " successfully updated."
                            });
                        }
                        else
                        {
                            if (result.IsSuccess)
                            {
                                var jsonString = JsonConvert.SerializeObject(result.Result, new JsonSerializerSettings { ContractResolver = CustomDataContractResolver.Instance });
                                var model = JsonConvert.DeserializeObject<tbl_shipment_itemDto>(jsonString);

                                return Ok(new ResponseDto
                                {
                                    IsSuccess = true,
                                    Result = model,
                                    DisplayMessage = result.DisplayMessage
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

        //[HttpGet]
        //[Route("getbyparcelinfo")]
        //public async Task<IActionResult> GetByParcelInfoAsync(string referenceNumber)
        //{
        //    try
        //    {
        //        try
        //        {
        //            var response = await _repository.GetByParcelInfo(referenceNumber);

        //            return Ok(response);
        //        }
        //        catch (Exception ex)
        //        {
        //            return new JsonResult(new GeneralResponse
        //            {
        //                response = 500,
        //                responseDescription = ex.Message.ToString(),
        //                success = false
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(new GeneralResponse
        //        {
        //            response = 300,
        //            responseDescription = ex.Message.ToString(),
        //            success = false
        //        });
        //    }
        //}
    }
}
