using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [ApiController]
    [Area("Maintenance")]
    [Route("api/addressbook")]
    //Added by HS on 14/12/2022
    [Route("api/clientheader")]
    public class ClientHeaderController : GenericController<tbl_client_headerDto>
    {
        //readonly IConfiguration _configuration;
        private ClientHeaderRepository _repository;
        private readonly IAuthenticationRepository _authRepo;

        public ClientHeaderController(ClientHeaderRepository repository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _authRepo = authRepo;
            //_configuration = configuration;
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] tbl_client_headerDto request, int isWeb = 0)
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
                    //Comment out by HS on 22/03/2023, move generate CH code into repository
                    //string referenceNumber = await _repository.GetNextId(Request.Headers["shipperId"]);
                    //request.tbl_client_header_code = referenceNumber;

                    result = await _repository.CreateAsync(request, Request.Headers["shipperId"]);

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
                            //Edited by HS on 07/02/2023
                            //var jsonString = JsonConvert.SerializeObject(result.Result);
                            //var model = JsonConvert.DeserializeObject<tbl_client_headerDto>(jsonString);

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
                }
                catch (Exception ex)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        response = 500,
                        responseDescription = "Check your request parameters",
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
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_client_headerDto request)
        {
            ResponseDto result = new();
            try
            {
                if (request.idtbl_client_header > 0 || (request.tbl_client_header_code != "" && request.tbl_client_header_code != null))
                {
                    result = await _repository.UpdateAsync(request);

                    if (result.IsSuccess)
                    {
                        var response = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        });
                        return Ok(new GeneralResponse
                        {
                            success = true,
                            response = 200,
                            responseDescription = "Address # " + request.tbl_client_header_code + " successfully updated."
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
                    responseDescription = "Missing/Invalid address id or number."
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
        public async Task<IActionResult> GetByReferenceAsync(string reference, string field)
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
                    if (field == "code")
                    {
                        result = await _repository.GetByReference(reference);
                    }
                    else
                    {
                        result = await _repository.GetByName(reference);
                    }


                    return Ok(result);
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