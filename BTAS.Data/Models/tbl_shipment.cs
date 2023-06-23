using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_shipment
    {
        public tbl_shipment()
        {
            shipmentItems = new HashSet<tbl_shipment_item>();
            billings = new HashSet<tbl_shipping_billing>();
            notes = new HashSet<tbl_note>();
            milestoneLinks = new HashSet<tbl_milestone_link>();
        }

        public int idtbl_shipment { get; set; }
        public string tbl_shipment_code { get; set; }
        public string tbl_shipment_status { get; set; }
        public string tbl_shipment_batchCode { get; set; }
        public string tbl_shipment_shipperCode { get; set; }
        public string tbl_shipment_trackingNo { get; set; }
        public string tbl_shipment_referenceNo { get; set; }
        public string tbl_shipment_description { get; set; }
        public string tbl_shipment_nativeDescription { get; set; }
        public string tbl_shipment_facility { get; set; }
        public string tbl_shipment_instruction { get; set; }
        public string tbl_shipment_invoiceCurrency { get; set; }
        public decimal? tbl_shipment_invoiceValue { get; set; }
        public string tbl_shipment_phone { get; set; }
        public string tbl_shipment_platform { get; set; }
        public string tbl_shipment_serviceCode { get; set; }
        public string tbl_shipment_serviceOption { get; set; }
        public bool? tbl_shipment_authorityToLeave { get; set; }
        public string tbl_shipment_incoterm { get; set; }
        public string tbl_shipment_shipmentItems { get; set; }
        public string tbl_shipment_vendorId { get; set; }
        public bool? tbl_shipment_gstExemptionCode { get; set; }
        public string tbl_shipment_abnNumber { get; set; }
        public string tbl_shipment_sortCode { get; set; }
        public decimal? tbl_shipment_coverAmount { get; set; }
        public string tbl_shipment_orderItems { get; set; }
        public bool? tbl_shipment_hasLockerService { get; set; }
        public string tbl_shipment_warehouse { get; set; }
        public DateTime? tbl_shipment_createdDate { get; set; }
        public DateTime? tbl_shipment_readyDate { get; set; }
        public bool? tbl_shipment_dg { get; set; }
        public string tbl_shipment_dgClass { get; set; }
        public string tbl_shipment_dgUn { get; set; }
        public string tbl_shipment_dgPackaging { get; set; }
        public bool? tbl_shipment_tailLiftO { get; set; }
        public bool? tbl_shipment_tailLiftD { get; set; }
        public string tbl_shipment_deliveryName { get; set; }
        public string tbl_shipment_deliveryPhone { get; set; }
        public string tbl_shipment_deliveryEmail { get; set; }
        public string tbl_shipment_deliveryContact { get; set; }
        public string tbl_shipment_deliveryContactPhone { get; set; }
        public string tbl_shipment_deliveryContactEmail { get; set; }
        public string tbl_shipment_deliveryCompany { get; set; }
        public string tbl_shipment_deliveryAddressLine1 { get; set; }
        public string tbl_shipment_deliveryAddressLine2 { get; set; }
        public string tbl_shipment_deliveryAddressLine3 { get; set; }
        public string tbl_shipment_deliverySuburb { get; set; }
        public string tbl_shipment_deliveryCity { get; set; }
        public string tbl_shipment_deliveryState { get; set; }
        public string tbl_shipment_deliveryPostcode { get; set; }
        public string tbl_shipment_deliveryCountry { get; set; }
        public string tbl_shipment_deliveryInstructions { get; set; }
        public DateTime? tbl_shipment_deliveryDate { get; set; }
        public string tbl_shipment_shipperName { get; set; }
        public string tbl_shipment_shipperPhone { get; set; }
        public string tbl_shipment_shipperEmail { get; set; }
        public string tbl_shipment_shipperContact { get; set; }
        public string tbl_shipment_shipperCompany { get; set; }
        public string tbl_shipment_shipperAddressLine1 { get; set; }
        public string tbl_shipment_shipperAddressLine2 { get; set; }
        public string tbl_shipment_shipperAddressLine3 { get; set; }
        public string tbl_shipment_shipperCity { get; set; }
        public string tbl_shipment_shipperSuburb { get; set; }
        public string tbl_shipment_shipperState { get; set; }
        public string tbl_shipment_shipperPostcode { get; set; }
        public string tbl_shipment_shipperCountry { get; set; }
        public string tbl_shipment_shipperInstructions { get; set; }
        public string tbl_shipment_returnName { get; set; }
        public string tbl_shipment_returnAddress1 { get; set; }
        public string tbl_shipment_returnAddress2 { get; set; }
        public string tbl_shipment_returnAddress3 { get; set; }
        public string tbl_shipment_returnCity { get; set; }
        public string tbl_shipment_returnState { get; set; }
        public string tbl_shipment_returnPostcode { get; set; }
        public string tbl_shipment_returnCountry { get; set; }
        public string tbl_shipment_returnOption { get; set; }

        //Edit by HS on 25/05/2023
        //public int? tbl_receptable_id { get; set; }
        public int? tbl_receptacle_id { get; set; }
        public string ReceptacleCode { get; set; }
        //Edit by HS on 25/05/2023
        //public virtual tbl_receptacle receptable { get; set; }
        public virtual tbl_receptacle receptacle { get; set; }
        public int? tbl_incoterms_id { get; set; }
        public string IncotermsCode { get; set; }
        public virtual tbl_incoterm incoterm { get; set; }

        public virtual ICollection<tbl_shipment_item> shipmentItems { get; set; }
        public virtual ICollection<tbl_shipping_billing> billings { get; set; }
        public virtual ICollection<tbl_document> documents { get; set; }
        public virtual ICollection<tbl_note> notes { get; set; }
        public virtual ICollection<tbl_milestone_link> milestoneLinks { get; set; }
    }
}
