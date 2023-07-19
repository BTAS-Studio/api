using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BTAS.API.Dto
{
    public class tbl_shipment_itemDto
    {
        [JsonProperty("Id")]
        [JsonIgnore]
        public int idtbl_shipment_item { get; set; }
        [JsonProperty("Code")]
        [StringLength(50)]
        public string tbl_shipment_item_code { get; set; }
        [JsonProperty("Weight")]
        public decimal tbl_shipment_item_weight { get; set; }
        [StringLength(50)]
        [JsonProperty("WeightUnit")]
        public string tbl_shipment_item_weightUnit { get; set; }
        [StringLength(50)]
        [JsonProperty("Length")]
        public decimal tbl_shipment_item_length { get; set; }
        [JsonProperty("Width")]
        public decimal tbl_shipment_item_width { get; set; }
        [JsonProperty("Height")]
        public decimal tbl_shipment_item_height { get; set; }
        [JsonProperty("VolumeUnit")]
        public string tbl_shipment_item_volumeUnit { get; set; }
        [JsonProperty("IsDangerousGoods")]
        public bool? tbl_shipment_item_dangerousGoods { get; set; }
        [StringLength(150)]
        [JsonProperty("Description")]
        public string tbl_shipment_item_description { get; set; }
        [StringLength(50)]
        [JsonProperty("Type")]
        public string tbl_shipment_item_type { get; set; }
        [JsonProperty("Quantity")]
        public int tbl_shipment_item_qty { get; set; }
        [JsonProperty("ShipmentId")]
        [JsonIgnore]
        public int? tbl_shipment_id { get; set; }
        [JsonProperty("ShipmentCode")]
        [StringLength(30)]
        public string ShipmentCode { get; set; }
        [DoNotInclude]
        public virtual tbl_shipmentDto shipment { get; set; }
        [JsonProperty("Items_Skus")]
        public virtual ICollection<tbl_item_skuDto> items_skus { get; set; } = new Collection<tbl_item_skuDto>();
    }
}
