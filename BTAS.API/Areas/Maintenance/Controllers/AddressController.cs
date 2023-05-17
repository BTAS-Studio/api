using Microsoft.AspNetCore.Mvc;
using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Models.Links;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [ApiController]
    [Area("Waybill")]
    [Route("api/address")]
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
                    var result = await _repository.CreateAsync(request, Request.Headers["shipperId"]);
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