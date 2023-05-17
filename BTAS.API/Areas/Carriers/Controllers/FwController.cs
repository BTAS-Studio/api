using AutoMapper;
using BTAS.API.Areas.Carriers.Models.Fastway;
using BTAS.API.Models;
using BTAS.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Controllers
{
    [Area("Carriers")]
    [ApiController]
    [Route("api/fw")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class FwController : ControllerBase
    {
        IConfiguration configuration;
        FastwayRepository _repo;
        IMapper _mapper;

        public FwController(IConfiguration configuration, FastwayRepository repo, IMapper mapper)
        {
            this.configuration = configuration;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("CreateShipment")]
        public async Task<IActionResult> CreateShippingAsync([FromBody] FWCreateShippingRequest request)
        {
            if (request != null)
            {
                if (!request.Services[0].ServiceCode.Contains("FW"))
                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 300,
                        responseDescription = "Invalid service code or not found."
                    });
            }

            var response = await _repo.CreateShipmentAsync(request);
            return new JsonResult(response);
        }
    }
}
