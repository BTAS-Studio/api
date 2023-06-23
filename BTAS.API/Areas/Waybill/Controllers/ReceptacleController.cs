using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Models.Links;
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
    [Route("api/receptacle")]
    [Authorize]
    public class ReceptacleController : GenericController<tbl_receptacleDto>
    {
        private ReceptacleRepository _repository;
        private HouseRepository _houseRepository;
        private readonly IAuthenticationRepository _authRepo;

        public ReceptacleController(ReceptacleRepository repository, HouseRepository houseRepository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _houseRepository = houseRepository;
            _authRepo = authRepo;
        }

        [HttpGet("getfiltered")]
        public async Task<IActionResult> GetFiltered([FromBody] CustomFilters<tbl_receptacleDto> customFilters)
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
        public async Task<IActionResult> GetByReferenceAsync(string referenceNumber, bool includeChild = false)
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

        [HttpPost]
        [Route("PostRange")]
        public async Task<object> PostAsync([FromBody] List<tbl_receptacleDto> entities)
        {
            try
            {
                List<tbl_receptacleDto> postedEntity = await _repository.CreateRangeAsync(entities);

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
        public async Task<IActionResult> CreateAsync([FromBody] tbl_receptacleDto request, int isWeb = 0)
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
                            // Edited by HS on 06/03/2023
                            //var jsonString = JsonConvert.SerializeObject(result.Result);
                            //var model = JsonConvert.DeserializeObject<tbl_receptacleDto>(jsonString);

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
        [Route("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_receptacleDto request, int isWeb = 0)
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
                    if (request.tbl_receptacle_code != "" && request.tbl_receptacle_code != null)
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
                                responseDescription = "Receptacle # " + request.tbl_receptacle_code + " successfully updated.",
                                referenceNumber = request.tbl_receptacle_code
                            });
                        }

                        return new JsonResult(new GeneralResponse
                        {
                            success = false,
                            response = 500,
                            responseDescription = result.DisplayMessage,
                            referenceNumber = request.tbl_receptacle_code
                        });
                    }

                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = "Missing/Invalid receptacle id or number.",
                        referenceNumber = request.tbl_receptacle_code
                    });
                }
                catch (Exception ex)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        response = 500,
                        responseDescription = ex.Message.ToString(),
                        success = false,
                        referenceNumber = request.tbl_receptacle_code
                    });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new GeneralResponse
                {
                    response = 300,
                    responseDescription = ex.Message.ToString(),
                    success = false,
                    referenceNumber = request.tbl_receptacle_code
                });
            }
        }

        [HttpPost]
        [Route("LinkToHouse")]
        public async Task<IActionResult> LinkToHouseAsync([FromBody] LinkToHouseRequest request)
        {
            try
            {
                if (request.house != null)
                {
                    var house = await _houseRepository.CreateAsync(request.house);
                    if (house.IsSuccess)
                    {
                        request.parentReference = house.ReferenceNumber;
                    }
                }
                var response = await _repository.LinkToHouseAsync(request);
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

      

        [HttpGet]
        //Edited by HS on 01/02/2023
        //Get the receptacle reference by its house's bill number
        [Route("GetByHouseReference")]
        public async Task<IActionResult> GetByHouseAsync(string houseBillNo)
        {
            try
            {
                
                ResponseDto result = new ResponseDto();
                try
                {
                    result = await _repository.GetByHouseBillNo(houseBillNo);
                    if (result.IsSuccess)
                    {
                        //var jsonString = JsonConvert.SerializeObject(result.Result);
                        //var model = JsonConvert.DeserializeObject<tbl_receptacleDto>(jsonString);
                        return Ok(new GeneralResponse
                        {
                            success = true,
                            response = 200,

                            referenceNumber = result.ReferenceNumber
                        });
                    }

                    return Ok(new GeneralResponse
                    {
                        success = false,
                        response= 500,
                        responseDescription= result.DisplayMessage
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

        //Added by HS on 03/02/2023
        /* This function is used to get the dummy receptacle's reference with a given master billNumber
         * Input: masterBillNumber, not generated reference number
         * Output: A generalResponse with the dummy receptacle reference
         * */
        [HttpGet]
        [Route("GetDummyByMasterBillNo")]
        public async Task<IActionResult> GetDummyByMasterBillNoAsync(string masterBillNo)
        {
            try
            {

                ResponseDto result = new ResponseDto();
                try
                {
                    result = await _repository.GetDummyByMasterBillNo(masterBillNo);
                    if (result.IsSuccess)
                    {
                        //var jsonString = JsonConvert.SerializeObject(result.Result);
                        //var jsonString = JsonConvert.SerializeObject(result.Result, Formatting.Indented, new JsonSerializerSettings
                        //{
                        //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        //});
                        //var model = JsonConvert.DeserializeObject<tbl_receptacleDto>(jsonString);
                        return Ok(new GeneralResponse
                        {
                            success = true,
                            response = 200,
                            referenceNumber = result.ReferenceNumber,
                            responseDescription = "Dummy RefNo:" + result.ReferenceNumber
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
    }
}
