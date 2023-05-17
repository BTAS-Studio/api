using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [Area("Maintenance")]
    [ApiController]
    [Route("api/filters")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DynamicFilterController : GenericController<tbl_dynamic_filtersDto>
    {
        //protected GeneralResponse _generalResponse;
        //readonly IConfiguration _configuration;
        //private CarrierInfoRepository _repository;

        public DynamicFilterController(IRepository<tbl_dynamic_filtersDto> repository) : base(repository)
        {
            //this._generalResponse = new GeneralResponse();
            //_repository = repository;
            //_configuration = configuration;
        }
    }
}
