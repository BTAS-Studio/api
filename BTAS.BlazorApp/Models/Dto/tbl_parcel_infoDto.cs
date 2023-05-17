using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Models.Dto
{
    public class tbl_parcel_infoDto
    {
		public int idtbl_parcel_info { get; set; }

		public int tbl_receptacle_id { get; set; }
		public virtual tbl_receptacleDto tbl_receptacle { get; set; }

		[StringLength(50)]
		public string tbl_parcel_info_batchId { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperId { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_trackingNo { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_referenceNo { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_deliveryAddressLine1 { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_deliveryAddressLine2 { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_deliveryAddressLine3 { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryCity { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryCountry { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_description { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_nativeDescription { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryEmail { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_facility { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_instruction { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_invoiceCurrency { get; set; }
		public decimal tbl_parcel_info_invoiceValue { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_phone { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_platform { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliverySuburb { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryPostcode { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryCompany { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryName { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_serviceCode { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_serviceOption { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryState { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperName { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_shipperAddressLine1 { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_shipperAddressLine2 { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_shipperAddressLine3 { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperCity { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperState { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperPostcode { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperCountry { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperPhone { get; set; }
		public byte tbl_parcel_info_authorityToLeave { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_incoterm { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_vendorid { get; set; }
		public byte tbl_parcel_info_gstexemptioncode { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_abnnumber { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_sortCode { get; set; }
		public decimal tbl_parcel_info_coveramount { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_orderItems { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryInstructions { get; set; }
		public byte tbl_parcel_info_lockerService { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_returnName { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_returnAddress1 { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_returnAddress2 { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_returnAddress3 { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_returnCity { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_returnState { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_returnPostcode { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_returnCountry { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_returnOption { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_parcelItems { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperEmail { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipment { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryContact { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryContactPhone { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryContactEmail { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperSuburb { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_deliveryPhone { get; set; }
		[StringLength(150)]
		public string tbl_parcel_info_shipperInstructions { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperContact { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_warehouse { get; set; }
		public DateTime tbl_parcel_info_timestamp { get; set; }
		public DateTime tbl_parcel_info_readyDate { get; set; }
		public byte tbl_parcel_info_dg { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_dgClass { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_dgUn { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_dgPackaging { get; set; }
		public byte tbl_parcel_info_tailLiftO { get; set; }
		public byte tbl_parcel_info_tailLiftD { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperCompany { get; set; }
		[StringLength(50)]
		public string tbl_parcel_info_shipperLastName { get; set; }
		public DateTime tbl_parcel_info_deliveryDate { get; set; }

		public ICollection<tbl_parcel_itemsDto> parcelItems { get; set; } = new Collection<tbl_parcel_itemsDto>();
	}
}
