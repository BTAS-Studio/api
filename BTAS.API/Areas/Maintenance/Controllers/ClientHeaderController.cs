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

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [ApiController]
    [Area("Maintenance")]
    //*[Route("api/addressbook")]
    //Added by HS on 14/12/2022
    [Route("api/clientheader")]
    [Authorize]
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
        public async Task<IActionResult> CreateAsync([FromBody] tbl_client_headerDto request)
        {
            ResponseDto result = new();
            try
            {
                //Comment out by HS on 22/03/2023, move generate CH code into repository
                //string referenceNumber = await _repository.GetNextId(Request.Headers["shipperId"]);
                //request.tbl_client_header_code = referenceNumber;

                result = await _repository.CreateAsync(request);

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


        [HttpPost]
        [Route("AddAddress")]
        public async Task<IActionResult> AddAddressAsync(string clientHeaderCode, string addressCode)
        {
            ResponseDto result = new();
            try
            {
                result = await _repository.AddAddressAsync(clientHeaderCode, addressCode);

                if (result.IsSuccess)
                {
                    return Ok(new GeneralResponse
                    {
                        success = true,
                        response = 200,
                        responseDescription = result.DisplayMessage,
                    });
                }

                return Ok(new GeneralResponse
                {
                    success = false,
                    response = 500,
                    responseDescription = result.DisplayMessage
                });

            }
            catch
            {
                return new JsonResult(new GeneralResponse
                {
                    response = 500,
                    responseDescription = result.DisplayMessage,
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
        public async Task<IActionResult> GetByReferenceAsync(string referenceNumber, bool includeChild = false, string field = "code")
        {
            ResponseDto result = new();
            try
            {
                if (field == "code")
                {
                    result = await _repository.GetByReference(referenceNumber, includeChild);
                }
                else
                {
                    result = await _repository.GetByName(referenceNumber);
                }

                return Ok(new GeneralResponse
                {
                    success = true,
                    responseDescription = result.DisplayMessage,
                    response = 200,
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

        [HttpGet]
        [Route("getfiltered")]
        public async Task<IActionResult> GetFiltered([FromBody] CustomFilters<tbl_client_headerDto> customFilters)
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
        [Route("duplicationcheck")]
        internal async Task<IActionResult> DuplicationCheckAsync([FromBody] tbl_client_headerDto entity)
        {
            try
            {

                var response = await _repository.DuplicationCheck(entity);

                return Ok(new GeneralResponse
                {
                    success = response.IsSuccess,
                    responseDescription = response.DisplayMessage,
                    referenceNumber = response.ReferenceNumber
                });

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}