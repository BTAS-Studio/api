using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronPdf;
using BTAS.API.Repository;
using BTAS.API.Extensions;
using System.Xml.Serialization;
using System.IO;
using System.Net.Http;
using BTAS.API.Areas.Carriers.Models.Allied;

namespace BTAS.API.Areas.Carriers.Controllers
{
    [Area("Carriers")]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class AlliedController : ControllerBase
    {
        private readonly AlliedRepository _repo;

        public AlliedController(AlliedRepository repo)
        {
            _repo = repo;
        }

        //[Consumes(@"application/soap+xml", otherContentTypes: @"text/xml")]
        [HttpPost("initaccount")]
        public async Task<IActionResult> AuthorizeAccount()
        {
            // Parse the SOAP request to get the data payload
            //var xmlPayload = XmlHelper.GetSoapXmlBody(request);

            // Deserialize the data payload
            //var serializer = new XmlSerializer(typeof(Account));
            //var account = (Account)serializer.Deserialize(new StringReader(request));

            var result = await _repo.GetAccount();
            return Ok(result);
        }

        [HttpPost("CreateJob")]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobRequest.CreateBooking request)
        {
            

            var result = await _repo.CreateJob(request);
            return Ok(result);
        }
    }
}
