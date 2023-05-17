using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [Area("Maintenance")]
    [ApiController]
    [Route("api/carrierinfo")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CarrierInfoController : GenericController<tbl_carrier_infoDto>
    {
        //protected GeneralResponse _generalResponse;
        //readonly IConfiguration _configuration;
        //private CarrierInfoRepository _repository;

        public CarrierInfoController(IRepository<tbl_carrier_infoDto> repository) : base(repository)
        {
            //this._generalResponse = new GeneralResponse();
            //_repository = repository;
            //_configuration = configuration;
        }
    }
}
