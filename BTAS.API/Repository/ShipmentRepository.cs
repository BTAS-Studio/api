using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using BTAS.API.Repository.SearchRepository;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class ShipmentRepository : SRepository, IRepository<tbl_shipmentDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public ShipmentRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all shippers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_shipmentDto>> GetAllAsync()
        {
            var result = await _context.tbl_shipments.OrderByDescending(s => s.idtbl_shipment).ToListAsync();
            return _mapper.Map<IEnumerable<tbl_shipmentDto>>(result);
        }

        public async Task<IEnumerable<tbl_shipmentDto>> GetAllAsyncWithChildren()
        {
            var result = await _context.tbl_shipments.OrderByDescending(s => s.idtbl_shipment)
                .Include(s => s.shipmentItems)
                .Include(p => p.notes)
                .Include(p => p.documents)
                .Include(p => p.incoterm)
                .Include(p => p.milestoneLinks)
                .ToListAsync();
            return _mapper.Map<IEnumerable<tbl_shipmentDto>>(result);
        }

        //Added by HS on 22/05/2023
        /// <summary>
        /// Retrieves a specified number of shipments according to input conditions(>, >=, <, <=, ==, !=, and contains)
        /// </summary>
        /// <returns> A list of shipment objects including their linked parent receptacles</returns>
        public async Task<IEnumerable<tbl_shipmentDto>> GetFilteredAsync(CustomFilters<tbl_shipmentDto> customFilters)
        {
            try
            {
                var qList = _context.tbl_shipments
                    .Include(x => x.receptacle)
                    .AsNoTracking()
                    .OrderByDescending(x => x.idtbl_shipment)
                    .AsQueryable();
                // excute each filter one by one 
                if (customFilters.Filters != null)
                {
                    foreach (var filter in customFilters.Filters)
                    {
                        PropertyInfo propertyInfo = null;
                        bool parent = false;
                        var jsonString = JsonConvert.SerializeObject(filter.searchField);
                        var jsonObj = JObject.Parse(jsonString);
                        JToken originalValue = null;

                        if (filter.tableName.ToUpper() == "SHIPMENT")
                        {
                            filter.tableName = "shipment";
                            bool containsDateTime = false;
                            //used for searching Contains DateTime type's columns
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeShipmentJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) =
                                GetPropertyInfo<tbl_shipmentDto, tbl_shipment>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "RECEPTACLE")
                        {
                            filter.tableName = "receptacle";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                                (containsDateTime, jsonString) = MakeReceptacleJsonString(filter, containsDateTime, jsonString);
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) =
                                GetParentPropertyInfo<tbl_shipment, tbl_receptacle, tbl_receptacleDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else if (filter.tableName.ToUpper() == "INCOTERM")
                        {
                            filter.tableName = "incoterm";
                            parent = true;
                            bool containsDateTime = false;
                            if (filter.condition.ToUpper() == "CONTAINS")
                            {
                                originalValue = jsonObj[filter.fieldName];
                            }

                            (propertyInfo, filter.fieldValue, containsDateTime) =
                                GetParentPropertyInfo<tbl_shipment, tbl_incoterm, tbl_incotermDto>(jsonString, propertyInfo, filter, containsDateTime, originalValue);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid table name: {filter.tableName}");
                        }

                        Type elementType = qList.ElementType;

                        if (propertyInfo == null)
                        {
                            throw new ArgumentException($"Invalid property name: {propertyInfo.Name}");
                        }

                        Expression<Func<tbl_shipment, bool>> propertyLambda = null;
                        propertyLambda = GetPropertyLambda<tbl_shipment>(propertyInfo, filter, parent);

                        if (propertyLambda != null)
                        {
                            qList = qList.Where(propertyLambda);
                        }
                    }
                }

                if (qList.Count() == 0)
                {
                    return null;
                }
                var filtered = await qList.Skip(customFilters.Page * customFilters.PageSize).Take(customFilters.PageSize).ToListAsync();
                return _mapper.Map<IEnumerable<tbl_shipmentDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves a single shipper based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_shipmentDto> GetByIdAsync(int id)
        {

            var result = await _context.tbl_shipments.SingleOrDefaultAsync(x => x.idtbl_shipment == id);

            return _mapper.Map<tbl_shipmentDto>(result);

        }

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild = false)
        {
            try
            {
                tbl_shipment result = new();
                if (includeChild)
                {
                    result = await _context.tbl_shipments
                        .Include(c => c.shipmentItems)
                        .Include(p => p.notes)
                        .Include(p => p.documents)
                        .Include(p => p.incoterm)
                        .Include(p => p.milestoneLinks)
                        .SingleOrDefaultAsync(x => x.tbl_shipment_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_shipments
                        .SingleOrDefaultAsync(x => x.tbl_shipment_code == referenceNumber);
                }

                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_shipment_code,
                    DisplayMessage = "Success",
                    Result = _mapper.Map<tbl_shipmentDto>(result)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.StackTrace.ToString() },
                    DisplayMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// Creates/updates a shipper record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_shipmentDto> CreateUpdateAsync(tbl_shipmentDto entity)
        {
            var shipment = _mapper.Map<tbl_shipmentDto, tbl_shipment>(entity);
            if (!String.IsNullOrEmpty(shipment.ReceptacleCode))
            {
                var parent = await _context.tbl_receptacles.SingleOrDefaultAsync(p => p.tbl_receptacle_code == shipment.ReceptacleCode);
                if (parent != null)
                {
                    shipment.tbl_receptacle_id = parent.idtbl_receptacle;
                }
            }
            if (!String.IsNullOrEmpty(shipment.IncotermsCode))
            {
                var parent = await _context.tbl_incoterms.SingleOrDefaultAsync(p => p.tbl_incoterm_code == shipment.IncotermsCode);
                if (parent != null)
                {
                    shipment.tbl_incoterms_id = parent.idtbl_incoterm;
                }
            }
            if (shipment.idtbl_shipment > 0)
            {
                _context.tbl_shipments.Update(shipment);
            }
            else
            {
                _context.tbl_shipments.Add(shipment);
            }
            await _context.SaveChangesAsync();

            return _mapper.Map<tbl_shipmentDto>(shipment);
        }

        /// <summary>
        /// Creates a shipment record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_shipmentDto entity)
        {
            try
            {
                entity.tbl_shipment_createdDate = DateTime.Now;
                entity.tbl_shipment_status = "OPEN";
                var result = _mapper.Map<tbl_shipmentDto, tbl_shipment>(entity);

                if (result.idtbl_shipment > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate shipment record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (!String.IsNullOrEmpty(result.ReceptacleCode))
                    {
                        var parent = await _context.tbl_receptacles.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_receptacle_code == result.ReceptacleCode);
                        if (parent != null)
                        {
                            result.tbl_receptacle_id = parent.idtbl_receptacle;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link to receptacle. Provided receptacle reference was not found.",
                                IsSuccess = false
                            };
                        }

                    }
                    if (!String.IsNullOrEmpty(result.IncotermsCode))
                    {
                        var parent = await _context.tbl_incoterms.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_incoterm_code == result.IncotermsCode);
                        if (parent != null)
                        {
                            result.tbl_incoterms_id = parent.idtbl_incoterm;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to incoterm. Provided incoterm reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }

                    await _context.tbl_shipments.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        DisplayMessage = "Shipment Item successfully added.",
                        IsSuccess = true,
                        ReferenceNumber = result.tbl_shipment_code
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = ex.Message.ToString()
                };
            }
        }


            /// <summary>
            /// Updates a shipment record
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            public async Task<ResponseDto> UpdateAsync(tbl_shipmentDto entity)
        {
            try
            {
                var result = await _context.tbl_shipments
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_shipment_code == entity.tbl_shipment_code);
                if (result != null)
                {
                    _mapper.Map(entity, result);
                    if (!String.IsNullOrEmpty(entity.ReceptacleCode))
                    {
                        var parent = await _context.tbl_receptacles
                        .FirstOrDefaultAsync(x => x.tbl_receptacle_code == entity.ReceptacleCode);

                        if (parent != null)
                        {
                            result.tbl_receptacle_id = parent.idtbl_receptacle;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to Shipment. Invalid shipment id or code.",
                                IsSuccess = false
                            };
                        }
                    }
                    if (!String.IsNullOrEmpty(entity.IncotermCode))
                    {
                        var parent = await _context.tbl_incoterms.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.tbl_incoterm_code == entity.IncotermCode);
                        if (parent != null)
                        {
                            result.tbl_incoterms_id = parent.idtbl_incoterm;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                DisplayMessage = "Unable to link to incoterm. Provided incoterm reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    _context.ChangeTracker.Clear();
                    _context.tbl_shipments.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        DisplayMessage = "Shipment does not exist.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    DisplayMessage = "Shipment successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_shipment_code
                };
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().ToString().IndexOf("Duplicate") > -1)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to save record. Possible duplicate SKU code.",
                        IsSuccess = false
                    };
                }
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.StackTrace.ToString(),
                    IsSuccess = false
                };
            }

        }

        /// <summary>
        /// Deletes existing shipper record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var shipment = await _context.tbl_shipments.FirstOrDefaultAsync(x => x.idtbl_shipment == id);
                if (shipment == null)
                {
                    return false;
                };
                _context.tbl_shipments.Remove(shipment);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Repository to process shipment search request
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="shipper"></param>
        /// <param name="tracking"></param>
        /// <param name="shipperName"></param>
        /// <param name="carrierName"></param>
        /// <param name="deliveryName"></param>
        /// <param name="isManifested"></param>
        /// <returns>
        /// tbl_shipment_searchDto class
        /// </returns>
        public async Task<IEnumerable<tbl_shipment_searchDto>> SearchShipmentAsync(string dateFrom = null, string dateTo = null, string shipper = null,
            string tracking = null, string shipperName = null, string carrierName = null, string deliveryName = null, int isManifested = 0)
        {
            try
            {
                string StoredProc = string.Format("call SearchShipment({0},{1},{2},{3},{4},{5},{6})",
                (dateFrom == "" ? "null" : string.Concat("'", dateFrom, "'")), (dateTo == "" ? "null" : string.Concat("'", dateTo, "'")), (shipper == "" ? "null" : string.Concat("'", shipper, "'")),
                (tracking == "" ? "null" : string.Concat("'", tracking, "'")), (shipperName == "" ? "null" : string.Concat("'", shipperName, "'")),
                (carrierName == "" ? "null" : string.Concat("'", carrierName, "'")), (deliveryName == "" ? "null" : string.Concat("'", deliveryName, "'")));

                var result = await _context.Set<tbl_shipment_search_response>().FromSqlRaw(StoredProc).ToListAsync<tbl_shipment_search_response>();
                if (isManifested == 1)
                    result.RemoveAll(x => x.manifestId == null);

                return _mapper.Map<IEnumerable<tbl_shipment_searchDto>>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Repository to process Shipment Details request
        /// </summary>
        /// <param name="jobNumber"></param>
        /// <param name="shipperId"></param>
        /// <returns>
        /// ShipmentDetailsResponse class
        /// </returns>
        public async Task<ShipmentDetails> GetShipmentDetails(string jobNumber, string shipperId)
        {
            try
            {
                string StoredProc = string.Format("call GetShipmentDetails('{0}','{1}')", jobNumber, shipperId);

                var result = await _context.Set<ShipmentDetailsResponse>().FromSqlRaw(StoredProc).ToListAsync<ShipmentDetailsResponse>();


                ShipmentDetails response = new();

                if (result != null)
                {
                    response.idshippers_tracking_ref = result[0].idshippers_tracking_ref;
                    response.tbl_shippers_tracking_createDate = result[0].tbl_shippers_tracking_createDate;
                    response.tbl_shippers_tracking_shipmentId = result[0].tbl_shippers_tracking_shipmentId;
                    response.tbl_shippers_tracking_prefix = result[0].tbl_shippers_tracking_prefix;
                    response.tbl_shippers_tracking_batch_id = result[0].tbl_shippers_tracking_batch_id;
                    response.tbl_shippers_tracking_est_cost = result[0].tbl_shippers_tracking_est_cost;
                    response.idtbl_parcel_info = result[0].idtbl_parcel_info;
                    response.tbl_parcel_info_batchId = result[0].tbl_parcel_info_batchId;
                    response.tbl_parcel_info_shipperId = result[0].tbl_parcel_info_shipperId;
                    response.tbl_parcel_info_trackingNo = result[0].tbl_parcel_info_trackingNo;
                    response.tbl_parcel_info_referenceNo = result[0].tbl_parcel_info_referenceNo;
                    response.tbl_parcel_info_deliveryAddressLine1 = result[0].tbl_parcel_info_deliveryAddressLine1;
                    response.tbl_parcel_info_deliveryAddressLine2 = result[0].tbl_parcel_info_deliveryAddressLine2;
                    response.tbl_parcel_info_deliveryAddressLine3 = result[0].tbl_parcel_info_deliveryAddressLine3;
                    response.tbl_parcel_info_deliveryCity = result[0].tbl_parcel_info_deliveryCity;
                    response.tbl_parcel_info_deliveryCountry = result[0].tbl_parcel_info_deliveryCountry;
                    response.tbl_parcel_info_description = result[0].tbl_parcel_info_description;
                    response.tbl_parcel_info_nativeDescription = result[0].tbl_parcel_info_nativeDescription;
                    response.tbl_parcel_info_deliveryEmail = result[0].tbl_parcel_info_deliveryEmail;
                    response.tbl_parcel_info_facility = result[0].tbl_parcel_info_facility;
                    response.tbl_parcel_info_instruction = result[0].tbl_parcel_info_instruction;
                    response.tbl_parcel_info_invoiceCurrency = result[0].tbl_parcel_info_invoiceCurrency;
                    response.tbl_parcel_info_invoiceValue = result[0].tbl_parcel_info_invoiceValue;
                    response.tbl_parcel_info_phone = result[0].tbl_parcel_info_phone;
                    response.tbl_parcel_info_platform = result[0].tbl_parcel_info_platform;
                    response.tbl_parcel_info_deliverySuburb = result[0].tbl_parcel_info_deliverySuburb;
                    response.tbl_parcel_info_deliveryPostcode = result[0].tbl_parcel_info_deliveryPostcode;
                    response.tbl_parcel_info_deliveryCompany = result[0].tbl_parcel_info_deliveryCompany;
                    response.tbl_parcel_info_deliveryName = result[0].tbl_parcel_info_deliveryName;
                    response.tbl_parcel_info_serviceCode = result[0].tbl_parcel_info_serviceCode;
                    response.tbl_parcel_info_serviceOption = result[0].tbl_parcel_info_serviceOption;
                    response.tbl_parcel_info_deliveryState = result[0].tbl_parcel_info_deliveryState;
                    response.tbl_parcel_info_shipperName = result[0].tbl_parcel_info_shipperName;
                    response.tbl_parcel_info_shipperAddressLine1 = result[0].tbl_parcel_info_shipperAddressLine1;
                    response.tbl_parcel_info_shipperAddressLine2 = result[0].tbl_parcel_info_shipperAddressLine2;
                    response.tbl_parcel_info_shipperAddressLine3 = result[0].tbl_parcel_info_shipperAddressLine3;
                    response.tbl_parcel_info_shipperCity = result[0].tbl_parcel_info_shipperCity;
                    response.tbl_parcel_info_shipperState = result[0].tbl_parcel_info_shipperState;
                    response.tbl_parcel_info_shipperPostcode = result[0].tbl_parcel_info_shipperPostcode;
                    response.tbl_parcel_info_shipperCountry = result[0].tbl_parcel_info_shipperCountry;
                    response.tbl_parcel_info_shipperPhone = result[0].tbl_parcel_info_shipperPhone;
                    response.tbl_parcel_info_authorityToLeave = result[0].tbl_parcel_info_authorityToLeave;
                    response.tbl_parcel_info_incoterm = result[0].tbl_parcel_info_incoterm;
                    response.tbl_parcel_info_vendorid = result[0].tbl_parcel_info_vendorid;
                    response.tbl_parcel_info_gstexemptioncode = result[0].tbl_parcel_info_gstexemptioncode;
                    response.tbl_parcel_info_abnnumber = result[0].tbl_parcel_info_abnnumber;
                    response.tbl_parcel_info_sortCode = result[0].tbl_parcel_info_sortCode;
                    response.tbl_parcel_info_coveramount = result[0].tbl_parcel_info_coveramount;
                    response.tbl_parcel_info_orderItems = result[0].tbl_parcel_info_orderItems;
                    response.tbl_parcel_info_deliveryInstructions = result[0].tbl_parcel_info_deliveryInstructions;
                    response.tbl_parcel_info_lockerService = result[0].tbl_parcel_info_lockerService;
                    response.tbl_parcel_info_returnName = result[0].tbl_parcel_info_returnName;
                    response.tbl_parcel_info_returnAddress1 = result[0].tbl_parcel_info_returnAddress1;
                    response.tbl_parcel_info_returnAddress2 = result[0].tbl_parcel_info_returnAddress2;
                    response.tbl_parcel_info_returnAddress3 = result[0].tbl_parcel_info_returnAddress3;
                    response.tbl_parcel_info_returnCity = result[0].tbl_parcel_info_returnCity;
                    response.tbl_parcel_info_returnState = result[0].tbl_parcel_info_returnState;
                    response.tbl_parcel_info_returnPostcode = result[0].tbl_parcel_info_returnPostcode;
                    response.tbl_parcel_info_returnCountry = result[0].tbl_parcel_info_returnCountry;
                    response.tbl_parcel_info_returnOption = result[0].tbl_parcel_info_returnOption;
                    response.tbl_parcel_info_shipperEmail = result[0].tbl_parcel_info_shipperEmail;
                    response.tbl_parcel_info_shipment = result[0].tbl_parcel_info_shipment;
                    response.tbl_parcel_info_deliveryContact = result[0].tbl_parcel_info_deliveryContact;
                    response.tbl_parcel_info_deliveryContactPhone = result[0].tbl_parcel_info_deliveryContactPhone;
                    response.tbl_parcel_info_deliveryContactEmail = result[0].tbl_parcel_info_deliveryContactEmail;
                    response.tbl_parcel_info_shipperSuburb = result[0].tbl_parcel_info_shipperSuburb;
                    response.tbl_parcel_info_deliveryPhone = result[0].tbl_parcel_info_deliveryPhone;
                    response.tbl_parcel_info_shipperInstructions = result[0].tbl_parcel_info_shipperInstructions;
                    response.tbl_parcel_info_shipperContact = result[0].tbl_parcel_info_shipperContact;
                    response.tbl_parcel_info_warehouse = result[0].tbl_parcel_info_warehouse;
                    response.tbl_parcel_info_timestamp = result[0].tbl_parcel_info_timestamp;
                    response.tbl_parcel_info_readyDate = result[0].tbl_parcel_info_readyDate;
                    response.tbl_parcel_info_dg = result[0].tbl_parcel_info_dg;
                    response.tbl_parcel_info_dgClass = result[0].tbl_parcel_info_dgClass;
                    response.tbl_parcel_info_dgUn = result[0].tbl_parcel_info_dgUn;
                    response.tbl_parcel_info_dgPackaging = result[0].tbl_parcel_info_dgPackaging;
                    response.tbl_parcel_info_tailLiftO = result[0].tbl_parcel_info_tailLiftO;
                    response.tbl_parcel_info_tailLiftD = result[0].tbl_parcel_info_tailLiftD;
                    response.tbl_parcel_info_shipperCompany = result[0].tbl_parcel_info_shipperCompany;
                    response.tbl_parcel_info_shipperLastName = result[0].tbl_parcel_info_shipperLastName;
                    response.tbl_parcel_info_deliveryDate = result[0].tbl_parcel_info_deliveryDate;
                    response.idtbl_parcel_items = result[0].idtbl_parcel_items;
                    response.tbl_parcel_items_info_id = result[0].tbl_parcel_items_info_id;
                    response.idtbl_carrier_api_response = result[0].idtbl_carrier_api_response;
                    response.tbl_carrier_api_response_message = result[0].tbl_carrier_api_response_message;
                    response.tbl_carrier_api_response_ind = result[0].tbl_carrier_api_response_ind;
                    response.tbl_carrier_api_response_parcelId = result[0].tbl_carrier_api_response_parcelId;
                    response.tbl_carrier_api_trackingRef = result[0].tbl_carrier_api_trackingRef;
                    response.tbl_services_id = result[0].tbl_services_id;
                    response.tbl_services_name = result[0].tbl_services_name;
                    response.tbl_services_code = result[0].tbl_services_code;
                    response.tbl_services_carrierId = result[0].tbl_services_carrierId;
                    response.tbl_services_active = result[0].tbl_services_active;
                    response.tbl_services_carrierAccount = result[0].tbl_services_carrierAccount;
                    response.tbl_services_carrierCode = result[0].tbl_services_carrierCode;
                    response.idtbl_carrier_info = result[0].idtbl_carrier_info;
                    response.tbl_carrier_name = result[0].tbl_carrier_name;
                    response.tbl_carrier_address1 = result[0].tbl_carrier_address1;
                    response.tbl_carrier_address2 = result[0].tbl_carrier_address2;
                    response.tbl_carrier_city = result[0].tbl_carrier_city;
                    response.tbl_carrier_suburb = result[0].tbl_carrier_suburb;
                    response.tbl_carrier_postCode = result[0].tbl_carrier_postCode;
                    response.tbl_carrier_state = result[0].tbl_carrier_state;
                    response.tbl_carrier_country_origin = result[0].tbl_carrier_country_origin;
                    response.tbl_carrier_country_destination = result[0].tbl_carrier_country_destination;
                    response.tbl_carrier_email = result[0].tbl_carrier_email;
                    response.tbl_carrier_phone = result[0].tbl_carrier_phone;
                    response.tbl_carrier_contactName = result[0].tbl_carrier_contactName;
                    response.tbl_carrier_code = result[0].tbl_carrier_code;
                    response.tbl_carrier_type = result[0].tbl_carrier_type;
                    response.tbl_carrier_active = result[0].tbl_carrier_active;
                    response.parcelsDe = new List<ParcelsDe>();
                    foreach (var shipment in result)
                    {
                        ParcelsDe parcel = new();

                        parcel.tbl_parcel_items_parcelQty = shipment.tbl_parcel_items_parcelQty;
                        parcel.tbl_parcel_items_parcelWeight = shipment.tbl_parcel_items_parcelWeight;
                        parcel.tbl_parcel_items_parcelWidth = shipment.tbl_parcel_items_parcelWidth;
                        parcel.tbl_parcel_items_parcelLength = shipment.tbl_parcel_items_parcelLength;
                        parcel.tbl_parcel_items_parcelHeight = shipment.tbl_parcel_items_parcelHeight;
                        parcel.tbl_parcel_items_parcelWeightUnit = shipment.tbl_parcel_items_parcelWeightUnit;
                        parcel.tbl_parcel_items_parcelReference = shipment.tbl_parcel_items_parcelReference;
                        parcel.tbl_parcel_items_parcelDescription = shipment.tbl_parcel_items_parcelDescription;
                        parcel.tbl_parcel_items_parcelDimensionUnit = shipment.tbl_parcel_items_parcelDimensionUnit;
                        parcel.tbl_parcel_items_parcelType = shipment.tbl_parcel_items_parcelType;

                        response.parcelsDe.Add(parcel);
                    }
                }

                return _mapper.Map<ShipmentDetails>(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
