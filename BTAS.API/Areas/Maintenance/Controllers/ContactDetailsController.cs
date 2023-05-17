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
    [Route("api/contactdetails")]
    public class ContactDetailsController : GenericController<tbl_client_contact_detailDto>
    {
        //readonly IConfiguration _configuration;
        private ContactDetailRepository _repository;
        private readonly IAuthenticationRepository _authRepo;

        public ContactDetailsController(ContactDetailRepository repository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _authRepo = authRepo;
            //_configuration = configuration;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] tbl_client_contact_detailDto request)
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
                    //Edited by HS on 01/02/2023
                    string referenceNumber = await _repository.GetNextId(Request.Headers["shipperId"]);
                    request.tbl_client_contact_detail_code = referenceNumber;
                    result = await _repository.CreateAsync(request);
                    //var response = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
                    //{
                    //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    //});

                    //return Ok(response);
                    if (result.IsSuccess)
                    {
                        //Edited by HS on 07/02/2023
                        //var jsonString = JsonConvert.SerializeObject(result.Result);
                        //var model = JsonConvert.DeserializeObject<tbl_client_contact_detailsDto>(jsonString);

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
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_client_contact_detailDto request)
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
                    if (request.idtbl_client_contact_detail > 0)
                    {
                        result = await _repository.UpdateAsync(request);
                    }

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
    }
}
