using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ParcelsDe
    {
        [JsonProperty(PropertyName = "qty")]
        public string tbl_parcel_items_parcelQty { get; set; }
        [JsonProperty(PropertyName = "weight")]
        public string tbl_parcel_items_parcelWeight { get; set; }
        [JsonProperty(PropertyName = "width")]
        public string tbl_parcel_items_parcelWidth { get; set; }
        [JsonProperty(PropertyName = "length")]
        public string tbl_parcel_items_parcelLength { get; set; }
        [JsonProperty(PropertyName = "height")]
        public string tbl_parcel_items_parcelHeight { get; set; }
        [JsonProperty(PropertyName = "weightUnit")]
        public string tbl_parcel_items_parcelWeightUnit { get; set; }
        [JsonProperty(PropertyName = "reference")]
        public string tbl_parcel_items_parcelReference { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string tbl_parcel_items_parcelDescription { get; set; }
        [JsonProperty(PropertyName = "dimensionUnit")]
        public string tbl_parcel_items_parcelDimensionUnit { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string tbl_parcel_items_parcelType { get; set; }
    }

    public class ShipmentDetails
    {
        [JsonProperty(PropertyName = "jobNumber")]
        public string idshippers_tracking_ref { get; set; }
        [JsonProperty(PropertyName = "createdDate")]
        public string tbl_shippers_tracking_createDate { get; set; }
        [JsonProperty(PropertyName = "shipmentId")]
        public string tbl_shippers_tracking_shipmentId { get; set; }
        [JsonProperty(PropertyName = "trackingPrefix")]
        public string tbl_shippers_tracking_prefix { get; set; }
        [JsonProperty(PropertyName = "trackingBatchid")]
        public string tbl_shippers_tracking_batch_id { get; set; }
        [JsonProperty(PropertyName = "estimatedCost")]
        public string tbl_shippers_tracking_est_cost { get; set; }
        [JsonProperty(PropertyName = "parcelInfoId")]
        public string idtbl_parcel_info { get; set; }
        [JsonProperty(PropertyName = "parcelInfoBatchId")]
        public string tbl_parcel_info_batchId { get; set; }
        [JsonProperty(PropertyName = "shipperId")]
        public string tbl_parcel_info_shipperId { get; set; }
        [JsonProperty(PropertyName = "trackingNumber")]
        public string tbl_parcel_info_trackingNo { get; set; }
        [JsonProperty(PropertyName = "parcelReferenceNo")]
        public string tbl_parcel_info_referenceNo { get; set; }
        [JsonProperty(PropertyName = "deliveryAddress1")]
        public string tbl_parcel_info_deliveryAddressLine1 { get; set; }
        [JsonProperty(PropertyName = "deliveryAddress2")]
        public string tbl_parcel_info_deliveryAddressLine2 { get; set; }
        [JsonProperty(PropertyName = "deliveryAddress3")]
        public string tbl_parcel_info_deliveryAddressLine3 { get; set; }
        [JsonProperty(PropertyName = "deliveryCity")]
        public string tbl_parcel_info_deliveryCity { get; set; }
        [JsonProperty(PropertyName = "deliveryCountry")]
        public string tbl_parcel_info_deliveryCountry { get; set; }
        [JsonProperty(PropertyName = "parcelDescription")]
        public string tbl_parcel_info_description { get; set; }
        [JsonProperty(PropertyName = "parcelNativeDecription")]
        public string tbl_parcel_info_nativeDescription { get; set; }
        [JsonProperty(PropertyName = "deliveryEmail")]
        public string tbl_parcel_info_deliveryEmail { get; set; }
        [JsonProperty(PropertyName = "facility")]
        public string tbl_parcel_info_facility { get; set; }
        [JsonProperty(PropertyName = "instruction")]
        public string tbl_parcel_info_instruction { get; set; }
        [JsonProperty(PropertyName = "invoiceCurrency")]
        public string tbl_parcel_info_invoiceCurrency { get; set; }
        [JsonProperty(PropertyName = "invoiceValue")]
        public string tbl_parcel_info_invoiceValue { get; set; }
        [JsonProperty(PropertyName = "parcelInfoPhone")]
        public string tbl_parcel_info_phone { get; set; }
        [JsonProperty(PropertyName = "platform")]
        public string tbl_parcel_info_platform { get; set; }
        [JsonProperty(PropertyName = "deliverySuburb")]
        public string tbl_parcel_info_deliverySuburb { get; set; }
        [JsonProperty(PropertyName = "deliveryPostcode")]
        public string tbl_parcel_info_deliveryPostcode { get; set; }
        [JsonProperty(PropertyName = "deliveryCompany")]
        public string tbl_parcel_info_deliveryCompany { get; set; }
        [JsonProperty(PropertyName = "deliveryName")]
        public string tbl_parcel_info_deliveryName { get; set; }
        [JsonProperty(PropertyName = "serviceCode")]
        public string tbl_parcel_info_serviceCode { get; set; }
        [JsonProperty(PropertyName = "serviceOption")]
        public string tbl_parcel_info_serviceOption { get; set; }
        [JsonProperty(PropertyName = "deliveryState")]
        public string tbl_parcel_info_deliveryState { get; set; }
        [JsonProperty(PropertyName = "shipperName")]
        public string tbl_parcel_info_shipperName { get; set; }
        [JsonProperty(PropertyName = "shipperAddress1")]
        public string tbl_parcel_info_shipperAddressLine1 { get; set; }
        [JsonProperty(PropertyName = "shipperAddress2")]
        public string tbl_parcel_info_shipperAddressLine2 { get; set; }
        [JsonProperty(PropertyName = "shipperAddress3")]
        public string tbl_parcel_info_shipperAddressLine3 { get; set; }
        [JsonProperty(PropertyName = "shipperCity")]
        public string tbl_parcel_info_shipperCity { get; set; }
        [JsonProperty(PropertyName = "shipperState")]
        public string tbl_parcel_info_shipperState { get; set; }
        [JsonProperty(PropertyName = "shipperPostcode")]
        public string tbl_parcel_info_shipperPostcode { get; set; }
        [JsonProperty(PropertyName = "shipperCountry")]
        public string tbl_parcel_info_shipperCountry { get; set; }
        [JsonProperty(PropertyName = "shipperPhone")]
        public string tbl_parcel_info_shipperPhone { get; set; }
        [JsonProperty(PropertyName = "authorityToLeave")]
        public string tbl_parcel_info_authorityToLeave { get; set; }
        [JsonProperty(PropertyName = "incoTerm")]
        public string tbl_parcel_info_incoterm { get; set; }
        [JsonProperty(PropertyName = "vendorId")]
        public string tbl_parcel_info_vendorid { get; set; }
        [JsonProperty(PropertyName = "tstExemptionCode")]
        public string tbl_parcel_info_gstexemptioncode { get; set; }
        [JsonProperty(PropertyName = "abnNumber")]
        public string tbl_parcel_info_abnnumber { get; set; }
        [JsonProperty(PropertyName = "sortCode")]
        public string tbl_parcel_info_sortCode { get; set; }
        [JsonProperty(PropertyName = "coverAmount")]
        public string tbl_parcel_info_coveramount { get; set; }
        [JsonProperty(PropertyName = "orderItems")]
        public string tbl_parcel_info_orderItems { get; set; }
        [JsonProperty(PropertyName = "deliveryInstructions")]
        public string tbl_parcel_info_deliveryInstructions { get; set; }
        [JsonProperty(PropertyName = "lockerService")]
        public string tbl_parcel_info_lockerService { get; set; }
        [JsonProperty(PropertyName = "returnName")]
        public string tbl_parcel_info_returnName { get; set; }
        [JsonProperty(PropertyName = "returnAddress1")]
        public string tbl_parcel_info_returnAddress1 { get; set; }
        [JsonProperty(PropertyName = "returnAddress2")]
        public string tbl_parcel_info_returnAddress2 { get; set; }
        [JsonProperty(PropertyName = "returnAddress3")]
        public string tbl_parcel_info_returnAddress3 { get; set; }
        [JsonProperty(PropertyName = "returnCity")]
        public string tbl_parcel_info_returnCity { get; set; }
        [JsonProperty(PropertyName = "returnState")]
        public string tbl_parcel_info_returnState { get; set; }
        [JsonProperty(PropertyName = "returnPostcode")]
        public string tbl_parcel_info_returnPostcode { get; set; }
        [JsonProperty(PropertyName = "returnCountry")]
        public string tbl_parcel_info_returnCountry { get; set; }
        [JsonProperty(PropertyName = "returnOption")]
        public string tbl_parcel_info_returnOption { get; set; }
        [JsonProperty(PropertyName = "shipperEmail")]
        public string tbl_parcel_info_shipperEmail { get; set; }
        [JsonProperty(PropertyName = "shipment")]
        public string tbl_parcel_info_shipment { get; set; }
        [JsonProperty(PropertyName = "deliveryContact")]
        public string tbl_parcel_info_deliveryContact { get; set; }
        [JsonProperty(PropertyName = "deliveryContactPhone")]
        public string tbl_parcel_info_deliveryContactPhone { get; set; }
        [JsonProperty(PropertyName = "deliveryContactEmail")]
        public string tbl_parcel_info_deliveryContactEmail { get; set; }
        [JsonProperty(PropertyName = "shipperSuburb")]
        public string tbl_parcel_info_shipperSuburb { get; set; }
        [JsonProperty(PropertyName = "deliveryPhone")]
        public string tbl_parcel_info_deliveryPhone { get; set; }
        [JsonProperty(PropertyName = "shipperInstructions")]
        public string tbl_parcel_info_shipperInstructions { get; set; }
        [JsonProperty(PropertyName = "shipperContact")]
        public string tbl_parcel_info_shipperContact { get; set; }
        [JsonProperty(PropertyName = "warehouse")]
        public string tbl_parcel_info_warehouse { get; set; }
        [JsonProperty(PropertyName = "timestamp")]
        public string tbl_parcel_info_timestamp { get; set; }
        [JsonProperty(PropertyName = "readyDate")]
        public string tbl_parcel_info_readyDate { get; set; }
        [JsonProperty(PropertyName = "dg")]
        public string tbl_parcel_info_dg { get; set; }
        [JsonProperty(PropertyName = "dgClass")]
        public string tbl_parcel_info_dgClass { get; set; }
        [JsonProperty(PropertyName = "dgUn")]
        public string tbl_parcel_info_dgUn { get; set; }
        [JsonProperty(PropertyName = "dgPackaging")]
        public string tbl_parcel_info_dgPackaging { get; set; }
        [JsonProperty(PropertyName = "tailLiftO")]
        public string tbl_parcel_info_tailLiftO { get; set; }
        [JsonProperty(PropertyName = "tailLiftD")]
        public string tbl_parcel_info_tailLiftD { get; set; }
        [JsonProperty(PropertyName = "shipperCompany")]
        public string tbl_parcel_info_shipperCompany { get; set; }
        [JsonProperty(PropertyName = "shipperLastname")]
        public string tbl_parcel_info_shipperLastName { get; set; }
        [JsonProperty(PropertyName = "deliveryDate")]
        public string tbl_parcel_info_deliveryDate { get; set; }
        [JsonProperty(PropertyName = "parcelItemId")]
        public string idtbl_parcel_items { get; set; }
        [JsonProperty(PropertyName = "parcelItemInfoId")]
        public string tbl_parcel_items_info_id { get; set; }
        [JsonProperty(PropertyName = "carrierId")]
        public string idtbl_carrier_api_response { get; set; }
        [JsonProperty(PropertyName = "carrierResponse")]
        public string tbl_carrier_api_response_message { get; set; }
        [JsonProperty(PropertyName = "carrierResponseInd")]
        public string tbl_carrier_api_response_ind { get; set; }
        [JsonProperty(PropertyName = "carrierParcelId")]
        public string tbl_carrier_api_response_parcelId { get; set; }
        [JsonProperty(PropertyName = "carrierTrackingRef")]
        public string tbl_carrier_api_trackingRef { get; set; }
        [JsonProperty(PropertyName = "servicesId")]
        public string tbl_services_id { get; set; }
        [JsonProperty(PropertyName = "servicesName")]
        public string tbl_services_name { get; set; }
        [JsonProperty(PropertyName = "servicesCode")]
        public string tbl_services_code { get; set; }
        [JsonProperty(PropertyName = "servicesCarrierId")]
        public string tbl_services_carrierId { get; set; }
        [JsonProperty(PropertyName = "servicesActive")]
        public string tbl_services_active { get; set; }
        [JsonProperty(PropertyName = "servicesCarrierAccount")]
        public string tbl_services_carrierAccount { get; set; }
        [JsonProperty(PropertyName = "servicesCarrierCode")]
        public string tbl_services_carrierCode { get; set; }
        [JsonProperty(PropertyName = "carrierInfoId")]
        public string idtbl_carrier_info { get; set; }
        [JsonProperty(PropertyName = "carrierName")]
        public string tbl_carrier_name { get; set; }
        [JsonProperty(PropertyName = "carrierAddress1")]
        public string tbl_carrier_address1 { get; set; }
        [JsonProperty(PropertyName = "carrierAddress2")]
        public string tbl_carrier_address2 { get; set; }
        [JsonProperty(PropertyName = "carrierCity")]
        public string tbl_carrier_city { get; set; }
        [JsonProperty(PropertyName = "carrierSuburb")]
        public string tbl_carrier_suburb { get; set; }
        [JsonProperty(PropertyName = "carrierPostcode")]
        public string tbl_carrier_postCode { get; set; }
        [JsonProperty(PropertyName = "carrierState")]
        public string tbl_carrier_state { get; set; }
        [JsonProperty(PropertyName = "carrierCountryOrigin")]
        public string tbl_carrier_country_origin { get; set; }
        [JsonProperty(PropertyName = "carrierCountryDestination")]
        public string tbl_carrier_country_destination { get; set; }
        [JsonProperty(PropertyName = "carrierEmail")]
        public string tbl_carrier_email { get; set; }
        [JsonProperty(PropertyName = "carrierPhone")]
        public string tbl_carrier_phone { get; set; }
        [JsonProperty(PropertyName = "carrierContactName")]
        public string tbl_carrier_contactName { get; set; }
        [JsonProperty(PropertyName = "carrierCode")]
        public string tbl_carrier_code { get; set; }
        [JsonProperty(PropertyName = "carrierType")]
        public string tbl_carrier_type { get; set; }
        [JsonProperty(PropertyName = "carrierActive")]
        public string tbl_carrier_active { get; set; }
        [JsonProperty(PropertyName = "ParcelDetails")]
        public List<ParcelsDe> parcelsDe { get; set; } = null;
    }


}
