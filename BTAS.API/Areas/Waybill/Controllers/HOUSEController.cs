using BTAS.API.Areas.Carriers.Models.Allied;
using BTAS.API.Areas.Carriers.Models.Apg;
using BTAS.API.Areas.Carriers.Models.Austway;
using BTAS.API.Areas.Carriers.Models.Fastway;
using BTAS.API.Controllers;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Models.Links;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
//using BTAS.WCF.AlliedWS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Waybill.Controllers
{
    [ApiController]
    [Area("Waybill")]
    [Route("api/house")]
    [Authorize]
    public class HouseController : GenericController<tbl_houseDto>
    {
        private HouseRepository _repository;
        private MasterRepository _masterRepository;
        private ContainerRepository _containerRepository;
        private ItemSkuRepository _skuRepository;
        private ClientHeaderRepository _addressRepository;
        private readonly IAuthenticationRepository _authRepo;
        private IConfiguration configuration;
        private ApgRepository _apgRepository;
        private AlliedRepository _aldRepository;
        private FastwayRepository _fwRepository;
        private BorderRepository _borderRepository;
        private NZRepository _nzRepository;
        private AmazonRepository _amazonRepository;
        private Austway3plRepository _austway3plRepository;
        private AustwayTruckRepository _austwayTruckRepository;
        //private AustwayLabelRepository _austRepository;
        //private BarcodeRepository _barcodeRepository;

        public HouseController(HouseRepository repository,
            MasterRepository masterRepository,
            ContainerRepository containerRepository,
            ItemSkuRepository skuRepository,
            ClientHeaderRepository addressRepository,
            IConfiguration configuration,
            ApgRepository apgRepository,
            AlliedRepository aldRepository,
            FastwayRepository fwRepository,
            BorderRepository borderRepository,
            NZRepository nzRepository,
            AmazonRepository amazonRepository,
            Austway3plRepository austway3plRepository,
            AustwayTruckRepository austwayTruckRepository,
        //AustwayLabelRepository austRepository,
        //BarcodeRepository barcodeRepository,
        IAuthenticationRepository authRepo) : base(repository)
        {
            _repository = repository;
            _masterRepository = masterRepository;
            _containerRepository = containerRepository;
            _skuRepository = skuRepository;
            _addressRepository = addressRepository;
            this.configuration = configuration;
            _apgRepository = apgRepository;
            _aldRepository = aldRepository;
            _fwRepository = fwRepository;
            _borderRepository = borderRepository;
            _nzRepository = nzRepository;
            _amazonRepository = amazonRepository;
            _austway3plRepository = austway3plRepository;
            _austwayTruckRepository = austwayTruckRepository;
            //_austRepository = austRepository;
            //_barcodeRepository = barcodeRepository;
            _authRepo = authRepo;
        }

        [HttpGet("getfiltered")]
        public async Task<IActionResult> GetFiltered([FromBody] CustomFilters<tbl_houseDto> customFilters)
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

        [HttpPost]
        [Route("postrange")]
        public async Task<object> PostAsync([FromBody] List<tbl_houseDto> entities)
        {
            try
            {
                List<tbl_houseDto> postedEntity = await _repository.CreateRangeAsync(entities);

                _response.result = postedEntity;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.errorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] tbl_houseDto request)
        {
            if (request.idtbl_house > 0 || !String.IsNullOrEmpty(request.tbl_house_code))
            {
                return new JsonResult(new GeneralResponse
                {
                    success = false,
                    response = 500,
                    responseDescription = "Invalid request."
                });
            }

            ResponseDto result = new();

            try
            {
                result = await _repository.CreateAsync(request, Request.Headers["shipperId"]);
                /*
                #region carriers
                //if (result.IsSuccess)
                //{
                //    List<string> htmlStrings = new();

                //    var jsonString = JsonConvert.SerializeObject(result.Result, Formatting.None, new JsonSerializerSettings
                //    {
                //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                //    });
                //    var model = JsonConvert.DeserializeObject<tbl_houseDto>(jsonString);

                //    List<OrderItem> orderItems = new();
                //    List<LabelItem> labelItems = new();
                //    double grossAmount = 0.0;

                //    foreach (var item in model.houseItems)
                //    {
                //        foreach (var sku in item.itemSkus)
                //        {
                //            var skuCode = await _skuRepository.GetByCodeAsync(sku.tbl_item_sku_code);
                //            orderItems.Add(new OrderItem
                //            {
                //                itemNo = item.idtbl_house_item.ToString(),
                //                sku = skuCode.tbl_item_sku_code,
                //                description = sku.tbl_items_description,
                //                originCountry = sku.tbl_items_originCountry,
                //                itemCount = item.tbl_house_item_qty,
                //                unitValue = sku.tbl_items_value,
                //                weight = sku.tbl_items_weight
                //            });

                //            labelItems.Add(new LabelItem
                //            {
                //                ItemId = item.idtbl_house_item,
                //                HouseId = model.idtbl_house,
                //                Weight = sku.tbl_items_weight,
                //                ParcelPallet = request.tbl_house_serviceCode.IndexOf("BOR") > -1 ? (request.tbl_house_serviceCode.ToUpper().IndexOf("EXP") > -1 ? "PAR" : "PAL") : "PAR"
                //            });

                //            grossAmount += Convert.ToDouble(sku.tbl_items_value);
                //        }

                //    }

                //    var consignor = await _addressRepository.GetByReference(model.ConsignorCode);
                //    var consignee = await _addressRepository.GetByReference(model.ConsigneeCode);
                //    var delivery = await _addressRepository.GetByReference(model.tbl_house_delivery);

                //    tbl_client_headerDto shipper = (tbl_client_headerDto)consignor.Result;
                //    tbl_client_headerDto recipient = (tbl_client_headerDto)consignee.Result;

                //    #region APG
                //    if (request.tbl_house_serviceCode.ToUpper().IndexOf("UBI") > -1)
                //    {

                //        CreateShippingRequest createshippingrequest = new CreateShippingRequest()
                //        {
                //            referenceNo = model.tbl_house_code,
                //            trackingNo = "",
                //            serviceCode = request.tbl_house_serviceCode,
                //            incoterm = request.tbl_house_incotermCode,
                //            description = request.tbl_house_description,
                //            nativeDescription = request.tbl_house_native_description,
                //            weight = request.tbl_house_weight,
                //            weightUnit = "",
                //            length = request.tbl_house_length,
                //            width = request.tbl_house_width,
                //            height = request.tbl_house_height,
                //            volume = 1,
                //            dimensionUnit = "cm",
                //            invoiceValue = (decimal)request.tbl_house_value,
                //            invoiceCurrency = request.tbl_house_currency,
                //            pickupType = "",
                //            authorityToLeave = "",
                //            lockerService = "",
                //            batteryType = "",
                //            batteryPacking = "",
                //            dangerousGoods = (request.tbl_house_DG == 1 ? "true" : "false"),
                //            serviceOption = "",
                //            instruction = "",
                //            facility = "",
                //            platform = "",
                //            recipientName = recipient.tbl_client_header_contactName,
                //            recipientCompany = "",
                //            phone = recipient.tbl_client_header_phone,
                //            email = recipient.tbl_client_header_email,
                //            addressLine1 = recipient.deliveryAddress.tbl_address_address1,
                //            addressLine2 = recipient.deliveryAddress.tbl_address_address2,
                //            addressLine3 = "",
                //            city = recipient.deliveryAddress.tbl_address_suburb,
                //            state = recipient.deliveryAddress.tbl_address_state,
                //            postcode = recipient.deliveryAddress.tbl_address_postcode,
                //            country = recipient.deliveryAddress.tbl_address_country,
                //            shipperName = shipper.tbl_client_header_contactName,
                //            shipperPhone = shipper.tbl_client_header_phone,
                //            shipperAddressLine1 = shipper.deliveryAddress.tbl_address_address1,
                //            shipperAddressLine2 = shipper.deliveryAddress.tbl_address_address2,
                //            shipperAddressLine3 = "",
                //            shipperCity = shipper.deliveryAddress.tbl_address_city,
                //            shipperState = shipper.deliveryAddress.tbl_address_state,
                //            shipperPostcode = shipper.deliveryAddress.tbl_address_postcode,
                //            shipperCountry = shipper.deliveryAddress.tbl_address_country,
                //            returnOption = "",
                //            returnName = "",
                //            returnAddressLine1 = "",
                //            returnAddressLine2 = "",
                //            returnAddressLine3 = "",
                //            returnCity = "",
                //            returnState = "",
                //            returnPostcode = "",
                //            returnCountry = "",
                //            abnnumber = "",
                //            gstexemptioncode = "",
                //            orderItems = orderItems,
                //            extendData = new ExtendData(),
                //        };

                //        var apgResult = await _apgRepository.CreateShipmentAsync(new List<CreateShippingRequest> { createshippingrequest });

                //        var apgString = JsonConvert.SerializeObject(apgResult);



                //        if (apgString.IndexOf("Success") > -1)
                //        {
                //            var apgResponse = JsonConvert.DeserializeObject<CreateShippingResponseSuccess>(apgString);

                //            CreateLabelRequest createLabel = new()
                //            {
                //                labelFormat = "JPG",
                //                labelType = 1,
                //                packinglist = false,
                //                merged = false,
                //                orderIds = new List<string>
                //                    {
                //                        apgResponse.data[0].orderId
                //                    }
                //            };

                //            var labelResult = await _apgRepository.CreateLabelAsync(createLabel);
                //            var labelString = JsonConvert.SerializeObject(labelResult);

                //            if (labelString.IndexOf("Success") > -1)
                //            {
                //                var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponseSuccess>(labelString);

                //                    return Ok(new GeneralResponse
                //                    {
                //                        success = true,
                //                        response = 200,
                //                        responseDescription = result.DisplayMessage,
                //                        referenceNumber = result.ReferenceNumber,
                //                        shipmentData = new ShipmentData
                //                        {
                //                            shipmentResponse = apgResponse
                //                        },
                //                        labelData = new LabelData
                //                        {
                //                            labelResponse = labelResponse
                //                        }
                //                    });
                //                }
                //            }
                //        }
                //        #endregion

                //    #region Allied
                //    if (request.tbl_house_serviceCode.ToUpper().IndexOf("ALD") > -1)
                //    {
                //        List<Item> alliedItems = new();
                //        foreach (var item in request.houseItems)
                //        {
                //            foreach (var sku in item.itemSkus)
                //            {
                //                var skuCode = await _skuRepository.GetByCodeAsync(sku.tbl_item_sku_code);
                //                alliedItems.Add(new Item
                //                {
                //                    dangerous = false,
                //                    length = (int)Math.Ceiling(item.tbl_house_item_length),
                //                    width = (int)Math.Ceiling(item.tbl_house_item_width),
                //                    height = (int)Math.Ceiling(item.tbl_house_item_height),
                //                    itemCount = item.tbl_house_item_qty,
                //                    weight = Convert.ToInt32(item.tbl_house_item_weight),
                //                    volume = Convert.ToDouble(item.tbl_house_item_length * item.tbl_house_item_width * item.tbl_house_item_height)
                //                });

                //            }
                //        }

                //        JobStop pickupAddress = new()
                //        {
                //            companyName = shipper.tbl_client_header_companyName,
                //            contact = shipper.tbl_client_header_contactName,
                //            phoneNumber = shipper.tbl_client_header_phone,
                //            stopType = "P",
                //            stopNumber = 1,
                //            geographicAddress = new GeographicAddress()
                //            {
                //                address1 = shipper.pickupAddress.tbl_address_address1,
                //                address2 = shipper.pickupAddress.tbl_address_address2,
                //                suburb = shipper.pickupAddress.tbl_address_suburb,
                //                state = shipper.pickupAddress.tbl_address_state,
                //                postCode = shipper.pickupAddress.tbl_address_postcode,
                //                country = shipper.pickupAddress.tbl_address_country
                //            }
                //        };

                //        JobStop deliveryAddress = new()
                //        {
                //            companyName = recipient.tbl_client_header_companyName,
                //            contact = recipient.tbl_client_header_contactName,
                //            phoneNumber = recipient.tbl_client_header_phone,
                //            stopType = "D",
                //            stopNumber = 2,
                //            geographicAddress = new GeographicAddress()
                //            {
                //                address1 = recipient.deliveryAddress.tbl_address_address1,
                //                address2 = recipient.deliveryAddress.tbl_address_address2,
                //                suburb = recipient.deliveryAddress.tbl_address_suburb,
                //                state = recipient.deliveryAddress.tbl_address_state,
                //                postCode = recipient.deliveryAddress.tbl_address_postcode,
                //                country = recipient.deliveryAddress.tbl_address_country
                //            }
                //        };

                //        Account account = new Account()
                //        {
                //            accountCode = "AUSEXP",
                //            accountHash = "6uR0IkWl8raELuTnZ8Ibdc5UO7YyrvYyjHfzIwdzvTw=",
                //            accountKey = -900000,
                //            accountLedger = "X",
                //            accountName = @"AUSTWAY EXPRESS P/L",
                //            accountState = "NSW",
                //            defaultAddress = "24-32 RAYMOND AVE",
                //            defaultContact = "YUAN VINCENT GAO",
                //            defaultPhoneNo = "0452 188 899",
                //            defaultPostCode = "2036",
                //            defaultState = "NSW",
                //            defaultSuburbName = "MATRAVILLE",
                //            discountLevel = 0,
                //            priceSuppressed = false,
                //            shippingDivision = "AOE"
                //        };

                //        CreateJobRequest.CreateBooking job = new();

                //        job.Job = new();

                //        //job.String_1 = configuration["Allied:SignatureLive"];
                //        job.String_1 = configuration["Allied:SignatureTest"];
                //        job.Job.account = (Account)account;
                //        job.Job.items = alliedItems.ToArray();
                //        job.Job.bookedBy = "Austway";
                //        job.Job.bookedDate = DateTime.Now;
                //        job.Job.cubicWeight = (double)request.tbl_house_volume;
                //        job.Job.instructions = request.tbl_house_deliveryInstructions;
                //        job.Job.itemCount = alliedItems.Count;
                //        job.Job.readyDate = DateTime.Now;
                //        job.Job.serviceLevel = "R";
                //        job.Job.volume = (double)request.tbl_house_volume;
                //        job.Job.weight = (double)request.tbl_house_weight;


                //        job.Job.price = new Price
                //        {
                //            chargeQuantity = alliedItems.Count,
                //            discountClass = "0",
                //            discountRate = 0,
                //            grossPrice = grossAmount,
                //            jobCode = "A",
                //            netPrice = grossAmount,
                //            rateCode = "1",
                //            reason = ""
                //        };

                //        job.Job.jobStops = new JobStop[] { pickupAddress, deliveryAddress };

                //        var aldResult = await _aldRepository.CreateJob(job);

                //        var aldString = JsonConvert.SerializeObject(aldResult.Result);

                //        if (aldResult.IsSuccess)
                //        {
                //            var labelResponse = JsonConvert.DeserializeObject<string>(aldString);

                //            return Ok(new GeneralResponse
                //            {
                //                success = true,
                //                response = 200,
                //                responseDescription = result.DisplayMessage,
                //                referenceNumber = result.ReferenceNumber,
                //                labelData = new LabelData
                //                {
                //                    labelResponse = labelResponse
                //                }
                //            });
                //        }
                //    }
                //    #endregion

                //    #region Fastway
                //    if (request.tbl_house_serviceCode.ToUpper().IndexOf("FW") > -1)
                //    {

                //        List<FWItem> fwItems = new();
                //        foreach (var item in request.houseItems)
                //        {
                //            foreach (var sku in item.itemSkus)
                //            {
                //                var skuCode = await _skuRepository.GetByCodeAsync(sku.tbl_item_sku_code);
                //                fwItems.Add(new FWItem
                //                {
                //                    Reference = skuCode.tbl_item_sku_code,
                //                    Quantity = item.tbl_house_item_qty,
                //                    PackageType = item.tbl_house_item_type,
                //                    WeightDead = Convert.ToInt32(item.tbl_house_item_weight),
                //                    WeightCubic = Convert.ToDouble(item.tbl_house_item_length * item.tbl_house_item_width * item.tbl_house_item_height),
                //                    Length = (int)Math.Ceiling(item.tbl_house_item_length),
                //                    Width = (int)Math.Ceiling(item.tbl_house_item_width),
                //                    Height = (int)Math.Ceiling(item.tbl_house_item_height)
                //                });
                //            }

                //        }

                //        FWAddress address = new()
                //        {
                //            StreetAddress = recipient.deliveryAddress.tbl_address_address1,
                //            AdditionalDetails = recipient.deliveryAddress.tbl_address_address2,
                //            Locality = recipient.deliveryAddress.tbl_address_suburb,
                //            StateOrProvince = recipient.deliveryAddress.tbl_address_state,
                //            PostalCode = recipient.deliveryAddress.tbl_address_postcode,
                //            Country = recipient.deliveryAddress.tbl_address_country
                //        };

                //        FWTo to = new()
                //        {
                //            BusinessName = recipient.tbl_client_header_companyName,
                //            ContactName = recipient.tbl_client_header_contactName,
                //            PhoneNumber = recipient.tbl_client_header_phone,
                //            Email = recipient.tbl_client_header_email,
                //            Address = address
                //        };

                //        FWService service = new()
                //        {
                //            ServiceCode = request.tbl_house_serviceCode,
                //            ServiceItemCode = ""
                //        };

                //        List<FWService> services = new();
                //        services.Add(service);

                //        FWCreateShippingRequest createshippingrequest = new FWCreateShippingRequest()
                //        {
                //            To = to,
                //            Items = fwItems,
                //            Services = services,
                //            InstructionsPrivate = "",
                //            InstructionsPublic = request.tbl_house_deliveryInstructions,
                //            ExternalRef1 = recipient.tbl_client_header_code
                //        };


                //        var fwResult = await _fwRepository.CreateShipmentAsync(createshippingrequest);

                //        var fwString = JsonConvert.SerializeObject(fwResult);



                //        if (fwString.IndexOf("Success") > -1)
                //        {
                //            var fwResponse = JsonConvert.DeserializeObject<CreateShippingResponseSuccess>(fwString);

                //            var labelResult = await _fwRepository.CreateLabelAsync("", "");
                //            var labelString = JsonConvert.SerializeObject(labelResult);

                //            if (labelString.IndexOf("Success") > -1)
                //            {
                //                var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponseSuccess>(labelString);

                //                return Ok(new GeneralResponse
                //                {
                //                    success = true,
                //                    response = 200,
                //                    responseDescription = result.DisplayMessage,
                //                    referenceNumber = result.ReferenceNumber,
                //                    shipmentData = new ShipmentData
                //                    {
                //                        shipmentResponse = fwResponse
                //                    },
                //                    labelData = new LabelData
                //                    {
                //                        labelResponse = labelResponse
                //                    }
                //                });
                //            }
                //        }
                //    }
                //    #endregion

                //    #region Border
                //    if (request.tbl_house_serviceCode.ToUpper().IndexOf("BOR") > -1)
                //    {
                //        string[] states =
                //        {
                //                "NSW","VIC","QLD","WA","NSW"
                //            };

                //        if (recipient.deliveryAddress.tbl_address_country != "AU")
                //        {
                //            return Ok(new GeneralResponse
                //            {
                //                success = true,
                //                response = 200,
                //                responseDescription = result.DisplayMessage,
                //                referenceNumber = result.ReferenceNumber,
                //                shipmentData = new ShipmentData
                //                {
                //                    shipmentResponse = null
                //                },
                //                labelData = new LabelData
                //                {
                //                    labelResponse = new CreateLabelResponse
                //                    {
                //                        Status = "Failed",
                //                        Base64Label = "Border Express is currently not available for non AU delivery."
                //                    }
                //                }
                //            });
                //        }

                //        if (!states.Contains(recipient.deliveryAddress.tbl_address_state))
                //        {
                //            return Ok(new GeneralResponse
                //            {
                //                success = true,
                //                response = 200,
                //                responseDescription = result.DisplayMessage,
                //                referenceNumber = result.ReferenceNumber,
                //                shipmentData = new ShipmentData
                //                {
                //                    shipmentResponse = null
                //                },
                //                labelData = new LabelData
                //                {
                //                    labelResponse = new CreateLabelResponse
                //                    {
                //                        Status = "Failed",
                //                        Base64Label = "Border Express does not support recipient's provided state."
                //                    }
                //                }
                //            });
                //        }
                //        var labelResult = await _borderRepository.CreateLabelAsync(labelItems, recipient);
                //        //var labelString = JsonConvert.SerializeObject(labelResult);
                //        return Ok(new GeneralResponse
                //        {
                //            success = true,
                //            response = 200,
                //            responseDescription = result.DisplayMessage,
                //            referenceNumber = result.ReferenceNumber,
                //            shipmentData = new ShipmentData
                //            {
                //                shipmentResponse = null
                //            },
                //            labelData = new LabelData
                //            {
                //                labelResponse = labelResult
                //            }
                //        });
                //        //if (labelResult.Status == "Success")
                //        //{
                //        //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                //        //    return Ok(new GeneralResponse
                //        //    {
                //        //        success = true,
                //        //        response = 200,
                //        //        responseDescription = result.DisplayMessage,
                //        //        referenceNumber = result.ReferenceNumber,
                //        //        shipmentData = new ShipmentData
                //        //        {
                //        //            shipmentResponse = null
                //        //        },
                //        //        labelData = new LabelData
                //        //        {
                //        //            labelResponse = labelResult
                //        //        }
                //        //    });
                //        //}
                //    }
                //    #endregion

                //    #region NZ
                //    if (request.tbl_house_serviceCode.ToUpper().IndexOf("NZ") > -1)
                //    {
                //        if (recipient.deliveryAddress.tbl_address_country != "NZ")
                //        {
                //            return Ok(new GeneralResponse
                //            {
                //                success = true,
                //                response = 200,
                //                responseDescription = result.DisplayMessage,
                //                referenceNumber = result.ReferenceNumber,
                //                shipmentData = new ShipmentData
                //                {
                //                    shipmentResponse = null
                //                },
                //                labelData = new LabelData
                //                {
                //                    labelResponse = new CreateLabelResponse
                //                    {
                //                        Status = "Failed",
                //                        Base64Label = "NZ Post Truck is currently not available for non NZ delivery."
                //                    }
                //                }
                //            });
                //        }


                //        var labelResult = await _nzRepository.CreateLabelAsync(labelItems, recipient);
                //        //var labelString = JsonConvert.SerializeObject(labelResult);
                //        return Ok(new GeneralResponse
                //        {
                //            success = true,
                //            response = 200,
                //            responseDescription = result.DisplayMessage,
                //            referenceNumber = result.ReferenceNumber,
                //            shipmentData = new ShipmentData
                //            {
                //                shipmentResponse = null
                //            },
                //            labelData = new LabelData
                //            {
                //                labelResponse = labelResult
                //            }
                //        });
                //        //if (labelResult.Status == "Success")
                //        //{
                //        //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                //        //    return Ok(new GeneralResponse
                //        //    {
                //        //        success = true,
                //        //        response = 200,
                //        //        responseDescription = result.DisplayMessage,
                //        //        referenceNumber = result.ReferenceNumber,
                //        //        shipmentData = new ShipmentData
                //        //        {
                //        //            shipmentResponse = null
                //        //        },
                //        //        labelData = new LabelData
                //        //        {
                //        //            labelResponse = labelResult
                //        //        }
                //        //    });
                //        //}
                //    }
                //    #endregion

                //    #region Amazon
                //    if (request.tbl_house_serviceCode.ToUpper().IndexOf("AMA") > -1)
                //    {
                //        if (recipient.deliveryAddress.tbl_address_country != "AU")
                //        {
                //            return Ok(new GeneralResponse
                //            {
                //                success = true,
                //                response = 200,
                //                responseDescription = result.DisplayMessage,
                //                referenceNumber = result.ReferenceNumber,
                //                shipmentData = new ShipmentData
                //                {
                //                    shipmentResponse = null
                //                },
                //                labelData = new LabelData
                //                {
                //                    labelResponse = new CreateLabelResponse
                //                    {
                //                        Status = "Failed",
                //                        Base64Label = "Austway Amazon is currently not available for non AU delivery."
                //                    }
                //                }
                //            });
                //        }

                //        var labelResult = await _amazonRepository.CreateLabelAsync(labelItems, recipient);
                //        //var labelString = JsonConvert.SerializeObject(labelResult);
                //        return Ok(new GeneralResponse
                //        {
                //            success = true,
                //            response = 200,
                //            responseDescription = result.DisplayMessage,
                //            referenceNumber = result.ReferenceNumber,
                //            shipmentData = new ShipmentData
                //            {
                //                shipmentResponse = null
                //            },
                //            labelData = new LabelData
                //            {
                //                labelResponse = labelResult
                //            }
                //        });

                //        //if (labelResult.Status == "Success")
                //        //{
                //        //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                //        //    return Ok(new GeneralResponse
                //        //    {
                //        //        success = true,
                //        //        response = 200,
                //        //        responseDescription = result.DisplayMessage,
                //        //        referenceNumber = result.ReferenceNumber,
                //        //        shipmentData = new ShipmentData
                //        //        {
                //        //            shipmentResponse = null
                //        //        },
                //        //        labelData = new LabelData
                //        //        {
                //        //            labelResponse = labelResult
                //        //        }
                //        //    });
                //        //}
                //    }
                //    #endregion

                //    #region 3PL
                //    if (request.tbl_house_serviceCode.ToUpper().IndexOf("3PL") > -1)
                //    {
                //        if (recipient.deliveryAddress.tbl_address_country != "AU")
                //        {
                //            return Ok(new GeneralResponse
                //            {
                //                success = true,
                //                response = 200,
                //                responseDescription = result.DisplayMessage,
                //                referenceNumber = result.ReferenceNumber,
                //                shipmentData = new ShipmentData
                //                {
                //                    shipmentResponse = null
                //                },
                //                labelData = new LabelData
                //                {
                //                    labelResponse = new CreateLabelResponse
                //                    {
                //                        Status = "Failed",
                //                        Base64Label = "Austway 3PL is currently not available for non AU delivery."
                //                    }
                //                }
                //            });
                //        }

                //        var labelResult = await _austway3plRepository.CreateLabelAsync(labelItems, recipient);
                //        //var labelString = JsonConvert.SerializeObject(labelResult);
                //        return Ok(new GeneralResponse
                //        {
                //            success = true,
                //            response = 200,
                //            responseDescription = result.DisplayMessage,
                //            referenceNumber = result.ReferenceNumber,
                //            shipmentData = new ShipmentData
                //            {
                //                shipmentResponse = null
                //            },
                //            labelData = new LabelData
                //            {
                //                labelResponse = labelResult
                //            }
                //        });
                //        //if (labelResult.Status == "Success")
                //        //{
                //        //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                //        //    return Ok(new GeneralResponse
                //        //    {
                //        //        success = true,
                //        //        response = 200,
                //        //        responseDescription = result.DisplayMessage,
                //        //        referenceNumber = result.ReferenceNumber,
                //        //        shipmentData = new ShipmentData
                //        //        {
                //        //            shipmentResponse = null
                //        //        },
                //        //        labelData = new LabelData
                //        //        {
                //        //            labelResponse = labelResult
                //        //        }
                //        //    });
                //        //}
                //    }
                //    #endregion

                //    #region AUSTWAY
                //    if (request.tbl_house_serviceCode.ToUpper().IndexOf("TRK") > -1)
                //    {
                //        if (recipient.deliveryAddress.tbl_address_country != "AU")
                //        {
                //            return Ok(new GeneralResponse
                //            {
                //                success = true,
                //                response = 200,
                //                responseDescription = result.DisplayMessage,
                //                referenceNumber = result.ReferenceNumber,
                //                shipmentData = new ShipmentData
                //                {
                //                    shipmentResponse = null
                //                },
                //                labelData = new LabelData
                //                {
                //                    labelResponse = new CreateLabelResponse
                //                    {
                //                        Status = "Failed",
                //                        Base64Label = "Austway Truck is currently not available for non AU delivery."
                //                    }
                //                }
                //            });
                //        }

                //        var labelResult = await _austwayTruckRepository.CreateLabelAsync(labelItems, recipient);
                //        //var labelString = JsonConvert.SerializeObject(labelResult);
                //        return Ok(new GeneralResponse
                //        {
                //            success = true,
                //            response = 200,
                //            responseDescription = result.DisplayMessage,
                //            referenceNumber = result.ReferenceNumber,
                //            shipmentData = new ShipmentData
                //            {
                //                shipmentResponse = null
                //            },
                //            labelData = new LabelData
                //            {
                //                labelResponse = labelResult
                //            }
                //        });
                //        //if (labelResult.Status == "Success")
                //        //{
                //        //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                //        //    return Ok(new GeneralResponse
                //        //    {
                //        //        success = true,
                //        //        response = 200,
                //        //        responseDescription = result.DisplayMessage,
                //        //        referenceNumber = result.ReferenceNumber,
                //        //        shipmentData = new ShipmentData
                //        //        {
                //        //            shipmentResponse = null
                //        //        },
                //        //        labelData = new LabelData
                //        //        {
                //        //            labelResponse = labelResult
                //        //        }
                //        //    });
                //        //}
                //    }
                //    #endregion
                */
                if (!result.IsSuccess)
                {
                    return Ok(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = result.DisplayMessage
                    });
                }
                return Ok(new GeneralResponse
                {
                    success = true,
                    response = 200,
                    responseDescription = result.DisplayMessage,
                    referenceNumber = result.ReferenceNumber,
                    shipmentData = null,
                    labelData = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating HOUSE!");
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] tbl_houseDto request, int isWeb = 0)
        {
            try
            {
                if (request.idtbl_house <= 0 && String.IsNullOrEmpty(request.tbl_house_code))
                {
                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = "Mising master id or code."
                    });
                }

                ResponseDto result = new();

                try
                {
                    if (request.tbl_house_code != "" && request.tbl_house_code != null)
                    {
                        result = await _repository.UpdateAsync(request);

                        if (result.IsSuccess)
                        {
                            /*
                            //var jsonString = JsonConvert.SerializeObject(result.Result);
                            var jsonString = JsonConvert.SerializeObject(result.Result, Formatting.None, new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                PreserveReferencesHandling = PreserveReferencesHandling.Objects
                            });
                            var model = JsonConvert.DeserializeObject<tbl_houseDto>(jsonString);

                            List<OrderItem> orderItems = new();
                            List<LabelItem> labelItems = new();
                            double grossAmount = 0.0;

                            foreach (var item in model.houseItems)
                            {
                                foreach (var sku in item.itemSkus)
                                {
                                    var skuCode = await _skuRepository.GetByCodeAsync(sku.tbl_item_sku_code);
                                    orderItems.Add(new OrderItem
                                    {
                                        itemNo = item.idtbl_house_item.ToString(),
                                        sku = skuCode.tbl_item_sku_code,
                                        description = skuCode.tbl_items_description,
                                        originCountry = skuCode.tbl_items_originCountry,
                                        itemCount = item.tbl_house_item_qty,
                                        unitValue = skuCode.tbl_items_value,
                                        weight = skuCode.tbl_items_weight
                                    });

                                    labelItems.Add(new LabelItem
                                    {
                                        ItemId = item.idtbl_house_item,
                                        HouseId = model.idtbl_house,
                                        Weight = sku.tbl_items_weight,
                                        ParcelPallet = request.tbl_house_serviceCode.IndexOf("BOR") > -1 ? (request.tbl_house_serviceCode.ToUpper().IndexOf("EXP") > -1 ? "PAR" : "PAL") : "PAR"
                                    });

                                    grossAmount += Convert.ToDouble(sku.tbl_items_value);
                                }
                            }

                            var consignor = await _addressRepository.GetByReference(model.ConsignorCode);
                            var consignee = await _addressRepository.GetByReference(model.ConsigneeCode);
                            var delivery = await _addressRepository.GetByReference(model.tbl_house_delivery);

                            tbl_client_headerDto shipper = (tbl_client_headerDto)consignor.Result;
                            tbl_client_headerDto recipient = (tbl_client_headerDto)consignee.Result;

                            #region APG
                            if (request.tbl_house_serviceCode.ToUpper().IndexOf("UBI") > -1)
                            {

                                CreateShippingRequest createshippingrequest = new CreateShippingRequest()
                                {
                                    referenceNo = model.tbl_house_code,
                                    trackingNo = "",
                                    serviceCode = request.tbl_house_serviceCode,
                                    incoterm = request.tbl_house_incotermCode,
                                    description = request.tbl_house_description,
                                    nativeDescription = request.tbl_house_native_description,
                                    weight = request.tbl_house_weight,
                                    weightUnit = "",
                                    length = request.tbl_house_length,
                                    width = request.tbl_house_width,
                                    height = request.tbl_house_height,
                                    volume = 1,
                                    dimensionUnit = "cm",
                                    invoiceValue = (decimal)request.tbl_house_value,
                                    invoiceCurrency = request.tbl_house_currency,
                                    pickupType = "",
                                    authorityToLeave = "",
                                    lockerService = "",
                                    batteryType = "",
                                    batteryPacking = "",
                                    dangerousGoods = (request.tbl_house_DG == 1 ? "true" : "false"),
                                    serviceOption = "",
                                    instruction = "",
                                    facility = "",
                                    platform = "",
                                    recipientName = recipient.tbl_client_header_contactName,
                                    recipientCompany = "",
                                    phone = recipient.tbl_client_header_phone,
                                    email = recipient.tbl_client_header_email,
                                    addressLine1 = recipient.deliveryAddress.tbl_address_address1,
                                    addressLine2 = recipient.deliveryAddress.tbl_address_address2,
                                    addressLine3 = "",
                                    city = recipient.deliveryAddress.tbl_address_suburb,
                                    state = recipient.deliveryAddress.tbl_address_state,
                                    postcode = recipient.deliveryAddress.tbl_address_postcode,
                                    country = recipient.deliveryAddress.tbl_address_country,
                                    shipperName = shipper.tbl_client_header_contactName,
                                    shipperPhone = shipper.tbl_client_header_phone,
                                    shipperAddressLine1 = shipper.deliveryAddress.tbl_address_country,
                                    shipperAddressLine2 = shipper.deliveryAddress.tbl_address_state,
                                    shipperAddressLine3 = "",
                                    shipperCity = shipper.deliveryAddress.tbl_address_city,
                                    shipperState = shipper.deliveryAddress.tbl_address_state,
                                    shipperPostcode = shipper.deliveryAddress.tbl_address_postcode,
                                    shipperCountry = shipper.deliveryAddress.tbl_address_country,
                                    returnOption = "",
                                    returnName = "",
                                    returnAddressLine1 = "",
                                    returnAddressLine2 = "",
                                    returnAddressLine3 = "",
                                    returnCity = "",
                                    returnState = "",
                                    returnPostcode = "",
                                    returnCountry = "",
                                    abnnumber = "",
                                    gstexemptioncode = "",
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
                                            responseDescription = result.DisplayMessage,
                                            referenceNumber = result.ReferenceNumber,
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



                                }
                            }
                            #endregion

                            #region Allied
                            if (request.tbl_house_serviceCode.ToUpper().IndexOf("ALD") > -1)
                            {
                                List<Item> alliedItems = new();
                                foreach (var item in request.houseItems)
                                {
                                    foreach (var sku in item.itemSkus)
                                    {
                                        var skuCode = await _skuRepository.GetByCodeAsync(sku.tbl_item_sku_code);
                                        alliedItems.Add(new Item
                                        {
                                            dangerous = false,
                                            length = (int)Math.Ceiling(item.tbl_house_item_length),
                                            width = (int)Math.Ceiling(item.tbl_house_item_width),
                                            height = (int)Math.Ceiling(item.tbl_house_item_height),
                                            itemCount = item.tbl_house_item_qty,
                                            weight = Convert.ToInt32(item.tbl_house_item_weight),
                                            volume = Convert.ToDouble(item.tbl_house_item_length * item.tbl_house_item_width * item.tbl_house_item_height)
                                        });
                                    }

                                }

                                JobStop pickupAddress = new()
                                {
                                    companyName = shipper.tbl_client_header_companyName,
                                    contact = shipper.tbl_client_header_contactName,
                                    phoneNumber = shipper.tbl_client_header_phone,
                                    stopType = "P",
                                    stopNumber = 1,
                                    geographicAddress = new GeographicAddress()
                                    {
                                        address1 = shipper.pickupAddress.tbl_address_address1,
                                        address2 = shipper.pickupAddress.tbl_address_address2,
                                        suburb = shipper.pickupAddress.tbl_address_suburb,
                                        state = shipper.pickupAddress.tbl_address_state,
                                        postCode = shipper.pickupAddress.tbl_address_postcode,
                                        country = shipper.pickupAddress.tbl_address_country
                                    }
                                };

                                JobStop deliveryAddress = new()
                                {
                                    companyName = recipient.tbl_client_header_companyName,
                                    contact = recipient.tbl_client_header_contactName,
                                    phoneNumber = recipient.tbl_client_header_phone,
                                    stopType = "D",
                                    stopNumber = 2,
                                    geographicAddress = new GeographicAddress()
                                    {
                                        address1 = recipient.deliveryAddress.tbl_address_address1,
                                        address2 = recipient.deliveryAddress.tbl_address_address2,
                                        suburb = recipient.deliveryAddress.tbl_address_suburb,
                                        state = recipient.deliveryAddress.tbl_address_state,
                                        postCode = recipient.deliveryAddress.tbl_address_postcode,
                                        country = recipient.deliveryAddress.tbl_address_country
                                    }
                                };

                                Account account = new Account()
                                {
                                    accountCode = "AUSEXP",
                                    accountHash = "6uR0IkWl8raELuTnZ8Ibdc5UO7YyrvYyjHfzIwdzvTw=",
                                    accountKey = -900000,
                                    accountLedger = "X",
                                    accountName = @"AUSTWAY EXPRESS P/L",
                                    accountState = "NSW",
                                    defaultAddress = "24-32 RAYMOND AVE",
                                    defaultContact = "YUAN VINCENT GAO",
                                    defaultPhoneNo = "0452 188 899",
                                    defaultPostCode = "2036",
                                    defaultState = "NSW",
                                    defaultSuburbName = "MATRAVILLE",
                                    discountLevel = 0,
                                    priceSuppressed = false,
                                    shippingDivision = "AOE"
                                };

                                CreateJobRequest.CreateBooking job = new();

                                job.Job = new();

                                //job.String_1 = configuration["Allied:SignatureLive"];
                                job.String_1 = configuration["Allied:SignatureTest"];
                                job.Job.account = (Account)account;
                                job.Job.items = alliedItems.ToArray();
                                job.Job.bookedBy = "Austway";
                                job.Job.bookedDate = DateTime.Now;
                                job.Job.cubicWeight = (double)request.tbl_house_volume;
                                job.Job.instructions = request.tbl_house_deliveryInstructions;
                                job.Job.itemCount = alliedItems.Count;
                                job.Job.readyDate = DateTime.Now;
                                job.Job.serviceLevel = "R";
                                job.Job.volume = (double)request.tbl_house_volume;
                                job.Job.weight = (double)request.tbl_house_weight;


                                job.Job.price = new Price
                                {
                                    chargeQuantity = alliedItems.Count,
                                    discountClass = "0",
                                    discountRate = 0,
                                    grossPrice = grossAmount,
                                    jobCode = "A",
                                    netPrice = grossAmount,
                                    rateCode = "1",
                                    reason = ""
                                };

                                job.Job.jobStops = new JobStop[] { pickupAddress, deliveryAddress };

                                var aldResult = await _aldRepository.CreateJob(job);

                                var aldString = JsonConvert.SerializeObject(aldResult.Result);

                                if (aldResult.IsSuccess)
                                {
                                    var labelResponse = JsonConvert.DeserializeObject<string>(aldString);

                                    return Ok(new GeneralResponse
                                    {
                                        success = true,
                                        response = 200,
                                        responseDescription = result.DisplayMessage,
                                        referenceNumber = result.ReferenceNumber,
                                        labelData = new LabelData
                                        {
                                            labelResponse = labelResponse
                                        }
                                    });
                                }
                            }
                            #endregion

                            #region Fastway
                            if (request.tbl_house_serviceCode.ToUpper().IndexOf("FW") > -1)
                            {

                                List<FWItem> fwItems = new();
                                foreach (var item in request.houseItems)
                                {
                                    foreach (var sku in item.itemSkus)
                                    {
                                        var skuCode = await _skuRepository.GetByCodeAsync(sku.tbl_item_sku_code);
                                        fwItems.Add(new FWItem
                                        {
                                            Reference = skuCode.tbl_item_sku_code,
                                            Quantity = item.tbl_house_item_qty,
                                            PackageType = item.tbl_house_item_type,
                                            WeightDead = Convert.ToInt32(item.tbl_house_item_weight),
                                            WeightCubic = Convert.ToDouble(item.tbl_house_item_length * item.tbl_house_item_width * item.tbl_house_item_height),
                                            Length = (int)Math.Ceiling(item.tbl_house_item_length),
                                            Width = (int)Math.Ceiling(item.tbl_house_item_width),
                                            Height = (int)Math.Ceiling(item.tbl_house_item_height)
                                        });
                                    }

                                }

                                FWAddress address = new()
                                {
                                    StreetAddress = recipient.deliveryAddress.tbl_address_address1,
                                    AdditionalDetails = recipient.deliveryAddress.tbl_address_address2,
                                    Locality = recipient.deliveryAddress.tbl_address_suburb,
                                    StateOrProvince = recipient.deliveryAddress.tbl_address_state,
                                    PostalCode = recipient.deliveryAddress.tbl_address_postcode,
                                    Country = recipient.deliveryAddress.tbl_address_country
                                };

                                FWTo to = new()
                                {
                                    BusinessName = recipient.tbl_client_header_companyName,
                                    ContactName = recipient.tbl_client_header_contactName,
                                    PhoneNumber = recipient.tbl_client_header_phone,
                                    Email = recipient.tbl_client_header_email,
                                    Address = address
                                };

                                FWService service = new()
                                {
                                    ServiceCode = request.tbl_house_serviceCode,
                                    ServiceItemCode = ""
                                };

                                List<FWService> services = new();
                                services.Add(service);

                                FWCreateShippingRequest createshippingrequest = new FWCreateShippingRequest()
                                {
                                    To = to,
                                    Items = fwItems,
                                    Services = services,
                                    InstructionsPrivate = "",
                                    InstructionsPublic = request.tbl_house_deliveryInstructions,
                                    ExternalRef1 = recipient.tbl_client_header_code
                                };


                                var fwResult = await _fwRepository.CreateShipmentAsync(createshippingrequest);

                                var fwString = JsonConvert.SerializeObject(fwResult);



                                if (fwString.IndexOf("Success") > -1)
                                {
                                    var fwResponse = JsonConvert.DeserializeObject<CreateShippingResponseSuccess>(fwString);

                                    var labelResult = await _fwRepository.CreateLabelAsync("", "");
                                    var labelString = JsonConvert.SerializeObject(labelResult);

                                    if (labelString.IndexOf("Success") > -1)
                                    {
                                        var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponseSuccess>(labelString);

                                        return Ok(new GeneralResponse
                                        {
                                            success = true,
                                            response = 200,
                                            responseDescription = result.DisplayMessage,
                                            referenceNumber = result.ReferenceNumber,
                                            shipmentData = new ShipmentData
                                            {
                                                shipmentResponse = fwResponse
                                            },
                                            labelData = new LabelData
                                            {
                                                labelResponse = labelResponse
                                            }
                                        });
                                    }
                                }
                            }
                            #endregion

                            #region Border
                            if (request.tbl_house_serviceCode.ToUpper().IndexOf("BOR") > -1)
                            {
                                string[] states =
                                {
                                "NSW","VIC","QLD","WA","NSW"
                            };

                                if (recipient.deliveryAddress.tbl_address_country != "AU")
                                {
                                    return Ok(new GeneralResponse
                                    {
                                        success = true,
                                        response = 200,
                                        responseDescription = result.DisplayMessage,
                                        referenceNumber = result.ReferenceNumber,
                                        shipmentData = new ShipmentData
                                        {
                                            shipmentResponse = null
                                        },
                                        labelData = new LabelData
                                        {
                                            labelResponse = new CreateLabelResponse
                                            {
                                                Status = "Failed",
                                                Base64Label = "Border Express is currently not available for non AU delivery."
                                            }
                                        }
                                    });
                                }

                                if (!states.Contains(recipient.deliveryAddress.tbl_address_state))
                                {
                                    return Ok(new GeneralResponse
                                    {
                                        success = true,
                                        response = 200,
                                        responseDescription = result.DisplayMessage,
                                        referenceNumber = result.ReferenceNumber,
                                        shipmentData = new ShipmentData
                                        {
                                            shipmentResponse = null
                                        },
                                        labelData = new LabelData
                                        {
                                            labelResponse = new CreateLabelResponse
                                            {
                                                Status = "Failed",
                                                Base64Label = "Border Express does not support recipient's provided state."
                                            }
                                        }
                                    });
                                }
                                var labelResult = await _borderRepository.CreateLabelAsync(labelItems, recipient);
                                //var labelString = JsonConvert.SerializeObject(labelResult);
                                return Ok(new GeneralResponse
                                {
                                    success = true,
                                    response = 200,
                                    responseDescription = result.DisplayMessage,
                                    referenceNumber = result.ReferenceNumber,
                                    shipmentData = new ShipmentData
                                    {
                                        shipmentResponse = null
                                    },
                                    labelData = new LabelData
                                    {
                                        labelResponse = labelResult
                                    }
                                });
                                //if (labelResult.Status == "Success")
                                //{
                                //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                                //    return Ok(new GeneralResponse
                                //    {
                                //        success = true,
                                //        response = 200,
                                //        responseDescription = result.DisplayMessage,
                                //        referenceNumber = result.ReferenceNumber,
                                //        shipmentData = new ShipmentData
                                //        {
                                //            shipmentResponse = null
                                //        },
                                //        labelData = new LabelData
                                //        {
                                //            labelResponse = labelResult
                                //        }
                                //    });
                                //}
                            }
                            #endregion

                            #region NZ
                            if (request.tbl_house_serviceCode.ToUpper().IndexOf("NZ") > -1)
                            {
                                if (recipient.deliveryAddress.tbl_address_country != "NZ")
                                {
                                    return Ok(new GeneralResponse
                                    {
                                        success = true,
                                        response = 200,
                                        responseDescription = result.DisplayMessage,
                                        referenceNumber = result.ReferenceNumber,
                                        shipmentData = new ShipmentData
                                        {
                                            shipmentResponse = null
                                        },
                                        labelData = new LabelData
                                        {
                                            labelResponse = new CreateLabelResponse
                                            {
                                                Status = "Failed",
                                                Base64Label = "NZ Post Truck is currently not available for non NZ delivery."
                                            }
                                        }
                                    });
                                }


                                var labelResult = await _nzRepository.CreateLabelAsync(labelItems, recipient);
                                //var labelString = JsonConvert.SerializeObject(labelResult);
                                return Ok(new GeneralResponse
                                {
                                    success = true,
                                    response = 200,
                                    responseDescription = result.DisplayMessage,
                                    referenceNumber = result.ReferenceNumber,
                                    shipmentData = new ShipmentData
                                    {
                                        shipmentResponse = null
                                    },
                                    labelData = new LabelData
                                    {
                                        labelResponse = labelResult
                                    }
                                });
                                //if (labelResult.Status == "Success")
                                //{
                                //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                                //    return Ok(new GeneralResponse
                                //    {
                                //        success = true,
                                //        response = 200,
                                //        responseDescription = result.DisplayMessage,
                                //        referenceNumber = result.ReferenceNumber,
                                //        shipmentData = new ShipmentData
                                //        {
                                //            shipmentResponse = null
                                //        },
                                //        labelData = new LabelData
                                //        {
                                //            labelResponse = labelResult
                                //        }
                                //    });
                                //}
                            }
                            #endregion

                            #region Amazon
                            if (request.tbl_house_serviceCode.ToUpper().IndexOf("AMA") > -1)
                            {
                                if (recipient.deliveryAddress.tbl_address_country != "AU")
                                {
                                    return Ok(new GeneralResponse
                                    {
                                        success = true,
                                        response = 200,
                                        responseDescription = result.DisplayMessage,
                                        referenceNumber = result.ReferenceNumber,
                                        shipmentData = new ShipmentData
                                        {
                                            shipmentResponse = null
                                        },
                                        labelData = new LabelData
                                        {
                                            labelResponse = new CreateLabelResponse
                                            {
                                                Status = "Failed",
                                                Base64Label = "Austway Amazon is currently not available for non AU delivery."
                                            }
                                        }
                                    });
                                }

                                var labelResult = await _amazonRepository.CreateLabelAsync(labelItems, recipient);
                                //var labelString = JsonConvert.SerializeObject(labelResult);
                                return Ok(new GeneralResponse
                                {
                                    success = true,
                                    response = 200,
                                    responseDescription = result.DisplayMessage,
                                    referenceNumber = result.ReferenceNumber,
                                    shipmentData = new ShipmentData
                                    {
                                        shipmentResponse = null
                                    },
                                    labelData = new LabelData
                                    {
                                        labelResponse = labelResult
                                    }
                                });

                                //if (labelResult.Status == "Success")
                                //{
                                //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                                //    return Ok(new GeneralResponse
                                //    {
                                //        success = true,
                                //        response = 200,
                                //        responseDescription = result.DisplayMessage,
                                //        referenceNumber = result.ReferenceNumber,
                                //        shipmentData = new ShipmentData
                                //        {
                                //            shipmentResponse = null
                                //        },
                                //        labelData = new LabelData
                                //        {
                                //            labelResponse = labelResult
                                //        }
                                //    });
                                //}
                            }
                            #endregion

                            #region 3PL
                            if (request.tbl_house_serviceCode.ToUpper().IndexOf("3PL") > -1)
                            {
                                if (recipient.deliveryAddress.tbl_address_country != "AU")
                                {
                                    return Ok(new GeneralResponse
                                    {
                                        success = true,
                                        response = 200,
                                        responseDescription = result.DisplayMessage,
                                        referenceNumber = result.ReferenceNumber,
                                        shipmentData = new ShipmentData
                                        {
                                            shipmentResponse = null
                                        },
                                        labelData = new LabelData
                                        {
                                            labelResponse = new CreateLabelResponse
                                            {
                                                Status = "Failed",
                                                Base64Label = "Austway 3PL is currently not available for non AU delivery."
                                            }
                                        }
                                    });
                                }

                                var labelResult = await _austway3plRepository.CreateLabelAsync(labelItems, recipient);
                                //var labelString = JsonConvert.SerializeObject(labelResult);
                                return Ok(new GeneralResponse
                                {
                                    success = true,
                                    response = 200,
                                    responseDescription = result.DisplayMessage,
                                    referenceNumber = result.ReferenceNumber,
                                    shipmentData = new ShipmentData
                                    {
                                        shipmentResponse = null
                                    },
                                    labelData = new LabelData
                                    {
                                        labelResponse = labelResult
                                    }
                                });
                                //if (labelResult.Status == "Success")
                                //{
                                //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                                //    return Ok(new GeneralResponse
                                //    {
                                //        success = true,
                                //        response = 200,
                                //        responseDescription = result.DisplayMessage,
                                //        referenceNumber = result.ReferenceNumber,
                                //        shipmentData = new ShipmentData
                                //        {
                                //            shipmentResponse = null
                                //        },
                                //        labelData = new LabelData
                                //        {
                                //            labelResponse = labelResult
                                //        }
                                //    });
                                //}
                            }
                            #endregion

                            #region AUSTWAY
                            if (request.tbl_house_serviceCode.ToUpper().IndexOf("TRK") > -1)
                            {
                                if (recipient.deliveryAddress.tbl_address_country != "AU")
                                {
                                    return Ok(new GeneralResponse
                                    {
                                        success = true,
                                        response = 200,
                                        responseDescription = result.DisplayMessage,
                                        referenceNumber = result.ReferenceNumber,
                                        shipmentData = new ShipmentData
                                        {
                                            shipmentResponse = null
                                        },
                                        labelData = new LabelData
                                        {
                                            labelResponse = new CreateLabelResponse
                                            {
                                                Status = "Failed",
                                                Base64Label = "Austway Truck is currently not available for non AU delivery."
                                            }
                                        }
                                    });
                                }

                                var labelResult = await _austwayTruckRepository.CreateLabelAsync(labelItems, recipient);
                                //var labelString = JsonConvert.SerializeObject(labelResult);
                                return Ok(new GeneralResponse
                                {
                                    success = true,
                                    response = 200,
                                    responseDescription = result.DisplayMessage,
                                    referenceNumber = result.ReferenceNumber,
                                    shipmentData = new ShipmentData
                                    {
                                        shipmentResponse = null
                                    },
                                    labelData = new LabelData
                                    {
                                        labelResponse = labelResult
                                    }
                                });
                                //if (labelResult.Status == "Success")
                                //{
                                //    //var labelResponse = JsonConvert.DeserializeObject<CreateLabelResponse>(labelString);

                                //    return Ok(new GeneralResponse
                                //    {
                                //        success = true,
                                //        response = 200,
                                //        responseDescription = result.DisplayMessage,
                                //        referenceNumber = result.ReferenceNumber,
                                //        shipmentData = new ShipmentData
                                //        {
                                //            shipmentResponse = null
                                //        },
                                //        labelData = new LabelData
                                //        {
                                //            labelResponse = labelResult
                                //        }
                                //    });
                                //}
                            }
                            #endregion
                            */
                            return Ok(new GeneralResponse
                            {
                                success = true,
                                response = 200,
                                responseDescription = result.DisplayMessage,
                                referenceNumber = result.ReferenceNumber,
                                shipmentData = null,
                                labelData = null
                            });
                        }

                        return new JsonResult(new GeneralResponse
                        {
                            success = false,
                            response = 500,
                            responseDescription = result.DisplayMessage
                        });
                    }

                    return new JsonResult(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = "Missing/Invalid HOUSE id or number."
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
                    response = 500,
                    responseDescription = ex.Message.ToString(),
                    success = false
                });
            }
        }

        [HttpPost]
        [Route("LinkToMaster")]
        public async Task<IActionResult> LinkToMasterAsync([FromBody] LinkToMasterRequest request)
        {
            try
            {
                if (request.master != null)
                {
                    var parent = await _masterRepository.CreateAsync(request.master, Request.Headers["shipperId"]);
                    if (parent.IsSuccess)
                    {
                        request.parentReference = parent.ReferenceNumber;
                    }
                }
                var response = await _repository.LinkToMasterAsync(request);
                if (response.IsSuccess)
                {
                    if (response.DisplayMessage == "failed")
                    {
                        response.DisplayMessage = "Failed updating record.";
                    }
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("LinkToContainer")]
        public async Task<IActionResult> LinkToContainerAsync([FromBody] LinkToContainerRequest request)
        {
            try
            {
                if (request.container != null)
                {
                    var parent = await _containerRepository.CreateAsync(request.container, Request.Headers["shipperId"]);
                    if (parent.IsSuccess)
                    {
                        request.parentReference = parent.ReferenceNumber;
                    }
                }
                var response = await _repository.LinkToContainerAsync(request);
                if (response.IsSuccess)
                {
                    if (response.DisplayMessage == "failed")
                    {
                        response.DisplayMessage = "Failed updating record.";
                    }
                }
                return Ok(response);
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

        //Added by HS on 13/01/2023
        //Get the consignee(client_header) reference of the consolidation house using its house bill number
        [HttpGet]
        [Route("getbybillnumber")]
        public async Task<IActionResult> GetByBillNumberAsync(string billNumber)
        {
            try
            {
                ResponseDto result = new();
                try
                {
                    result = await _repository.GetByBillNumber(billNumber);
                    if (result.IsSuccess)
                    {
                        return Ok(new GeneralResponse
                        {
                            success = true,
                            response = 200,
                            referenceNumber = result.ReferenceNumber,
                            responseDescription = "Consol Consignee RefNo:" + result.ReferenceNumber
                        });
                    }
                    return Ok(new GeneralResponse
                    {
                        success = false,
                        response = 500,
                        responseDescription = result.DisplayMessage
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

        [HttpGet]
        [Route("getbymaster")]
        public async Task<IActionResult> GetByMasterAsync(string referenceNumber)
        {
            try
            {
                try
                {
                    var response = await _repository.GetByMaster(referenceNumber);

                    return Ok(response);
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

        [HttpGet]
        [Route("getbycontainer")]
        public async Task<IActionResult> GetByContainerAsync(string referenceNumber)
        {
            try
            {
                try
                {
                    var response = await _repository.GetByContainer(referenceNumber);

                    return Ok(response);
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

        private string Barcode39(string barcode)
        {
            string result;
            using (MemoryStream ms = new MemoryStream())
            {
                //The Image is drawn based on length of Barcode text.
                using (Bitmap bitMap = new Bitmap(barcode.Length * 40, 80))
                {
                    //The Graphics library object is generated for the Image.
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        //The installed Barcode font.
                        Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                        PointF point = new PointF(2f, 2f);

                        //White Brush is used to fill the Image with white color.
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                        //Black Brush is used to draw the Barcode over the Image.
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                    }

                    //The Bitmap is saved to Memory Stream.
                    //bitMap.Save(ms, ImageFormat.Png);
                    bitMap.Save(ms, ImageFormat.Png);
                    bitMap.Dispose();


                    //The Image is finally converted to Base64 string.
                    result = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    ms.Close();
                }
            }
            return result;
        }
    }
}
