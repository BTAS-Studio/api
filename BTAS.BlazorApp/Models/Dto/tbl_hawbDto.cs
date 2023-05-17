using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Dto
{
	public class tbl_hawbDto
	{
		[JsonProperty("Id")]
		[DoNotInclude]
		public int idtbl_hawb { get; set; }

		[JsonProperty("HawbNumber")]
		[StringLength(30)]
		[Description("HAWB reference number")]
		public string tbl_hawb_reference { get; set; }
		[JsonProperty("HouseBillNumber")]
		[StringLength(30)]
		[Description("HAWB bill number")]
		public string tbl_hawb_billNumber { get; set; }
		[StringLength(50)]
		[JsonProperty("Status")]
		[Description("HAWB status")]
		[RegularExpression("Open|Posted")]
		public string tbl_hawb_status { get; set; }

		[StringLength(50)]
		[JsonProperty("ConsignorCode")]
		[Description("Consignor address numnber")]
		public string tbl_hawb_consignor { get; set; }
		[StringLength(50)]
		[JsonProperty("ConsigneeCode")]
		[Description("Consignee address number")]
		public string tbl_hawb_consignee { get; set; }
		[StringLength(50)]
		[JsonProperty("DeliveryAddressCode")]
		[Description("Delivery address number")]
		public string tbl_hawb_delivery { get; set; }

		[StringLength(30)]
		[JsonProperty("IncotermsCode")]
		[Description("Linked incoterms code")]
		public string tbl_hawb_incotermCode { get; set; }
		[StringLength(50)]
		[JsonProperty("AirJobReference")]
		[Description("HAWB job reference number")]
		public string tbl_hawb_airJobReference { get; set; }
		[StringLength(50)]
		[JsonProperty("ShipperId")]
		[Description("HAWB shipper code")]
		public string tbl_hawb_shipperId { get; set; }
		[JsonProperty("Weight")]
		[Description("Total weight")]
		public decimal tbl_hawb_weight { get; set; }
		[JsonProperty("Length")]
		[Description("Total length")]
		public decimal tbl_hawb_length { get; set; }
		[JsonProperty("Width")]
		[Description("Total width")]
		public decimal tbl_hawb_width { get; set; }
		[JsonProperty("Height")]
		[Description("Total height")]
		public decimal tbl_hawb_height { get; set; }
		[JsonProperty("Pieces")]
		[Description("Total quantity")]
		public int tbl_hawb_pieces { get; set; }
		[JsonProperty("Volume")]
		[Description("Total volume")]
		public decimal tbl_hawb_volume { get; set; }
		[StringLength(50)]
		[JsonProperty("OriginAirport")]
		[Description("Origin airport")]
		public string tbl_hawb_originAirport { get; set; }
		[StringLength(50)]
		[JsonProperty("DestinationAirport")]
		[Description("Destination airport")]
		public string tbl_hawb_destinationAirport { get; set; }
		[JsonProperty("Value")]
		[Description("Total value")]
		public int tbl_hawb_value { get; set; }
		[StringLength(150)]
		[JsonProperty("Description")]
		[Description("HAWB description")]
		public string tbl_hawb_description { get; set; }
		[StringLength(150)]
		[JsonProperty("NativeDescription")]
		[Description("HAWB native description")]
		public string tbl_hawb_native_description { get; set; }
		[JsonProperty("FTA")]
		public byte tbl_hawb_FTA { get; set; }
		[StringLength(50)]
		[JsonProperty("ShipperReference")]
		[Description("Shipper reference")]
		public string tbl_hawb_shipperRef { get; set; }
		[StringLength(50)]
		[JsonProperty("ColoaderCode")]
		[Description("Coloader code")]
		public string tbl_hawb_coloaderCode { get; set; }
		[StringLength(50)]
		[JsonProperty("LatestTracking")]
		[Description("Latest tracking")]
		public string tbl_hawb_latestTracking { get; set; }
		[JsonProperty("Timestamp")]
		public DateTime tbl_hawb_timestamp { get; set; }
		[StringLength(50)]
		[JsonProperty("ServiceCode")]
		[Description("Service code")]
		[RegularExpression("no.carrier|APG.EPARCEL.DOM.AU|FW.DOM.COURIER.AU|UBI.CN2UKE2E.ROM|BOR.EXP.PARCEL.NSW|AUST.3PL.EDI.AU|AUST.AMA.EDI.AU|AUST.TRK.EDI.AU|NZ.INT.COURIER.ECON|NZ.INT.COURIER.ONIGHT|AUST.ALD.EDI.AU")]
		public string tbl_hawb_serviceCode { get; set; }
		[JsonProperty("DeliveryDate")]
		[Description("Delivery date")]
		public DateTime tbl_hawb_deliverydate { get; set; }
		[StringLength(150)]
		[JsonProperty("DeliveryInstructions")]
		[Description("Delivery additional instructions")]
		public string tbl_hawb_deliveryInstructions { get; set; }
		[StringLength(50)]
		[JsonProperty("ClearanceDate")]
		[Description("Date cleared")]
		public string tbl_hawb_clearancedate { get; set; }
		[JsonProperty("COO")]
		public byte tbl_hawb_coo { get; set; }
		[StringLength(50)]
		[JsonProperty("Type")]
		public string tbl_hawb_type { get; set; }
		[JsonProperty("TailLiftOrigin")]
		public byte tbl_hawb_tailLiftO { get; set; }
		[JsonProperty("TailLiftDestination")]
		public byte tbl_hawb_tailLiftD { get; set; }
		[JsonProperty("DG")]
		public byte tbl_hawb_DG { get; set; }

		[JsonProperty("UN")]
		public string tbl_hawb_UN { get; set; }
		[StringLength(50)]
		[JsonProperty("Packaging")]
		public string tbl_hawb_packaging { get; set; }
		[StringLength(50)]
		[JsonProperty("Class")]
		[Description("HAWB classifications")]
		public string tbl_hawb_class { get; set; }
		[StringLength(50)]
		[JsonProperty("Currency")]
		public string tbl_hawb_currency { get; set; }

		[JsonProperty("MawbId")]
		[DoNotInclude]
		public int? tbl_mawb_id { get; set; }
		[JsonProperty("MawbNumber")]
		[StringLength(30)]
		[Optional]
		[Description("Linked MAWB reference number")]
		public string mawbNumber { get; set; }
		[JsonProperty("mawb")]
		[Optional]
		[Description("Json array of linked MAWB")]
		public virtual tbl_mawbDto tbl_mawb { get; set; }

		[JsonProperty("ContainerId")]
		[DoNotInclude]
		public int? tbl_container_id { get; set; }
		[JsonProperty("ContainerNumber")]
		[StringLength(30)]
		[Optional]
		[Description("Linked container reference number")]
		public string containerNumber { get; set; }
		[JsonProperty("container")]
		[Optional]
		[Description("Json array of linked container details")]
		public virtual tbl_containerDto tbl_container { get; set; }
		[JsonProperty("Documents")]
		[Optional]
		[Description("Json array of linked documents")]
		public virtual ICollection<tbl_documentsDto> documents { get; set; } = new Collection<tbl_documentsDto>();
		public virtual ICollection<tbl_hawb_itemsDto> hawbItems { get; set; } = new Collection<tbl_hawb_itemsDto>();
		public virtual ICollection<tbl_receptacleDto> receptacles { get; set; } = new Collection<tbl_receptacleDto>();
	}
}
