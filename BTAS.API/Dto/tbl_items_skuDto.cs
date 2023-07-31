using BTAS.Data.Models;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BTAS.API.Dto
{
    public class tbl_item_skuDto
    {
		[JsonProperty("Id")]
        [JsonIgnore]
        public int idtbl_item_sku { get; set; }
		[JsonProperty("Code")]
		[StringLength(50)]
		public string tbl_item_sku_code { get; set; }  
        [JsonProperty("Weight")]
        public decimal? tbl_items_weight { get; set; }
        [StringLength(50)]
		[JsonProperty("WeightUnit")]
		public string tbl_items_weightUnit { get; set; }
        [JsonProperty("Length")]
        public decimal? tbl_items_length { get; set; }
        [JsonProperty("Width")]
        public decimal? tbl_items_width { get; set; }
        [JsonProperty("Height")]
        public decimal? tbl_items_height { get; set; }
        [JsonProperty("Volume")]
        public decimal? tbl_items_volume { get; set; }
        [StringLength(50)]
		[JsonProperty("VolumeUnit")]
		public string tbl_items_volumeUnit { get; set; }
		[JsonProperty("Quantity")]
		public int? tbl_items_qty { get; set; }
		[StringLength(150)]
		[JsonProperty("Description")]
		public string tbl_items_description { get; set; }
		[StringLength(150)]
		[JsonProperty("NativeDescription")]
		public string tbl_items_nativeDescription { get; set; }
		[StringLength(50)]
		[JsonProperty("HsCode")]
		public string tbl_items_hsCode { get; set; }
		[StringLength(50)]
		[JsonProperty("OriginCountry")]
		public string tbl_items_originCountry { get; set; }
		[JsonProperty("Value")]
		public decimal? tbl_items_value { get; set; }
		[StringLength(50)]
		[JsonProperty("ProductUrl")]
		public string tbl_items_productUrl { get; set; }
		[StringLength(50)]
		[JsonProperty("BatteryType")]
		public string tbl_items_batteryType { get; set; }
		[StringLength(50)]
		[JsonProperty("BatteryPacking")]
		public string tbl_items_batteryPacking { get; set; }
		[JsonProperty("DangerousGoods")]
		public bool? tbl_items_dangerousGoods { get; set; }
		[StringLength(50)]
		[JsonProperty("BatchNumber")]
		public string tbl_items_batchNumber { get; set; }
		//[JsonProperty("HouseItemsId")]
		//      public int? tbl_house_items_id { get; set; }
		//[JsonProperty("HouseItemsCode")]
		//      [StringLength(50)]
		//      public string HouseItemsCode { get; set; }
		//[JsonProperty("ShipmentItemsId")]
		//      public int? tbl_shipment_item_id { get; set; }
		//[JsonProperty("ShipmentItemsCode")]
		//      [StringLength(50)]
		//      public string ShipmentItemsCode { get; set; }
		public virtual ICollection<tbl_house_itemDto> houseItems { get; set; } = new Collection<tbl_house_itemDto>();
		public virtual ICollection<tbl_shipment_itemDto> shipmentItems { get; set; } = new Collection<tbl_shipment_itemDto>();
	}
}