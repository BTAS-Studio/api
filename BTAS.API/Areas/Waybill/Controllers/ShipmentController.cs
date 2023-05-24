using BTAS.API.Areas.Carriers.Models.Apg;
using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Models.Links;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Waybill.Controllers
{
    [ApiController]
    [Area("Waybill")]
    //[Route("api/parcelinfo")]
    [Route("api/shipment")]
    [Authorize]
    public class ShipmentController : GenericController<tbl_shipmentDto>
    {
        private readonly ShipmentRepository _repository;
        private readonly ReceptacleRepository _receptacleRepository;
        private readonly ApgRepository _apgRepository;
        private readonly ItemSkuRepository _skuRepository;
        //private ClientHeaderRepository _addressRepository;
        private readonly IAuthenticationRepository _authRepo;
        
        public ShipmentController(ShipmentRepository repository, ReceptacleRepository receptacleRepository, ApgRepository apg, ItemSkuRepository sku, IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _receptacleRepository = receptacleRepository;
            _apgRepository = apg;
            _skuRepository = sku;
            _authRepo = authRepo;
        }

        [HttpGet("getfiltered")]
        public async Task<IActionResult> GetFiltered([FromBody] CustomFilters<tbl_shipmentDto> customFilters)
        {
            try
            {
                var response = await _repository.GetFilteredAsync(customFilters);
                if (response != null)
                {
                    return Ok(new GeneralResponse
                    {
                        success = true,
                        responseDescription = response.ToArray().Length.ToString(),
                        result = response
                    });
                }
                else
                {
                    return new JsonResult(new GeneralResponse
                    {
                        response = 500,
                        responseDescription = "No matching result",
                        success = false
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetByReference")]
        public async Task<IActionResult> GetByReferenceAsync(string referenceNumber, bool includeChild = false, int isWeb = 0)
        {
            try
            {
                ResponseDto result = new();
                var response = await _repository.GetByReference(referenceNumber, includeChild);

                return Ok(new GeneralResponse
                {
                    success = response.IsSuccess,
                    referenceNumber = response.ReferenceNumber,
                    responseDescription = response.DisplayMessage,
                    result = response.Result
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

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] tbl_shipmentDto request, int isWeb = 0)
        {
            try
            {
                tbl_shipmentDto result = new();

                //Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
                //foreach (var header in Request.Headers)
                //{
                //    requestHeaders.Add(header.Key, header.Value);
                //}

                //if (isWeb == 0)
                //{
                //    GeneralResponse apiResponse = JsonConvert.DeserializeObject<GeneralResponse>(await _authRepo.ValidateTokenAsync(requestHeaders["apikey"], requestHeaders["apiToken"], requestHeaders["shipperId"]));
                //    if (apiResponse.success == false)
                //    {
                //        return NotFound(apiResponse);
                //    }
                //}

                try
                {
                    result = await _repository.CreateUpdateAsync(request); //tbl_shipmentDto

                    if (isWeb == 1)
                    {
                        var response = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        });
                        return Ok(response);
                    }
                    else
                    {
                        if (result != null)
                        {
                            var jsonString = JsonConvert.SerializeObject(result);
                            var model = JsonConvert.DeserializeObject<tbl_shipmentDto>(jsonString);

                            #region APG
                            if (model.tbl_shipment_serviceCode.ToUpper().IndexOf("UBI") > -1)
                            {
                                var totalWeight = 0.0;
                                var totalLength = 0.0;
                                var totalWidth = 0.0;
                                var totalHeight = 0.0;
                                var totalVolume = 0.0;
                                var weightUnit = "";

                                List<OrderItem> orderItems = new();
                                foreach (var item in request.shipmentItems)
                                {
                                    foreach(var sku in item.items_skus)
                                    {
                                        var skuCode = await _skuRepository.GetByCodeAsync(sku.tbl_item_sku_code);
                                        orderItems.Add(new OrderItem
                                        {
                                            itemNo = item.idtbl_shipment_item.ToString(),
                                            sku = skuCode.tbl_item_sku_code,
                                            description = sku.tbl_items_description,
                                            originCountry = sku.tbl_items_originCountry,
                                            itemCount = item.tbl_shipment_item_qty,
                                            unitValue = sku.tbl_items_value,
                                            weight = item.tbl_shipment_item_weight
                                        });

                                        totalWeight = totalWeight + (double)item.tbl_shipment_item_weight;
                                        totalLength = totalLength + (double)item.tbl_shipment_item_length;
                                        totalWidth = totalWidth + (double)item.tbl_shipment_item_width;
                                        totalHeight = totalHeight + (double)item.tbl_shipment_item_height;
                                        weightUnit = item.tbl_shipment_item_weightUnit;
                                    }
                                    
                                }

                                totalVolume = (totalLength / 100) * (totalWidth / 100) * (totalHeight / 100);

                                CreateShippingRequest createshippingrequest = new CreateShippingRequest()
                                {
                                    referenceNo = result.tbl_shipment_code,
                                    trackingNo = "",
                                    serviceCode = request.tbl_shipment_serviceCode,
                                    incoterm = request.tbl_shipment_incoterm,
                                    description = request.tbl_shipment_description,
                                    nativeDescription = request.tbl_shipment_nativeDescription,
                                    weight = (decimal)totalWeight,
                                    weightUnit = weightUnit,
                                    length = (decimal)totalLength,
                                    width = (decimal)totalWidth,
                                    height = (decimal)totalHeight,
                                    volume = totalVolume,
                                    dimensionUnit = "cm",
                                    invoiceValue = (decimal)request.tbl_shipment_invoiceValue,
                                    invoiceCurrency = request.tbl_shipment_invoiceCurrency,
                                    pickupType = "",
                                    authorityToLeave = (request.tbl_shipment_authorityToLeave == true ? "true" : "false"),
                                    lockerService = (request.tbl_shipment_hasLockerService == true ? "true" : "false"),
                                    batteryType = "",
                                    batteryPacking = "",
                                    dangerousGoods = (request.tbl_shipment_dg == true ? "true" : "false"),
                                    serviceOption = "",
                                    instruction = request.tbl_shipment_instruction,
                                    facility = request.tbl_shipment_facility,
                                    platform = "",
                                    recipientName = request.tbl_shipment_deliveryName,
                                    recipientCompany = request.tbl_shipment_deliveryCompany,
                                    phone = request.tbl_shipment_deliveryPhone,
                                    email = request.tbl_shipment_deliveryEmail,
                                    addressLine1 = request.tbl_shipment_deliveryAddressLine1,
                                    addressLine2 = request.tbl_shipment_deliveryAddressLine2,
                                    addressLine3 = request.tbl_shipment_deliveryAddressLine3,
                                    city = request.tbl_shipment_deliveryCity,
                                    state = request.tbl_shipment_deliveryState,
                                    postcode = request.tbl_shipment_deliveryPostcode,
                                    country = request.tbl_shipment_deliveryCountry,
                                    shipperName = request.tbl_shipment_shipperName,
                                    shipperPhone = request.tbl_shipment_shipperPhone,
                                    shipperAddressLine1 = request.tbl_shipment_shipperAddressLine1,
                                    shipperAddressLine2 = request.tbl_shipment_shipperAddressLine2,
                                    shipperAddressLine3 = request.tbl_shipment_shipperAddressLine3,
                                    shipperCity = request.tbl_shipment_shipperCity,
                                    shipperState = request.tbl_shipment_shipperState,
                                    shipperPostcode = request.tbl_shipment_shipperPostcode,
                                    shipperCountry = request.tbl_shipment_shipperCountry,
                                    returnOption = request.tbl_shipment_returnOption,
                                    returnName = request.tbl_shipment_returnName,
                                    returnAddressLine1 = request.tbl_shipment_returnAddress1,
                                    returnAddressLine2 = request.tbl_shipment_returnAddress2,
                                    returnAddressLine3 = request.tbl_shipment_returnAddress3,
                                    returnCity = request.tbl_shipment_returnCity,
                                    returnState = request.tbl_shipment_returnState,
                                    returnPostcode = request.tbl_shipment_returnPostcode,
                                    returnCountry = request.tbl_shipment_returnCountry,
                                    abnnumber = request.tbl_shipment_abnNumber,
                                    gstexemptioncode = request.tbl_shipment_gstExemptionCode.ToString(),
                                    orderItems = orderItems,
                                    extendData = new ExtendData(),
                                };


                                var apgResult = await _apgRepository.CreateShipmentAsync(new List<CreateShippingRequest> { createshippingrequest });

                                var apgString = JsonConvert.SerializeObject(apgResult);

                                if (apgString.IndexOf("Success") > -1)
                                {
                                    var apgResponse = JsonConvert.DeserializeObject<CreateShippingResponseSuccess>(apgString);

                                    CreateLabelRequest createLabel = new()
                                    {
                                        labelFormat = "JPG",
                                        labelType = 1,
                                        packinglist = false,
                                        merged = false,
                                        orderIds = new List<string>
                                        {
                                            apgResponse.data[0].orderId
                                        }
                                    };

                                    var labelResult = await _apgRepository.CreateLabelAsync(createLabel);
                                    var labelString = JsonConvert.SerializeObject(labelResult);

                                    if (labelString.IndexOf("Success") > -1)
                                    {
                                        var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponseSuccess>(labelString);

                                        return Ok(new GeneralResponse
                                        {
                                            success = true,
                                            response = 200,
                                            responseDescription = "Label successfully created.",
                                            referenceNumber = result.tbl_shipment_code,
                                            shipmentData = new ShipmentData
                                            {
                                                shipmentResponse = apgResponse
                                            },
                                            labelData = new LabelData
                                            {
                                                labelResponse = labelResponse
                                            }
                                        });
                                    }

                                    return Ok(new GeneralResponse
                                    {
                                        success = true,
                                        response = 200,
                                        referenceNumber = result.tbl_shipment_code,
                                        shipmentData = new ShipmentData
                                        {
                                            shipmentResponse = apgResponse
                                        },
                                        labelData = null
                                    });
                                }

                                return Ok(new GeneralResponse
                                {
                                    success = true,
                                    response = 200,
                                    referenceNumber = result.tbl_shipment_code,
                                    shipmentData = new ShipmentData
                                    {
                                        shipmentResponse = apgResult
                                    },
                                    labelData = null
                                });

                            }
                            
                            return Ok(new GeneralResponse
                            {
                                success = true,
                                response = 200,
                                referenceNumber = result.tbl_shipment_code,
                                responseDescription = "Shipment successfully created/updated."
                            });
                            #endregion
                        }

                        return Ok(new GeneralResponse
                        {
                            success = false,
                            response = 500,
                        });
                    }
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
                    response = 500,
                    responseDescription = ex.Message.ToString(),
                    success = false
                });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_shipmentDto request)
        {
            try
            {
                tbl_shipmentDto result = new();
                try
                {
                    if (request.tbl_shipment_code != "" && request.tbl_shipment_code != null)
                    {
                        result = await _repository.CreateUpdateAsync(request);

                        if (result != null)
                        {
                            var jsonString = JsonConvert.SerializeObject(result);
                            var model = JsonConvert.DeserializeObject<tbl_shipmentDto>(jsonString);

                            if (request.tbl_shipment_serviceCode.ToUpper().IndexOf("UBI") > -1)
                            {
                                var totalWeight = 0.0;
                                var totalLength = 0.0;
                                var totalWidth = 0.0;
                                var totalHeight = 0.0;
                                var totalVolume = 0.0;
                                var weightUnit = "";

                                List<OrderItem> orderItems = new();
                                foreach (var item in request.shipmentItems)
                                {
                                    foreach(var sku in item.items_skus)
                                    {
                                        var skuCode = await _skuRepository.GetByCodeAsync(sku.tbl_item_sku_code);
                                        orderItems.Add(new OrderItem
                                        {
                                            itemNo = item.idtbl_shipment_item.ToString(),
                                            sku = skuCode.tbl_item_sku_code,
                                            description = sku.tbl_items_description,
                                            originCountry = sku.tbl_items_originCountry,
                                            itemCount = item.tbl_shipment_item_qty,
                                            unitValue = sku.tbl_items_value,
                                            weight = item.tbl_shipment_item_weight
                                        });

                                        totalWeight = totalWeight + (double)item.tbl_shipment_item_weight;
                                        totalLength = totalLength + (double)item.tbl_shipment_item_length;
                                        totalWidth = totalWidth + (double)item.tbl_shipment_item_width;
                                        totalHeight = totalHeight + (double)item.tbl_shipment_item_height;
                                        weightUnit = item.tbl_shipment_item_weightUnit;
                                    }
                                    
                                }

                                totalVolume = (totalLength / 100) * (totalWidth / 100) * (totalHeight / 100);

                                CreateShippingRequest createshippingrequest = new CreateShippingRequest()
                                {
                                    referenceNo = result.tbl_shipment_code,
                                    trackingNo = "",
                                    serviceCode = request.tbl_shipment_serviceCode,
                                    incoterm = request.tbl_shipment_incoterm,
                                    description = request.tbl_shipment_description,
                                    nativeDescription = request.tbl_shipment_nativeDescription,
                                    weight = (decimal)totalWeight,
                                    weightUnit = weightUnit,
                                    length = (decimal)totalLength,
                                    width = (decimal)totalWidth,
                                    height = (decimal)totalHeight,
                                    volume = totalVolume,
                                    dimensionUnit = "cm",
                                    invoiceValue = (decimal)request.tbl_shipment_invoiceValue,
                                    invoiceCurrency = request.tbl_shipment_invoiceCurrency,
                                    pickupType = "",
                                    authorityToLeave = (request.tbl_shipment_authorityToLeave == true ? "true" : "false"),
                                    lockerService = (request.tbl_shipment_hasLockerService == true ? "true" : "false"),
                                    batteryType = "",
                                    batteryPacking = "",
                                    dangerousGoods = (request.tbl_shipment_dg == true ? "true" : "false"),
                                    serviceOption = "",
                                    instruction = request.tbl_shipment_instruction,
                                    facility = request.tbl_shipment_facility,
                                    platform = "",
                                    recipientName = request.tbl_shipment_deliveryName,
                                    recipientCompany = request.tbl_shipment_deliveryCompany,
                                    phone = request.tbl_shipment_deliveryPhone,
                                    email = request.tbl_shipment_deliveryEmail,
                                    addressLine1 = request.tbl_shipment_deliveryAddressLine1,
                                    addressLine2 = request.tbl_shipment_deliveryAddressLine2,
                                    addressLine3 = request.tbl_shipment_deliveryAddressLine3,
                                    city = request.tbl_shipment_deliveryCity,
                                    state = request.tbl_shipment_deliveryState,
                                    postcode = request.tbl_shipment_deliveryPostcode,
                                    country = request.tbl_shipment_deliveryCountry,
                                    shipperName = request.tbl_shipment_shipperName,
                                    shipperPhone = request.tbl_shipment_shipperPhone,
                                    shipperAddressLine1 = request.tbl_shipment_shipperAddressLine1,
                                    shipperAddressLine2 = request.tbl_shipment_shipperAddressLine2,
                                    shipperAddressLine3 = request.tbl_shipment_shipperAddressLine3,
                                    shipperCity = request.tbl_shipment_shipperCity,
                                    shipperState = request.tbl_shipment_shipperState,
                                    shipperPostcode = request.tbl_shipment_shipperPostcode,
                                    shipperCountry = request.tbl_shipment_shipperCountry,
                                    returnOption = request.tbl_shipment_returnOption,
                                    returnName = request.tbl_shipment_returnName,
                                    returnAddressLine1 = request.tbl_shipment_returnAddress1,
                                    returnAddressLine2 = request.tbl_shipment_returnAddress2,
                                    returnAddressLine3 = request.tbl_shipment_returnAddress3,
                                    returnCity = request.tbl_shipment_returnCity,
                                    returnState = request.tbl_shipment_returnState,
                                    returnPostcode = request.tbl_shipment_returnPostcode,
                                    returnCountry = request.tbl_shipment_returnCountry,
                                    abnnumber = request.tbl_shipment_abnNumber,
                                    gstexemptioncode = request.tbl_shipment_gstExemptionCode.ToString(),
                                    orderItems = orderItems,
                                    extendData = new ExtendData(),
                                };


                                var apgResult = await _apgRepository.CreateShipmentAsync(new List<CreateShippingRequest> { createshippingrequest });

                                var apgString = JsonConvert.SerializeObject(apgResult);

                                if (apgString.IndexOf("Success") > -1)
                                {
                                    var apgResponse = JsonConvert.DeserializeObject<CreateShippingResponseSuccess>(apgString);

                                    CreateLabelRequest createLabel = new()
                                    {
                                        labelFormat = "JPG",
                                        labelType = 1,
                                        packinglist = false,
                                        merged = false,
                                        orderIds = new List<string>
                                        {
                                            apgResponse.data[0].orderId
                                        }
                                    };

                                    var labelResult = await _apgRepository.CreateLabelAsync(createLabel);
                                    var labelString = JsonConvert.SerializeObject(labelResult);

                                    if (labelString.IndexOf("Success") > -1)
                                    {
                                        var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponseSuccess>(labelString);

                                        return Ok(new GeneralResponse
                                        {
                                            success = true,
                                            response = 200,
                                            referenceNumber = result.tbl_shipment_code,
                                            shipmentData = new ShipmentData
                                            {
                                                shipmentResponse = apgResponse
                                            },
                                            labelData = new LabelData
                                            {
                                                labelResponse = labelResponse
                                            }
                                        });
                                    }

                                    return Ok(new GeneralResponse
                                    {
                                        success = true,
                                        response = 200,
                                        referenceNumber = result.tbl_shipment_code,
                                        shipmentData = new ShipmentData
                                        {
                                            shipmentResponse = apgResponse
                                        },
                                        labelData = null
                                    });
                                }

                                return Ok(new GeneralResponse
                                {
                                    success = true,
                                    response = 200,
                                    referenceNumber = result.tbl_shipment_code,
                                    shipmentData = new ShipmentData
                                    {
                                        shipmentResponse = apgResult
                                    },
                                    labelData = null
                                });

                            }

                            return Ok(new GeneralResponse
                            {
                                success = true,
                                response = 200,
                                referenceNumber = result.tbl_shipment_code
                            });
                        }

                        return new JsonResult(new GeneralResponse
                        {
                            success = false,
                            response = 500
                        });
                    }

                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = "Missing/Invalid parcel info id or number."
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

    //    [HttpPost]
    //    [Route("LinkToReceptacle")]
    //    public async Task<IActionResult> LinkToReceptacleAsync([FromBody] LinkToReceptacleRequest request)
    //    {
    //        try
    //        {
    //            if (request.receptacle != null)
    //            {
    //                var house = await _receptacleRepository.CreateAsync(request.receptacle, Request.Headers["shipperId"]);
    //                if (house.IsSuccess)
    //                {
    //                    request.parentReference = house.ReferenceNumber;
    //                }
    //            }
    //            var response = await _repository.LinkToReceptacle(request);
    //            if (response.IsSuccess)
    //            {
    //                if (response.DisplayMessage == "failed")
    //                {
    //                    response.DisplayMessage = "Failed updating record.";
    //                }
    //            }
    //            return Ok(response);
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HttpPost]
    //    [Route("LinkToReceptacleByConsignment")]
    //    public async Task<IActionResult> LinkToReceptacleByConsignmentAsync([FromBody] LinkToReceptacleRequest request)
    //    {
    //        try
    //        {
    //            if (request.receptacle != null)
    //            {
    //                var receptacle = await _receptacleRepository.CreateAsync(request.receptacle, Request.Headers["shipperId"]);
    //                if (receptacle.IsSuccess)
    //                {
    //                    request.parentReference = receptacle.ReferenceNumber;
    //                }
    //            }

    //            var response = await _repository.LinkToReceptacleByConsignment(request);
    //            if (response.IsSuccess)
    //            {
    //                var jsonString = JsonConvert.SerializeObject(response.Result);
    //                var model = JsonConvert.DeserializeObject<tbl_receptacleDto>(jsonString);
    //                return Ok(new GeneralResponse
    //                {
    //                    success = true,
    //                    response = 200,
    //                    responseDescription = response.DisplayMessage
    //                });
    //            }
    //            return Ok(new GeneralResponse
    //            {
    //                success = false,
    //                response = 500,
    //                responseDescription = response.DisplayMessage
    //            });
    //        }
    //        catch (Exception ex)
    //        {
    //            return new JsonResult(new GeneralResponse
    //            {
    //                response = 500,
    //                responseDescription = ex.Message.ToString(),
    //                success = false
    //            });
    //        }
    //    }

    //    [HttpGet]
    //    [Route("GetByReference")]
    //    public async Task<IActionResult> GetByReferenceAsync(string referenceNumber, bool includeChild = false, int isWeb = 0)
    //    {
    //        try
    //        {
    //            ResponseDto result = new();

    //            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
    //            foreach (var header in Request.Headers)
    //            {
    //                requestHeaders.Add(header.Key, header.Value);
    //            }

    //            if (isWeb == 0)
    //            {
    //                GeneralResponse apiResponse = JsonConvert.DeserializeObject<GeneralResponse>(await _authRepo.ValidateTokenAsync(requestHeaders["apikey"], requestHeaders["apiToken"], requestHeaders["shipperId"]));
    //                if (apiResponse.success == false)
    //                {
    //                    return NotFound(apiResponse);
    //                }
    //            }

    //            try
    //            {
    //                var response = await _repository.GetByReference(referenceNumber, includeChild);

    //                return Ok(response);
    //            }
    //            catch (Exception ex)
    //            {
    //                return new JsonResult(new GeneralResponse
    //                {
    //                    response = 500,
    //                    responseDescription = ex.Message.ToString(),
    //                    success = false,
    //                    referenceNumber = referenceNumber
    //                });
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return new JsonResult(new GeneralResponse
    //            {
    //                response = 300,
    //                responseDescription = ex.Message.ToString(),
    //                success = false,
    //                referenceNumber = referenceNumber
    //            });
    //        }
    //    }

    //    [HttpGet]
    //    [Route("getbyreceptacle")]
    //    public async Task<IActionResult> GetByMasterReceptacleAsync(string referenceNumber)
    //    {
    //        try
    //        {
    //            try
    //            {
    //                var response = await _repository.GetByReceptacle(referenceNumber);

    //                return Ok(response);
    //            }
    //            catch (Exception ex)
    //            {
    //                return new JsonResult(new GeneralResponse
    //                {
    //                    response = 500,
    //                    responseDescription = ex.Message.ToString(),
    //                    success = false
    //                });
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return new JsonResult(new GeneralResponse
    //            {
    //                response = 300,
    //                responseDescription = ex.Message.ToString(),
    //                success = false
    //            });
    //        }
    //    }
    }
}
