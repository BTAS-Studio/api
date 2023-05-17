using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Waybill.Controllers
{
    [ApiController]
    [Area("Waybill")]
    [Route("api/itemsku")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    public class ShipperController : GenericController<tbl_shippers_tracking_refDto>
    {
        private ShipmentTrackingRepository _repository;
        private readonly IAuthenticationRepository _authRepo;

        public ShipperController(ShipmentTrackingRepository repository, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _authRepo = authRepo;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] tbl_shippers_tracking_refDto request)
        {
            try
            {
                ResponseDto result = new();

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
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_shippers_tracking_refDto request)
        {
            try
            {
                ResponseDto result = new();

                try
                {
                    if (request.idshippers_tracking_ref > 0)
                    {
                        var shipper = await _repository.CreateUpdateAsync(request);

                        if (result.IsSuccess)
                        {
                            return Ok(new GeneralResponse
                            {
                                success = true,
                                response = 200,
                                responseDescription = "Shipper Tracking # " + request.idshippers_tracking_ref + " successfully updated."
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
                        responseDescription = "Missing/Invalid tracking reference."
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
