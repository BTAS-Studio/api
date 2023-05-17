using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class ShipmentTrackingRepository : IRepository<tbl_shippers_tracking_refDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public ShipmentTrackingRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all shippers tracking
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_shippers_tracking_refDto>> GetAllAsync()
        {
            IEnumerable<tbl_shippers_tracking_ref> _list = await _context.tbl_shippers_tracking_refs.ToListAsync();
            return _mapper.Map<List<tbl_shippers_tracking_refDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single shipper tracking based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_shippers_tracking_refDto> GetByIdAsync(int id)
        {

            var shipper = await _context.tbl_shippers_tracking_refs.FirstOrDefaultAsync(x => x.idshippers_tracking_ref == id);
            return _mapper.Map<tbl_shippers_tracking_refDto>(shipper);

        }

        /// <summary>
        /// Creates/updates a shipper tracking record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_shippers_tracking_refDto> CreateUpdateAsync(tbl_shippers_tracking_refDto entity)
        {
            var shipper = _mapper.Map<tbl_shippers_tracking_refDto, tbl_shippers_tracking_ref>(entity);
            if (shipper.idshippers_tracking_ref > 0)
            {
                _context.tbl_shippers_tracking_refs.Update(shipper);
            }
            else
            {
                _context.tbl_shippers_tracking_refs.Add(shipper);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<tbl_shippers_tracking_ref, tbl_shippers_tracking_refDto>(shipper);
        }

        /// <summary>
        /// Creates a shipper tracking record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_shippers_tracking_refDto entity)
        {
            try
            {
                var shipper = _mapper.Map<tbl_shippers_tracking_refDto, tbl_shippers_tracking_ref>(entity);
                if (shipper.idshippers_tracking_ref > 0)
                {
                    _context.tbl_shippers_tracking_refs.Update(shipper);
                }
                else
                {
                    _context.tbl_shippers_tracking_refs.Add(shipper);
                }
                await _context.SaveChangesAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<tbl_houseDto>(shipper),
                    DisplayMessage = "Shipper Tracking Reference successfully saved.",
                    IsSuccess = true,
                    ReferenceNumber = shipper.idshippers_tracking_ref.ToString()
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Unable to create tracking reference. " + ex.Message.ToString(),
                    IsSuccess = false
                };
            }            
        }

        /// <summary>
        /// Deletes existing shipper tracking record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var shipper = await _context.tbl_shippers_tracking_refs.FirstOrDefaultAsync(x => x.idshippers_tracking_ref == id);
                if (shipper == null)
                {
                    return false;
                }
                _context.tbl_shippers_tracking_refs.Remove(shipper);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
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
                throw new Exception();
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
                throw new Exception();
            }
        }

        public Task<IEnumerable<tbl_shippers_tracking_refDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_shippers_tracking_refDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_shippers_tracking_refDto>> GetAllAsyncWithChildren(searchFilter<tbl_shippers_tracking_refDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
