using AutoMapper;
using BTAS.API.Areas.Carriers.Models.Apg;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Controllers
{
    [Area("Carriers")]
    [ApiController]
    [Route("api/apg")]
    [ApiVersion("1.0")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class ApgController : ControllerBase
    {
        IConfiguration configuration;

        //ParcelInfoRepository piRepo;
        //ParcelItemRepository pItemRepo;
        //ApiResponseRepository apiRepo;
        ApgRepository _repo;
        IMapper _mapper;

        public ApgController(IConfiguration configuration, ApgRepository repo, IMapper mapper)
        {
            this.configuration = configuration;
            //this.piRepo = piRepo;
            //this.pItemRepo = pItemRepo;
            //this.apiRepo = apiRepo;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("CreateShipment")]
        public async Task<IActionResult> CreateShippingAsync([FromBody] List<CreateShippingRequest> request)
        {
            if (request.Count > 0)
            {
                foreach (var shipment in request)
                {
                    if (!shipment.serviceCode.Contains("UBI"))
                        return new JsonResult(new GeneralResponse
                        {
                            success = false,
                            response = 300,
                            responseDescription = "Invalid service code or not found."
                        });
                }
            }

            var response = await _repo.CreateShipmentAsync(request);
            return new JsonResult(response);
        }

        //[HttpPost("QueryShipment")]
        //public async Task<IActionResult> QueryShippingAsync([FromBody] List<string> request)
        //{
        //    var client = CallApg("POST", "/services/shipper/queryorders");

        //    byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
        //    client.ContentLength = data.Length;

        //    using (Stream requestStream = await client.GetRequestStreamAsync())
        //    {
        //        requestStream.Write(data, 0, data.Length);
        //    }

        //    using (WebResponse response = await client.GetResponseAsync())
        //    {
        //        var result = PrintWebResponse(response);
        //        if (result.IndexOf("Failure") > -1)
        //        {
        //            return new JsonResult(JsonConvert.DeserializeObject<GenericResponseError>(result));
        //        }
        //        else
        //        {
        //            if (result.IndexOf("Partial") > -1)
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<GenericResponsePartial>(result));
        //            }
        //            else
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<CloseShipmentResponseSuccess>(result));
        //            }
        //        }
        //    }
        //}

        //[HttpPost("GainTracking")]
        //public async Task<IActionResult> GainTrackingAsync([FromBody] List<string> request)
        //{
        //    var client = CallApg("POST", "/services/shipper/trackingNumbers");

        //    byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
        //    client.ContentLength = data.Length;

        //    using (Stream requestStream = await client.GetRequestStreamAsync())
        //    {
        //        requestStream.Write(data, 0, data.Length);
        //    }

        //    using (WebResponse response = await client.GetResponseAsync())
        //    {
        //        var result = PrintWebResponse(response);
        //        if (result.IndexOf("Failure") > -1)
        //        {
        //            return new JsonResult(JsonConvert.DeserializeObject<GenericResponseError>(result));
        //        }
        //        else
        //        {
        //            if (result.IndexOf("Partial") > -1)
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<GenericResponsePartial>(result));
        //            }
        //            else
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<CloseShipmentResponseSuccess>(result));
        //            }
        //        }
        //    }
        //}

        //[HttpPost("CreateOrder")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //public async Task<IActionResult> CreateOrderAsync([FromBody] List<CreateShippingRequest> request)
        //{
        //    var client = CallApg("POST", "/services/shipper/orders");

        //    byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
        //    client.ContentLength = data.Length;

        //    using (Stream requestStream = await client.GetRequestStreamAsync())
        //    {
        //        requestStream.Write(data, 0, data.Length);
        //    }

        //    using (WebResponse response = await client.GetResponseAsync())
        //    {
        //        var result = PrintWebResponse(response);
        //        if (result.IndexOf("Failure") > -1)
        //        {
        //            return new JsonResult(JsonConvert.DeserializeObject<CreateShippingResponseError>(result));
        //        }
        //        else
        //        {
        //            if (result.IndexOf("Partial") > -1)
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<GenericResponsePartial>(result));
        //            }
        //            else
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<CreateShippingResponseSuccess>(result));
        //            }
        //        }
        //    }
        //}

        //[HttpPost("CloseShipment")]
        //public async Task<IActionResult> CloseOrderAsync([FromBody] List<string> request)
        //{
        //    var client = CallApg("POST", "/services/shipper/manifests");

        //    byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
        //    client.ContentLength = data.Length;

        //    using (Stream requestStream = await client.GetRequestStreamAsync())
        //    {
        //        requestStream.Write(data, 0, data.Length);
        //    }

        //    using (WebResponse response = await client.GetResponseAsync())
        //    {
        //        var result = PrintWebResponse(response);
        //        if (result.IndexOf("Failure") > -1)
        //        {
        //            return new JsonResult(JsonConvert.DeserializeObject<GenericResponseError>(result));
        //        }
        //        else
        //        {
        //            if (result.IndexOf("Partial") > -1)
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<GenericResponsePartial>(result));
        //            }
        //            else
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<CloseShipmentResponseSuccess>(result));
        //            }
        //        }
        //    }
        //}

        [HttpPost("CreateLabel")]
        public async Task<IActionResult> CreateLabelAsync([FromBody] CreateLabelRequest request)
        {
            var response = await _repo.CreateLabelAsync(request);
            return new JsonResult(response);
        }

        //[HttpPost("ShippingCost")]
        //public async Task<IActionResult> ShippingCostAsync([FromBody] List<string> request)
        //{
        //    var client = CallApg("POST", "/services/shipper/cost-query");

        //    byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
        //    client.ContentLength = data.Length;

        //    using (Stream requestStream = await client.GetRequestStreamAsync())
        //    {
        //        requestStream.Write(data, 0, data.Length);
        //    }

        //    using (WebResponse response = await client.GetResponseAsync())
        //    {
        //        var result = PrintWebResponse(response);
        //        if (result.IndexOf("Failure") > -1)
        //        {
        //            return new JsonResult(JsonConvert.DeserializeObject<ShippingCostResponseError>(result));
        //        }
        //        else
        //        {
        //            return new JsonResult(JsonConvert.DeserializeObject<ShippingCostResponseSuccess>(result));
        //        }
        //    }
        //}

        //[HttpPost("GetTracking")]
        //public async Task<IActionResult> GetTrackingAsync([FromBody] List<string> request)
        //{
        //    var client = CallApg("POST", "/services/shipper/trackingNumbers");

        //    byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
        //    client.ContentLength = data.Length;

        //    using (Stream requestStream = await client.GetRequestStreamAsync())
        //    {
        //        requestStream.Write(data, 0, data.Length);
        //    }

        //    using (WebResponse response = await client.GetResponseAsync())
        //    {
        //        var result = PrintWebResponse(response);
        //        if (result.IndexOf("Failure") > -1)
        //        {
        //            return new JsonResult(JsonConvert.DeserializeObject<GenericResponseError>(result));
        //        }
        //        else
        //        {
        //            if (result.IndexOf("Partial") > -1)
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<GetTrackingResponsePartial>(result));
        //            }
        //            else
        //            {
        //                return new JsonResult(JsonConvert.DeserializeObject<GetTrackingResponseSuccess>(result));
        //            }
        //        }
        //    }
        //}

        //private HttpWebRequest CallApg(string method, string route)
        //{
        //    string uri = "http://qa.etowertech.com";
        //    string path = uri + route;
        //    string wallTechDate = String.Format("{0:R}", DateTime.UtcNow);
        //    string auth = method + '\n' + wallTechDate + '\n' + path;
        //    string hash = EncodeAuth(auth, configuration["ETowerCredentials:Secret"]);

        //    HttpWebRequest client = (HttpWebRequest)WebRequest.Create(path);

        //    client.ContentType = "application/json";
        //    client.Accept = "application/json";
        //    client.Headers.Add("X-WallTech-Date", wallTechDate);
        //    client.Headers.Add("Authorization", "WallTech " + configuration["ETowerCredentials:Token"] + ':' + hash);
        //    client.Method = method;

        //    return client;
        //}


        //static string PrintWebResponse(WebResponse response)
        //{
        //    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        //    {
        //        string text = reader.ReadToEnd();
        //        return text;
        //    }
        //}

        //static string EncodeAuth(string data, string key)
        //{
        //    string rtn = null;
        //    if (null != data && null != key)
        //    {
        //        byte[] byteData = Encoding.UTF8.GetBytes(data);
        //        byte[] byteKey = Encoding.UTF8.GetBytes(key);
        //        using (HMACSHA1 myhmacsha1 = new HMACSHA1(Encoding.UTF8.GetBytes(key)))
        //        {
        //            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
        //            {
        //                byte[] hashValue = myhmacsha1.ComputeHash(stream);
        //                rtn = Convert.ToBase64String(hashValue);
        //            }
        //        }
        //    }
        //    return rtn;
        //}
    }
}
