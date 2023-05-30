using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.Data.Models
{
    [NotMapped]
    public class ShipmentDetailsResponse
    {
        public string idshippers_tracking_ref { get; set; }
        public string tbl_shippers_tracking_createDate { get; set; }
        public string tbl_shippers_tracking_shipmentId { get; set; }
        public string tbl_shippers_tracking_prefix { get; set; }
        public string tbl_shippers_tracking_batch_id { get; set; }
        public string tbl_shippers_tracking_est_cost { get; set; }
        public string idtbl_parcel_info { get; set; }
        public string tbl_parcel_info_batchId { get; set; }
        public string tbl_parcel_info_shipperId { get; set; }
        public string tbl_parcel_info_trackingNo { get; set; }
        public string tbl_parcel_info_referenceNo { get; set; }
        public string tbl_parcel_info_deliveryAddressLine1 { get; set; }
        public string tbl_parcel_info_deliveryAddressLine2 { get; set; }
        public string tbl_parcel_info_deliveryAddressLine3 { get; set; }
        public string tbl_parcel_info_deliveryCity { get; set; }
        public string tbl_parcel_info_deliveryCountry { get; set; }
        public string tbl_parcel_info_description { get; set; }
        public string tbl_parcel_info_nativeDescription { get; set; }
        public string tbl_parcel_info_deliveryEmail { get; set; }
        public string tbl_parcel_info_facility { get; set; }
        public string tbl_parcel_info_instruction { get; set; }
        public string tbl_parcel_info_invoiceCurrency { get; set; }
        public string tbl_parcel_info_invoiceValue { get; set; }
        public string tbl_parcel_info_phone { get; set; }
        public string tbl_parcel_info_platform { get; set; }
        public string tbl_parcel_info_deliverySuburb { get; set; }
        public string tbl_parcel_info_deliveryPostcode { get; set; }
        public string tbl_parcel_info_deliveryCompany { get; set; }
        public string tbl_parcel_info_deliveryName { get; set; }
        public string tbl_parcel_info_serviceCode { get; set; }
        public string tbl_parcel_info_serviceOption { get; set; }
        public string tbl_parcel_info_deliveryState { get; set; }
        public string tbl_parcel_info_shipperName { get; set; }
        public string tbl_parcel_info_shipperAddressLine1 { get; set; }
        public string tbl_parcel_info_shipperAddressLine2 { get; set; }
        public string tbl_parcel_info_shipperAddressLine3 { get; set; }
        public string tbl_parcel_info_shipperCity { get; set; }
        public string tbl_parcel_info_shipperState { get; set; }
        public string tbl_parcel_info_shipperPostcode { get; set; }
        public string tbl_parcel_info_shipperCountry { get; set; }
        public string tbl_parcel_info_shipperPhone { get; set; }
        public string tbl_parcel_info_authorityToLeave { get; set; }
        public string tbl_parcel_info_incoterm { get; set; }
        public string tbl_parcel_info_vendorid { get; set; }
        public string tbl_parcel_info_gstexemptioncode { get; set; }
        public string tbl_parcel_info_abnnumber { get; set; }
        public string tbl_parcel_info_sortCode { get; set; }
        public string tbl_parcel_info_coveramount { get; set; }
        public string tbl_parcel_info_orderItems { get; set; }
        public string tbl_parcel_info_deliveryInstructions { get; set; }
        public string tbl_parcel_info_lockerService { get; set; }
        public string tbl_parcel_info_returnName { get; set; }
        public string tbl_parcel_info_returnAddress1 { get; set; }
        public string tbl_parcel_info_returnAddress2 { get; set; }
        public string tbl_parcel_info_returnAddress3 { get; set; }
        public string tbl_parcel_info_returnCity { get; set; }
        public string tbl_parcel_info_returnState { get; set; }
        public string tbl_parcel_info_returnPostcode { get; set; }
        public string tbl_parcel_info_returnCountry { get; set; }
        public string tbl_parcel_info_returnOption { get; set; }
        public string tbl_parcel_info_shipperEmail { get; set; }
        public string tbl_parcel_info_shipment { get; set; }
        public string tbl_parcel_info_deliveryContact { get; set; }
        public string tbl_parcel_info_deliveryContactPhone { get; set; }
        public string tbl_parcel_info_deliveryContactEmail { get; set; }
        public string tbl_parcel_info_shipperSuburb { get; set; }
        public string tbl_parcel_info_deliveryPhone { get; set; }
        public string tbl_parcel_info_shipperInstructions { get; set; }
        public string tbl_parcel_info_shipperContact { get; set; }
        public string tbl_parcel_info_warehouse { get; set; }
        public string tbl_parcel_info_timestamp { get; set; }
        public string tbl_parcel_info_readyDate { get; set; }
        public string tbl_parcel_info_dg { get; set; }
        public string tbl_parcel_info_dgClass { get; set; }
        public string tbl_parcel_info_dgUn { get; set; }
        public string tbl_parcel_info_dgPackaging { get; set; }
        public string tbl_parcel_info_tailLiftO { get; set; }
        public string tbl_parcel_info_tailLiftD { get; set; }
        public string tbl_parcel_info_shipperCompany { get; set; }
        public string tbl_parcel_info_shipperLastName { get; set; }
        public string tbl_parcel_info_deliveryDate { get; set; }
        public string idtbl_parcel_items { get; set; }
        public string tbl_parcel_items_info_id { get; set; }
        public string idtbl_carrier_api_response { get; set; }
        public string tbl_carrier_api_response_message { get; set; }
        public string tbl_carrier_api_response_ind { get; set; }
        public string tbl_carrier_api_response_parcelId { get; set; }
        public string tbl_carrier_api_trackingRef { get; set; }
        public string tbl_services_id { get; set; }
        public string tbl_services_name { get; set; }
        public string tbl_services_code { get; set; }
        public string tbl_services_carrierId { get; set; }
        public string tbl_services_active { get; set; }
        public string tbl_services_carrierAccount { get; set; }
        public string tbl_services_carrierCode { get; set; }
        public string idtbl_carrier_info { get; set; }
        public string tbl_carrier_name { get; set; }
        public string tbl_carrier_address1 { get; set; }
        public string tbl_carrier_address2 { get; set; }
        public string tbl_carrier_city { get; set; }
        public string tbl_carrier_suburb { get; set; }
        public string tbl_carrier_postCode { get; set; }
        public string tbl_carrier_state { get; set; }
        public string tbl_carrier_country_origin { get; set; }
        public string tbl_carrier_country_destination { get; set; }
        public string tbl_carrier_email { get; set; }
        public string tbl_carrier_phone { get; set; }
        public string tbl_carrier_contactName { get; set; }
        public string tbl_carrier_code { get; set; }
        public string tbl_carrier_type { get; set; }
        public string tbl_carrier_active { get; set; }
        public string tbl_parcel_items_parcelQty { get; set; }
        public string tbl_parcel_items_parcelWeight { get; set; }
        public string tbl_parcel_items_parcelWidth { get; set; }
        public string tbl_parcel_items_parcelLength { get; set; }
        public string tbl_parcel_items_parcelHeight { get; set; }
        public string tbl_parcel_items_parcelWeightUnit { get; set; }
        public string tbl_parcel_items_parcelReference { get; set; }
        public string tbl_parcel_items_parcelDescription { get; set; }
        public string tbl_parcel_items_parcelDimensionUnit { get; set; }
        public string tbl_parcel_items_parcelType { get; set; }
    }
}
