using AutoMapper;
using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Models.Links;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Waybill.Controllers
{
    [ApiController]
    [Area("Waybill")]
    [Route("api/master")]
    //[Authorize]
    public class MasterController : GenericController<tbl_masterDto>
    {
        //readonly IConfiguration _configuration;
        private MasterRepository _repository;
        private VoyageRepository _voyageRepo;
        private ClientHeaderRepository _clientHeaderRepository;
        private readonly IAuthenticationRepository _authRepo;
        private IMapper _mapper;
        //private ILogger _logger;

        /// <summary>
        /// This is for the creation of MASTER
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="authRepo"></param>
        public MasterController(MasterRepository repository, VoyageRepository voyageRepo, ClientHeaderRepository clientHeaderRepository, IAuthenticationRepository authRepo, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _voyageRepo = voyageRepo;
            _clientHeaderRepository = clientHeaderRepository;
            _authRepo = authRepo;
            _mapper = mapper;
            //_logger = logger;
            //_configuration = configuration;
        }
        /*
        [HttpGet("getfiltered")]
        public async Task<IActionResult> GetFiltered([FromBody] searchFilter filter)
        {
            try
            {
                var response = await _repository.GetAllAsyncWithChildren(filter);
                
                return Ok(new ResponseDto { 
                    Result = response,
                    IsSuccess = true
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        */
        /// <summary>
        /// This method is used to make a dynamic filtering made by user providing column, condition and value to dynamically generate the filter parameters
        /// </summary>
        /// <param name="customFilter"></param>
        /// <returns></returns>
        [HttpGet("getfiltered")]
        public async Task<IActionResult> GetFiltered([FromBody] CustomFilters<tbl_masterDto> customFilters)
        {
            try
            {
                var response = await _repository.GetFilteredAsync(customFilters);
                if (response != null) {
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
                        success = false,
                        response = 404,
                        responseDescription = "No matching result"
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Create MASTER
        /// </summary>
        /// <param name="request">
        /// </param>
        /// <example>
        /// {
        ///"idtbl_master": 0,
        ///"tbl_master_masterBillNumber": "11111",
        ///"tbl_master_bookingNumber": "11111",
        ///"tbl_master_type": "AGT",
        ///"tbl_master_transportType": "AIR",
        ///"tbl_master_containerMode": "",
        ///"houses": [],
        ///"containers": []
        ///  }
        /// </example>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        //Editted by HS on 25/11/2022
        //public async Task<IActionResult> CreateAsync([FromBody] tbl_masterDto request, int isWeb = 0)
        public async Task<IActionResult> CreateAsync([FromBody] tbl_masterDto request)
        {
            if (request.idtbl_master > 0 || !String.IsNullOrEmpty(request.tbl_master_code))
            {
                return new JsonResult(new GeneralResponse
                {
                    success = false,
                    response = 500,
                    responseDescription = "Invalid request."
                });
            }
            //else
            //{
            //    if (await _repository.GetByReference(request.tbl_master_code) != null)
            //    {
            //        return new JsonResult(new GeneralResponse
            //        {
            //            success = false,
            //            response = 500,
            //            responseDescription = "Code already exists."
            //        });
            //    }
            //}

            try
            {
                ResponseDto result = new();

                //if (request.idtbl_master > 0 || request)

                try
                {

                    if ((request.originAgentCode == null || request.originAgentCode == "") && request.originAgent != null)
                    {
                        var address = await _clientHeaderRepository.CreateAsync(request.originAgent, Request.Headers["shipperId"]);
                        if (!address.IsSuccess)
                        {
                            return new JsonResult(new GeneralResponse
                            {
                                response = 500,
                                responseDescription = "There is a problem with your origin details. " + result.DisplayMessage,
                                success = false
                            });
                        }
                        request.originAgent = null;
                        request.tbl_client_header_origin_id = address.Id;
                        request.originAgentCode = address.ReferenceNumber;
                    }

                    if ((request.destinationAgentCode == null || request.destinationAgentCode == "") && request.destinationAgent != null)
                    {
                        var address = await _clientHeaderRepository.CreateAsync(request.destinationAgent, Request.Headers["shipperId"]);
                        if (!address.IsSuccess)
                        {
                            return new JsonResult(new GeneralResponse
                            {
                                response = 500,
                                responseDescription = "There is a problem with your destination details. " + result.DisplayMessage,
                                success = false
                            });
                        }
                        request.destinationAgent = null;
                        request.tbl_client_header_destination_id = address.Id;
                        request.destinationAgentCode = address.ReferenceNumber;
                    }

                    if ((request.carrierAgentCode == null || request.carrierAgentCode == "") && request.carrierAgent != null)
                    {
                        var address = await _clientHeaderRepository.CreateAsync(request.carrierAgent, Request.Headers["shipperId"]);
                        if (!address.IsSuccess)
                        {
                            return new JsonResult(new GeneralResponse
                            {
                                response = 500,
                                responseDescription = "There is a problem with your carrier details. " + result.DisplayMessage,
                                success = false
                            });
                        }
                        request.carrierAgent = null;
                        request.tbl_client_header_carrier_id = address.Id;
                        request.carrierAgentCode = address.ReferenceNumber;
                    }

                    if ((request.creditorAgentCode == null || request.creditorAgentCode == "") && request.creditorAgent != null)
                    {
                        var address = await _clientHeaderRepository.CreateAsync(request.creditorAgent, Request.Headers["shipperId"]);
                        if (!address.IsSuccess)
                        {
                            return new JsonResult(new GeneralResponse
                            {
                                response = 500,
                                responseDescription = "There is a problem with your creditor details. " + result.DisplayMessage,
                                success = false
                            });
                        }
                        request.creditorAgent = null;
                        request.tbl_client_header_creditor_id = address.Id;
                        request.creditorAgentCode = address.ReferenceNumber;
                    }

                    request.tbl_master_createdDate = DateTime.Now;

                    result = await _repository.CreateAsync(request, Request.Headers["shipperId"]);
                    if (!result.IsSuccess)
                    {
                        return new JsonResult(new GeneralResponse
                        {
                            response = 500,
                            responseDescription = result.DisplayMessage,
                            success = false
                        });
                    }

                    var jsonString = JsonConvert.SerializeObject(result.Result);
                    var model = JsonConvert.DeserializeObject<tbl_masterDto>(jsonString);
                    GeneralResponse response = new()
                    {
                        success = true,
                        response = 200,
                        responseDescription = "",
                        referenceNumber = model.tbl_master_code
                    };

                    return Ok(response);

                    //if (isWeb == 1)
                    //{
                    //    var response = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
                    //    {
                    //        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    //    });
                    //    return Ok(response);
                    //}
                    //else
                    //{
                    //    var jsonString = JsonConvert.SerializeObject(result.Result);
                    //    var model = JsonConvert.DeserializeObject<tbl_masterDto>(jsonString);
                    //    GeneralResponse response = new()
                    //    {
                    //        success = true,
                    //        response = 200,
                    //        responseDescription = model.tbl_master_code
                    //    };

                    //    return Ok(response);
                    //}
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

        /// <summary>
        /// Update an existing master record
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isWeb"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_masterDto request, int isWeb = 0)
        {
            if (request.idtbl_master <= 0 && String.IsNullOrEmpty(request.tbl_master_code))
            {
                return new JsonResult(new GeneralResponse
                {
                    success = false,
                    response = 500,
                    responseDescription = "Missing/Invalid master id or code."
                });
            }
            else
            {
                if (await _repository.GetByReference(request.tbl_master_code) == null)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = "Code does not exists."
                    });
                }
            }

            try
            {
                ResponseDto result = new();

                try
                {
                    if ((request.originAgentCode == null || request.originAgentCode == "") && request.originAgent != null)
                    {
                        var address = await _clientHeaderRepository.CreateAsync(request.originAgent, Request.Headers["shipperId"]);
                        if (!address.IsSuccess)
                        {
                            return new JsonResult(new GeneralResponse
                            {
                                response = 500,
                                responseDescription = "There is a problem with your origin details. " + result.DisplayMessage,
                                success = false
                            });
                        }
                        request.originAgent = null;
                        request.tbl_client_header_origin_id = address.Id;
                        request.originAgentCode = address.ReferenceNumber;
                    }

                    if ((request.destinationAgentCode == null || request.destinationAgentCode == "") && request.destinationAgent != null)
                    {
                        var address = await _clientHeaderRepository.CreateAsync(request.destinationAgent, Request.Headers["shipperId"]);
                        if (!address.IsSuccess)
                        {
                            return new JsonResult(new GeneralResponse
                            {
                                response = 500,
                                responseDescription = "There is a problem with your destination details. " + result.DisplayMessage,
                                success = false
                            });
                        }
                        request.destinationAgent = null;
                        request.tbl_client_header_destination_id = address.Id;
                        request.destinationAgentCode = address.ReferenceNumber;
                    }

                    if ((request.carrierAgentCode == null || request.carrierAgentCode == "") && request.carrierAgent != null)
                    {
                        var address = await _clientHeaderRepository.CreateAsync(request.carrierAgent, Request.Headers["shipperId"]);
                        if (!address.IsSuccess)
                        {
                            return new JsonResult(new GeneralResponse
                            {
                                response = 500,
                                responseDescription = "There is a problem with your carrier details. " + result.DisplayMessage,
                                success = false
                            });
                        }
                        request.carrierAgent = null;
                        request.tbl_client_header_carrier_id = address.Id;
                        request.carrierAgentCode = address.ReferenceNumber;
                    }

                    if ((request.creditorAgentCode == null || request.creditorAgentCode == "") && request.creditorAgent != null)
                    {
                        var address = await _clientHeaderRepository.CreateAsync(request.creditorAgent, Request.Headers["shipperId"]);
                        if (!address.IsSuccess)
                        {
                            return new JsonResult(new GeneralResponse
                            {
                                response = 500,
                                responseDescription = "There is a problem with your creditor details. " + result.DisplayMessage,
                                success = false
                            });
                        }
                        request.creditorAgent = null;
                        request.tbl_client_header_creditor_id = address.Id;
                        request.creditorAgentCode = address.ReferenceNumber;
                    }

                    if (request.tbl_master_code != "" && request.tbl_master_code != null)
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
                                responseDescription = "MASTER #" + request.tbl_master_code + " successfully updated."
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
                        responseDescription = "Missing/Invalid MASTER id or number."
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

        /// <summary>
        /// Link a master record to an existing voyage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("LinkToVoyage")]
        public async Task<IActionResult> LinkToVoyageAsync([FromBody] LinkToVoyageRequest request)
        {
            try
            {
                if (request.voyage != null)
                {
                    var voyage = await _voyageRepo.CreateAsync(request.voyage, Request.Headers["shipperId"]);
                    if (voyage.IsSuccess)
                    {
                        request.parentReference = voyage.ReferenceNumber;
                    }
                }
                var response = await _repository.LinkToVoyageAsync(request);
                if (response.IsSuccess)
                {
                    if (response.DisplayMessage == "failed")
                    {
                        response.DisplayMessage = "Failed updating record.";
                    }
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// This method is used to search for a specific reference number, either master code or bill number, 
        /// with an additional parameter of includeChild to include or not to include children record (default)
        /// </summary>
        /// <param name="referenceNumber"></param>
        /// <param name="includeChild"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getbyreference")]
        public async Task<IActionResult> GetByReferenceAsync(string referenceNumber, bool includeChild = false)
        {
            try
            {
                try
                {
                    var response = await _repository.GetByReference(referenceNumber, includeChild);

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

        [HttpGet]
        [Route("getbyvoyage")]
        public async Task<IActionResult> GetByVoyageAsync(string referenceNumber)
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
                    var response = await _repository.GetByVoyage(referenceNumber);

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
