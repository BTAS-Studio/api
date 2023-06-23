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
    [Route("api/container")]
    [Authorize]
    public class ContainerController : GenericController<tbl_containerDto>
    {
        private ContainerRepository _repository;
        private MasterRepository _masterRepository;
        private readonly IAuthenticationRepository _authRepo;

        public ContainerController(ContainerRepository repository, MasterRepository masterRepository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _masterRepository = masterRepository;
            _authRepo = authRepo;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Route("postrange")]
        public async Task<object> PostAsync([FromBody] List<tbl_containerDto> entities)
        {
            try
            {
                List<tbl_containerDto> postedEntity = await _repository.CreateRangeAsync(entities);

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
        public async Task<IActionResult> CreateAsync([FromBody] tbl_containerDto request)
        {
            try
            {
                var result = await _repository.CreateAsync(request);
                if (!result.IsSuccess)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        response = 500,
                        responseDescription = result.DisplayMessage,
                        success = false
                    });
                }

                return Ok(new GeneralResponse
                {
                    success = true,
                    response = 200,
                    responseDescription = result.DisplayMessage,
                    referenceNumber = result.ReferenceNumber
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
    

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_containerDto request)
        {
            try
            {
                try
                {
                    if(request.tbl_container_code != "" && request.tbl_container_code != null)
                    {
                        var result = await _repository.UpdateAsync(request);

                        if (result.IsSuccess)
                        {
                            return Ok(new GeneralResponse
                            {
                                success = true,
                                response = 200,
                                responseDescription = "Container # " + request.tbl_container_code + " successfully updated."
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
                        responseDescription = "Missing/Invalid container id or number."
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

        [HttpPost]
        [Route("LinkToMaster")]
        public async Task<IActionResult> LinkToMasterAsync([FromBody] LinkToMasterRequest request)
        {
            try
            {
                if (request.master != null)
                {
                    var parent = await _masterRepository.CreateAsync(request.master);
                    if (parent.IsSuccess)
                    {
                        request.parentReference = parent.ReferenceNumber;
                    }
                }
                var response = await _repository.LinkToMasterAsync(request);
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
        [Route("getbymaster")]
        public async Task<IActionResult> GetByMasterAsync(string referenceNumber)
        {
            try
            {
                try
                {
                    var response = await _repository.GetByMaster(referenceNumber);

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

        [HttpGet("getfiltered")]
        public async Task<IActionResult> GetFiltered([FromBody] CustomFilters<tbl_containerDto> customFilters)
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
        public async Task<IActionResult> GetByReferenceAsync(string referenceNumber, bool includeChild = false, int isWeb = 0)
        {
            try
            {
                ResponseDto result = new();
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
    }
}
