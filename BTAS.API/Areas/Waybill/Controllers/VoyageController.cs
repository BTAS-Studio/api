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
    [Route("api/voyage")]
    [Authorize]
    public class VoyageController : GenericController<tbl_voyageDto>
    {
        private VoyageRepository _repository;
        private readonly IAuthenticationRepository _authRepo;
        private MasterRepository _masterRepo;
        public VoyageController(VoyageRepository repository, MasterRepository masterRepo, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _authRepo = authRepo;
            _masterRepo = masterRepo;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Route("postrange")]
        public async Task<object> PostAsync([FromBody] List<tbl_voyageDto> entities)
        {
            try
            {
                List<tbl_voyageDto> postedEntity = await _repository.CreateRangeAsync(entities);

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
        //Edited by HS on 13/12/2022
        public async Task<IActionResult> CreateAsync([FromBody] tbl_voyageDto request)
        {
            if (request.idtbl_voyage > 0 || !String.IsNullOrEmpty(request.tbl_voyage_code))
            {
                return new JsonResult(new GeneralResponse
                {
                    success = false,
                    response = 400,
                    responseDescription = "Invalid request."
                });
            }

            try
            {
                ResponseDto result = new();

                try
                {
                    result = await _repository.CreateAsync(request, Request.Headers["shipperId"]);

                    var jsonString = JsonConvert.SerializeObject(result.Result);
                    var model = JsonConvert.DeserializeObject<tbl_voyageDto>(jsonString);
                    // Edited by HS on 25/01/2023
                    //var masterResponse = masterepo.updat(model.masters.First());
                    //var houseResponse = await HouseRepository.UpdateAsync(masterResponse.Result);

                    GeneralResponse response = new()
                    {
                        success = result.IsSuccess,
                        response = result.IsSuccess ? 200 : 500,
                        responseDescription = result.DisplayMessage,
                        referenceNumber = result.ReferenceNumber
                    };

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
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_voyageDto request)
        {
            if (request.idtbl_voyage <= 0 && String.IsNullOrEmpty(request.tbl_voyage_code))
            {
                return new JsonResult(new GeneralResponse
                {
                    success = false,
                    response = 500,
                    responseDescription = "Missing/Invalid voyage id or code."
                });
            }

            if (await _repository.GetByReference(request.tbl_voyage_code) == null)
            {
                return new JsonResult(new GeneralResponse
                {
                    success = false,
                    response = 500,
                    responseDescription = "Missing/Invalid voyage id or code."
                });
            }

            try
            {
                ResponseDto result = new();

                try
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
                            responseDescription = "Voyage # " + request.tbl_voyage_number + " successfully updated."
                        });
                    }

                    return new JsonResult(new GeneralResponse
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

        [HttpGet]
        [Route("GetByReference")]
        public async Task<IActionResult> GetByReferenceAsync(string referenceNumber, bool includeChild = false)
        {
            try
            {
                ResponseDto response = new();

                try
                {
                    response = await _repository.GetByReference(referenceNumber,includeChild);

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
    }
}
