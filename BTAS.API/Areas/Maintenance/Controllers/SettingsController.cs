using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [Area("Maintenance")]
    [ApiController]
    [Route("api/settings")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SettingsController : GenericController<tbl_default_settingDto>
    {
        //protected GeneralResponse _generalResponse;
        //readonly IConfiguration _configuration;
        //private CarrierInfoRepository _repository;

        public SettingsController(IRepository<tbl_default_settingDto> repository) : base(repository)
        {
            //this._generalResponse = new GeneralResponse();
            //_repository = repository;
            //_configuration = configuration;
        }
    }
}
