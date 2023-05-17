using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel;
using BTAS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTAS.API.Dto
{
    //Edited by HS on 24/01/2023

    //Edited by HS on 27/01/2023 comment out all [Optional] and [Required]
    public class tbl_shipmentDto
    {
        [JsonProperty("Id")]
        [DoNotInclude]
        public int idtbl_shipment { get; set; }
        [StringLength(30)]
        [Description("HOUSE Unique reference, this is system generated on create. Only needed for update and get.")]
        //[Conditional]
        [JsonProperty("Code")]
        public string tbl_shipment_code { get; set; }
        [StringLength(30)]
        //[Optional]
        [Description("Mark shipment as inactive, active or closed")]
        //Edited by HS on 27/01/2023
        //[RegularExpression("Inactive|Active|Closed")]
        [JsonProperty("Status")]
        public string tbl_shipment_status { get; set; }
        [StringLength(15)]
        //[Required]
        [Description("Refer to provided batchId")]
        [JsonProperty("BatchCode")]
        public string tbl_shipment_batchCode { get; set; }
        //[StringLength(50)]
        ////[Required]
        //[Description("Refer to provided credentials")]
        //[JsonProperty("ShipperId")]
        //public string tbl_shipment_shipperId { get; set; }
        [StringLength(10)]
        //[Required]
        [Description("Refer to provided credentials")]
        [JsonProperty("ShipperCode")]
        public string tbl_shipment_shipperCode { get; set; }
        [StringLength(50)]
        //[Conditional]
        [Description("Can be provided if shipperCode is not provided")]
        [JsonProperty("TrackingNumber")]
        public string tbl_shipment_trackingNo { get; set; }
        [StringLength(50)]
        [Description("")]
        [JsonProperty("ReferenceNumber")]
        public string tbl_shipment_referenceNo { get; set; }
        [StringLength(150)]
        //[Required]
        [Description("Shipment Description is required for international shipments")]
        [JsonProperty("Description")]
        public string tbl_shipment_description { get; set; }
        [StringLength(150)]
        //[Conditional]
        [Description("Required for shipments from CN, must be mandarin")]
        [JsonProperty("NativeDescription")]
        public string tbl_shipment_nativeDescription { get; set; }
        [StringLength(50)]
        //[Conditional]
        [Description("Particular delivery facilty information")]
        [JsonProperty("Facility")]
        public string tbl_shipment_facility { get; set; }
        [StringLength(150)]
        //[Optional]
        [Description("Carrier instructions, not seen by the reciever")]
        [JsonProperty("Instruction")]
        public string tbl_shipment_instruction { get; set; }
        [StringLength(3)]
        //[Conditional]
        [Description("Needed for international shipments, but recommended for all. Refer to Currency codes.")]
        [JsonProperty("InvoiceCurrency")]
        public string tbl_shipment_invoiceCurrency { get; set; }
        [JsonProperty("InvoiceValue")]
        //[Conditional]
        [Description("Needed for international shipments, but recommended for all.")]
        public decimal? tbl_shipment_invoiceValue { get; set; }
        [StringLength(45)]
        //[Conditional]
        [Description("Required by some carriers, but recommended for all.")]
        [JsonProperty("Phone")]
        public string tbl_shipment_phone { get; set; }
        [StringLength(45)]
        //[Conditional]
        [Description("PlatForm")]
        [JsonProperty("PlatForm")]
        public string tbl_shipment_platform { get; set; }
        [StringLength(45)]
        //[Required]
        [Description("Use to create labels on particular carriers.Please refer to Service Code detail for further information")]
        [RegularExpression("no.carrier|APG.EPARCEL.DOM.AU|FW.DOM.COURIER.AU|UBI.CN2UKE2E.ROM")]
        [JsonProperty("ServiceCode")]
        public string tbl_shipment_serviceCode { get; set; }
        [StringLength(45)]
        [Description("Service Option")]
        [JsonProperty("ServiceOption")]
        public string tbl_shipment_serviceOption { get; set; }
        //[Required]
        [Description("Does the carrier have authority to leave in safe place?")]
        [JsonProperty("HasAuthorityToLeave")]
        public bool? tbl_shipment_authorityToLeave { get; set; } = false;
        [StringLength(50)]
        //[Optional]
        [Description("Refer to internatioanlly recognised incoterms.")]
        [JsonProperty("ShipmentIncoterm")]
        public string tbl_shipment_incoterm { get; set; }
        [StringLength(150)]
        [Description("Shipment Items")]
        [JsonProperty("ShipmentItems")]
        public string tbl_shipment_shipmentItems { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Provide if required by carrier.")]
        [JsonProperty("VendorId")]
        public string tbl_shipment_vendorId { get; set; }
        [JsonProperty("GstExemptionCode")]
        ////[Conditional]
        [Description("Provide if international shipment has any tax exemptions.")]
        public bool? tbl_shipment_gstExemptionCode { get; set; } = false;
        [StringLength(45)]
        //[Optional]
        [Description("Company registration number.")]
        [JsonProperty("ABNNumber")]
        public string tbl_shipment_abnNumber { get; set; }
        [StringLength(45)]
        //[Optional]
        [Description("Company Sort Code.")]
        [JsonProperty("SortCode")]
        public string tbl_shipment_sortCode { get; set; }
        //[Optional]
        [Description("Insurance amount for transit.")]
        [JsonProperty("TransitCoverAmount")]
        public decimal? tbl_shipment_coverAmount { get; set; }
        [StringLength(150)]
        [Description("Order Items")]
        [JsonProperty("OrderItems")]
        public string tbl_shipment_orderItems { get; set; }

        ////[Conditional]
        [Description("Can be used for country local PO Box deliveries.")]
        [JsonProperty("HasLockerService")]
        public bool? tbl_shipment_hasLockerService { get; set; }
        [StringLength(45)]
        //[Optional]
        [Description("Is the delivery address a warehouse?")]
        [JsonProperty("Warehouse")]
        public string tbl_shipment_warehouse { get; set; }
        [JsonProperty("CreatedDate")]
        [Description("System generated")]
        public DateTime? tbl_shipment_createdDate { get; set; }
        ////[Conditional]
        [Description("DateTime shipment is ready for collection. Required for some carriers")]
        [JsonProperty("ReadyDate")]
        public DateTime? tbl_shipment_readyDate { get; set; }
        ////[Conditional]
        [Description("Are the goods classed as dangerous?")]
        [JsonProperty("DangerousGoods")]
        public bool? tbl_shipment_dg { get; set; } = false;
        [StringLength(45)]
        ////[Conditional]
        [Description("The Dangerous goods class.")]
        [JsonProperty("DangerousGoodsClass")]
        public string tbl_shipment_dgClass { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("The Dangerous goods UN Code.")]
        [JsonProperty("DangerousGoodsUn")]
        public string tbl_shipment_dgUn { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("The Dangerous goods Packaging")]
        [JsonProperty("DGPackaging")]
        public string tbl_shipment_dgPackaging { get; set; }
        //[Optional]
        [Description("Is a taillift required on collection")]
        [JsonProperty("TailLiftOrigin")]
        public bool? tbl_shipment_tailLiftO { get; set; } = false;
        //[Optional]
        [Description("Is a taillift required on delivery")]
        [JsonProperty("TailLiftDestionation")]
        public bool? tbl_shipment_tailLiftD { get; set; } = false;
        [StringLength(45)]
        //[Required]
        [Description("Person contact name")]
        [JsonProperty("DeliveryName")]
        public string tbl_shipment_deliveryName { get; set; }
        [Description("Delivery phone is needed by all carriers")]
        [JsonProperty("DeliveryPhone")]
        public string tbl_shipment_deliveryPhone { get; set; }
        [JsonProperty("DeliveryEmail")]
        public string tbl_shipment_deliveryEmail { get; set; }
        [StringLength(45)]
        [Description("Delivery Contact")]
        [JsonProperty("DeliveryContact")]
        public string tbl_shipment_deliveryContact { get; set; }
        [StringLength(45)]
        [Description("Delivery Contact Phone")]
        [JsonProperty("DeliveryContactPhone")]
        public string tbl_shipment_deliveryContactPhone { get; set; }
        [StringLength(45)]
        [Description("Delivery Contact Email")]
        [JsonProperty("DeliveryContactEmail")]
        public string tbl_shipment_deliveryContactEmail { get; set; }
        [StringLength(45)]
        //[Optional]
        [Description("If this is a buisness address then it is recommended")]
        [JsonProperty("DeliveryCompany")]
        public string tbl_shipment_deliveryCompany { get; set; }

        [StringLength(150)]
        //[Required]
        [Description("Delivery Address Line 1")]
        [JsonProperty("DeliveryAddressLine1")]
        public string tbl_shipment_deliveryAddressLine1 { get; set; }
        [StringLength(150)]
        //[Optional]
        [Description("Delivery Address Line 2")]
        [JsonProperty("DeliveryAddressLine2")]
        public string tbl_shipment_deliveryAddressLine2 { get; set; }
        [StringLength(150)]
        //[Optional]
        [Description("Delivery Address Line 3")]
        [JsonProperty("DeliveryAddressLine3")]
        public string tbl_shipment_deliveryAddressLine3 { get; set; }
        [StringLength(45)]
        //[Conditional]
        [Description("Sometimes can be referred to as the city or town")]
        [JsonProperty("DeliverySuburb")]
        public string tbl_shipment_deliverySuburb { get; set; }
        [StringLength(45)]
        //[Conditional]
        [Description("Some countries require the delivery city")]
        [JsonProperty("DeliveryCity")]
        public string tbl_shipment_deliveryCity { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Delivery state is required in certain countries")]
        [JsonProperty("DeliveryState")]
        public string tbl_shipment_deliveryState { get; set; }
        [StringLength(45)]
        //[Conditional]
        [Description("Depends on the delivery country, can be referred to as Zip")]
        [JsonProperty("DeliveryPostcode")]
        public string tbl_shipment_deliveryPostcode { get; set; }
        [StringLength(2)]
        //[Required]
        [Description("Delivery Country required. Refer to ISO country code")]
        [JsonProperty("DeliveryCountry")]
        public string tbl_shipment_deliveryCountry { get; set; }
        [StringLength(150)]
        //[Optional]
        [Description("Instruction seen by the reciever.")]
        [JsonProperty("DeliveryInstructions")]
        public string tbl_shipment_deliveryInstructions { get; set; }
        //[Optional]
        [Description("Required Delivery Date")]
        [JsonProperty("DeliveryDate")]
        public DateTime? tbl_shipment_deliveryDate { get; set; }
        [StringLength(45)]
        //[Required]
        [Description("Shipper contact name")]
        [JsonProperty("ShipperName")]
        public string tbl_shipment_shipperName { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Required by some carriers, use local phone format")]
        [JsonProperty("ShipperPhone")]
        public string tbl_shipment_shipperPhone { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Shipper email required for some carriers")]
        [JsonProperty("ShipperEmail")]
        public string tbl_shipment_shipperEmail { get; set; }
        [StringLength(45)]
        [JsonProperty("ShipperContact")]
        public string tbl_shipment_shipperContact { get; set; }
        [StringLength(45)]
        //[Optional]
        [Description("'Shipper company should be supplied where possible")]
        [JsonProperty("ShipperCompany")]
        public string tbl_shipment_shipperCompany { get; set; }
        [StringLength(150)]
        //[Required]
        [Description("Shipper address line 1")]
        [JsonProperty("ShipperAddressLine1")]
        public string tbl_shipment_shipperAddressLine1 { get; set; }
        [StringLength(150)]
        //[Optional]
        [Description("Shipper address line 2 if required")]
        [JsonProperty("ShipperAddressLine2")]
        public string tbl_shipment_shipperAddressLine2 { get; set; }
        [StringLength(150)]
        //[Optional]
        [Description("Shipper address line 3 if required")]
        [JsonProperty("ShipperAddressLine3")]
        public string tbl_shipment_shipperAddressLine3 { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Shipper city required for certain countries.")]
        [JsonProperty("ShipperCity")]
        public string tbl_shipment_shipperCity { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Shipper suburb required for some countries")]
        [JsonProperty("ShipperSuburb")]
        public string tbl_shipment_shipperSuburb { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Shipper state required for certain countries.")]
        [JsonProperty("ShipperState")]
        public string tbl_shipment_shipperState { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Shipper postcode required for certain countries, can be referred to as the zip code.")]
        [JsonProperty("ShipperPostcode")]
        public string tbl_shipment_shipperPostcode { get; set; }
        [StringLength(2)]
        //[Required]
        [Description("Shipper country required, please refer to ISO standard")]
        [JsonProperty("ShipperCountry")]
        public string tbl_shipment_shipperCountry { get; set; }
        [StringLength(150)]
        //[Optional]
        [Description("Instructions for the Shipper")]
        [JsonProperty("ShipperInstructions")]
        public string tbl_shipment_shipperInstructions { get; set; }
        [StringLength(50)]
        ////[Conditional]
        [Description("Return contact name, required for some carriers.")]
        [JsonProperty("ReturnName")]
        public string tbl_shipment_returnName { get; set; }
        [StringLength(150)]
        ////[Conditional]
        [Description("Return contact address line 1, required for some carriers.")]
        [JsonProperty("ReturnAddressLine1")]
        public string tbl_shipment_returnAddress1 { get; set; }
        [StringLength(150)]
        ////[Conditional]
        [Description("Return contact address line 2, required for some carriers.")]
        [JsonProperty("ReturnAddressLine2")]
        public string tbl_shipment_returnAddress2 { get; set; }
        [StringLength(150)]
        ////[Conditional]
        [Description("Return contact address line 3, required for some carriers.")]
        [JsonProperty("ReturnAddressLine3")]
        public string tbl_shipment_returnAddress3 { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Return contact address city, required for some carriers.")]
        [JsonProperty("ReturnCity")]
        public string tbl_shipment_returnCity { get; set; }
        [StringLength(3)]
        ////[Conditional]
        [Description("Return contact address state, required for some carriers.")]
        [JsonProperty("ReturnState")]
        public string tbl_shipment_returnState { get; set; }
        [StringLength(45)]
        ////[Conditional]
        [Description("Return contact address postcode, required for some carriers.")]
        [JsonProperty("ReturnPostcode")]
        public string tbl_shipment_returnPostcode { get; set; }
        [StringLength(2)]
        ////[Conditional]
        [Description("Return contact address city, required for some carriers. Refer to ISO codes.")]
        [JsonProperty("ReturnCountry")]
        public string tbl_shipment_returnCountry { get; set; }
        [StringLength(20)]
        ////[Conditional]
        [Description("Return service carrier service type")]
        [JsonProperty("ReturnOption")]
        public string tbl_shipment_returnOption { get; set; }
        //[StringLength(150)]
        //[Description("Shipment")]
        //[JsonProperty("Shipment")]
        //public string tbl_shipment_shipment { get; set; }



        [Description("This is our system PK ref")]
        [JsonProperty("ReceptacleId")]
        public int? tbl_receptacle_id { get; set; }
        [StringLength(30)]
        //[Optional]
        [Description("Receptacle Reference - Use this to link this Shipment/Lower to a particular receptacle")]
        [JsonProperty("ReceptacleCode")]
        public string ReceptacleCode { get; set; }
        [JsonProperty("Receptacle")]
        public virtual tbl_receptacleDto receptacle { get; set; }
        [JsonProperty("IncotermsId")]
        public int? tbl_incoterms_id { get; set; }
        [StringLength(30)]
        [JsonProperty("IncotermsCode")]
        public string IncotermsCode { get; set; }
        public virtual tbl_incotermDto incoterm { get; set; }

        public virtual ICollection<tbl_documentDto> documents { get; set; } = new Collection<tbl_documentDto>();
        public virtual ICollection<tbl_shipment_itemDto> shipmentItems { get; set; } = new Collection<tbl_shipment_itemDto>();
    }
}