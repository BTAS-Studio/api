using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Maintenance.Controllers
{
    [ApiController]
    [Area("Maintenance")]
    [Route("api/shipment")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1", Deprecated = true)]
    [ApiVersion("1.2")]
    public class ShipmentController : GenericController<tbl_shipmentDto>
    {
        //protected GeneralResponse _generalResponse;
        //readonly IConfiguration _configuration;
        private readonly ShipmentRepository _repository;
        private readonly IAuthenticationRepository _authRepo;

        public ShipmentController(ShipmentRepository repository, IAuthenticationRepository authRepo) : base(repository)
        {
            //this._generalResponse = new GeneralResponse();
            _repository = repository;
            _authRepo = authRepo;
            //_configuration = configuration;
        }

        
        /// <summary>
        /// For shipment summary searching with user token validation
        /// </summary>
        /// <param name="request">
        /// json request from body as:
        /// {
        ///    "fromDate": "",
        ///    "toDate": "",
        ///    "shipID": [
        ///    ],
        ///    "tracking": "",
        ///    "shipperName": "",
        ///    "carrierName": "",
        ///    "deliveryName": "",
        ///    "isManifested":1
        /// }
        /// </param>
        /// <returns>
        /// tbl_shipment_searchDto class
        /// </returns>
        [HttpPost]
        [Route("search/summary")]
        [MapToApiVersion("1.2")]
        public async Task<IActionResult> GetShipmentSummary([FromBody] ShipmentSearchRequest request)
        {
            try
            {
                IEnumerable<tbl_shipment_searchDto> result = null;

                //Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
                //foreach (var header in Request.Headers)
                //{
                //    requestHeaders.Add(header.Key, header.Value);
                //}

                //GeneralResponse apiResponse = JsonConvert.DeserializeObject<GeneralResponse>(await _authRepo.ValidateTokenAsync(requestHeaders["apikey"], requestHeaders["apiToken"], requestHeaders["shipperId"]));
                //if (apiResponse.success == false)
                //{

                //    return NotFound(apiResponse);
                //}

                try
                {
                    string idArray = "";
                    foreach (var id in request.shipID)
                    {
                        idArray = string.Concat(idArray, id, ",");
                    }

                    result = await _repository.SearchShipmentAsync(request.fromDate, request.toDate, idArray, request.tracking, request.shipperName, request.carrierName, request.deliveryName, request.isManifested);

                }
                catch (Exception)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        response = 500,
                        responseDescription = "Check your request parameters",
                        success = false
                    });
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return new JsonResult(new GeneralResponse
                {
                    response = 300,
                    responseDescription = "Check your request parameters",
                    success = false
                });
            }
            
        }

        /// <summary>
        /// Get shipment details based on given request
        /// </summary>
        /// <param name="request">
        /// {
        /// "tracking":"100004430",
        /// "shipperId":"AUSTSYD"
        /// }
        /// </param>
        /// <returns>
        /// class ShipmentDetails
        /// </returns>
        [HttpPost]
        [Route("search/details")]
        [MapToApiVersion("1.2")]
        public async Task<IActionResult> GetShipmentDetails([FromBody] ShipmentDetailsRequest request)
        {
            try
            {
                //ShipmentDetails result = null;

                //Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
                //foreach (var header in Request.Headers)
                //{
                //    requestHeaders.Add(header.Key, header.Value);
                //}

                //GeneralResponse apiResponse = JsonConvert.DeserializeObject<GeneralResponse>(await _authRepo.ValidateTokenAsync(requestHeaders["apikey"], requestHeaders["apiToken"], requestHeaders["shipperId"]));
                //if (apiResponse.success == false)
                //{

                //    return NotFound(apiResponse);
                //}
                try
                {
                    var result = await _repository.GetShipmentDetails(request.tracking, request.shipperId);
                    var response = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings { ContractResolver = CustomDataContractResolver.Instance });
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return new JsonResult(new GeneralResponse
                    {
                        response = 500,
                        responseDescription = "Check your request parameters",
                        success = false
                    });
                }

                
            }
            catch (Exception)
            {
                return new JsonResult(new GeneralResponse
                {
                    response = 300,
                    responseDescription = "Check your request parameters",
                    success = false
                });
            }
            
        }
    }
}
