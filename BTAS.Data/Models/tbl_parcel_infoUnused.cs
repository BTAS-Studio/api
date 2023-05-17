using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_parcel_infoUnused
    {
        public tbl_parcel_infoUnused()
        {
            tbl_documents = new HashSet<tbl_document>();
            tbl_shipping_billings = new HashSet<tbl_shipping_billing>();
        }

        public int idtbl_parcel_info { get; set; }
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
        public decimal? tbl_parcel_info_invoiceValue { get; set; }
        public string tbl_parcel_info_phone { get; set; }
        public string tbl_parcel_info_deliverySuburb { get; set; }
        public string tbl_parcel_info_deliveryPostcode { get; set; }
        public string tbl_parcel_info_deliveryCompany { get; set; }
        public string tbl_parcel_info_deliveryName { get; set; }
        public string tbl_parcel_info_serviceCode { get; set; }
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
        public sbyte tbl_parcel_info_authorityToLeave { get; set; }
        public string tbl_parcel_info_incoterm { get; set; }
        public string tbl_parcel_info_vendorid { get; set; }
        public sbyte? tbl_parcel_info_gstexemptioncode { get; set; }
        public string tbl_parcel_info_abnnumber { get; set; }
        public string tbl_parcel_info_sortCode { get; set; }
        public decimal? tbl_parcel_info_coveramount { get; set; }
        public string tbl_parcel_info_deliveryInstructions { get; set; }
        public sbyte? tbl_parcel_info_lockerService { get; set; }
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
        public string tbl_parcel_info_shipperSuburb { get; set; }
        public string tbl_parcel_info_deliveryPhone { get; set; }
        public string tbl_parcel_info_shipperInstructions { get; set; }
        public string tbl_parcel_info_shipperContact { get; set; }
        public string tbl_parcel_info_warehouse { get; set; }
        public DateTime? tbl_parcel_info_timestamp { get; set; }
        public DateTime? tbl_parcel_info_readyDate { get; set; }
        public bool? tbl_parcel_info_dg { get; set; }
        public string tbl_parcel_info_dgClass { get; set; }
        public string tbl_parcel_info_dgUn { get; set; }
        public string tbl_parcel_info_dgPackaging { get; set; }
        public sbyte? tbl_parcel_info_tailLiftO { get; set; }
        public sbyte? tbl_parcel_info_tailLiftD { get; set; }
        public string tbl_parcel_info_shipperCompany { get; set; }
        public DateTime? tbl_parcel_info_deliveryDate { get; set; }
        public int? tbl_receptacle_id { get; set; }
        public string ReceptacleNumber { get; set; }
        public string tbl_parcel_info_number { get; set; }
        public string tbl_parcel_info_status { get; set; }

        public virtual ICollection<tbl_document> tbl_documents { get; set; }
        public virtual ICollection<tbl_shipping_billing> tbl_shipping_billings { get; set; }
    }
}
