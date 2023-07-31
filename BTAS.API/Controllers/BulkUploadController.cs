using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository.Upload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BTAS.API.Controllers
{

    [ApiController]
    [Route("api/bulkupload")]
    [ApiVersion("2.0")]
    [Authorize]
    public class BulkUploadController : ControllerBase
    {
        private BulkUploadRepository _repository;
        public BulkUploadController (BulkUploadRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("bulkupload")]
        public async Task<IActionResult> BulkUploadAsync([FromBody] tbl_voyageDto request)
        {
            try
            {
                var result = await _repository.BulkUploadAsync(request);
                if (result.IsSuccess == false) 
                {
                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 400,
                        responseDescription = result.DisplayMessage
                    });
                }
                return Ok(new GeneralResponse
                {
                    success = true,
                    response = 200,
                    responseDescription = "Data successfully uploaded."
                });
            }
            catch(Exception ex)
            {
                return new JsonResult(new GeneralResponse
                {
                    success = false,

                    response = 500,

                    responseDescription = ex.Message.ToString()
                }) ;
            }
            
        }
    }
}
