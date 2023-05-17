using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BTAS.API.Dto
{
	public class tbl_house_itemDto
	{
		[JsonProperty("Id")]
		[DoNotInclude]
		public int idtbl_house_item { get; set; }
		[JsonProperty("Code")]
		[StringLength(50)]
		public string house_item_code { get; set; }
		[StringLength(50)]
		[JsonProperty("Type")]
		public string tbl_house_item_type { get; set; }
		[JsonProperty("Quantity")]
		public int tbl_house_item_qty { get; set; }
		[JsonProperty("Weight")]
		public decimal tbl_house_item_weight { get; set; }
		[StringLength(50)]
		[JsonProperty("WeightUnit")]
		public string tbl_house_item_weightUnit { get; set; }
		[JsonProperty("Length")]
		public decimal tbl_house_item_length { get; set; }
		[JsonProperty("Width")]
		public decimal tbl_house_item_width { get; set; }
		[JsonProperty("Height")]
		public decimal tbl_house_item_height { get; set; }
		[StringLength(50)]
		[JsonProperty("VolumeUnit")]
		public string tbl_house_item_volumeUnit { get; set; }
		[JsonProperty("DangerousGoods")]
		public byte tbl_house_item_dg { get; set; }
		[StringLength(150)]
		[JsonProperty("Description")]
		public string tbl_house_item_description { get; set; }

		[JsonProperty("HouseId")]
		[DoNotInclude]
		public int? tbl_house_id { get; set; }
		[StringLength(30)]
		[JsonProperty("HouseCode")]
		public string HouseCode { get; set; }
		public virtual tbl_houseDto house { get; set; }

		public virtual ICollection<tbl_item_skuDto> itemSkus { get; set; } = new Collection<tbl_item_skuDto>();
	}
}
