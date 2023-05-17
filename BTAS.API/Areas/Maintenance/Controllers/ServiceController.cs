using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [ApiController]
    [Area("Maintenance")]
    [Route("api/service")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ServiceController : GenericController<tbl_servicesDto>
    {
        //protected GeneralResponse _generalResponse;
        //readonly IConfiguration _configuration;
        //private CarrierInfoRepository _repository;

        public ServiceController(IRepository<tbl_servicesDto> repository) : base(repository)
        {
            //this._generalResponse = new GeneralResponse();
            //_repository = repository;
            //_configuration = configuration;
        }
    }
}
