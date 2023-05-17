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
    [Route("api/itemsku")]
    [Authorize]
    public class ItemSkuController : GenericController<tbl_item_skuDto>
    {
        private ItemSkuRepository _repository;
        private readonly IAuthenticationRepository _authRepo;

        public ItemSkuController(ItemSkuRepository repository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _authRepo = authRepo;
        }

        [HttpGet]
        [Route("getbycode")]
        public async Task<object> GetByCodeAsync(string code)
        {
            try
            {
                var response = await _repository.GetByCodeAsync(code);

                return Ok(response);
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
        public async Task<IActionResult> CreateAsync([FromBody] tbl_item_skuDto request)
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
                    result = await _repository.CreateAsync(request);
                    var response = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    });
                    return Ok(response);
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
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_item_skuDto request)
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
                    if (request.idtbl_item_sku > 0 || (request.tbl_item_sku_code != "" && request.tbl_item_sku_code != null))
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
                                responseDescription = "SKU # " + request.tbl_item_sku_code + " successfully updated."
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
                        responseDescription = "Missing/Invalid SKU id or code."
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
