using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Dto
{
    public class tbl_items_skuDto
    {
		public int idtbl_items_sku { get; set; }
		[StringLength(50)]
		public string tbl_items_weightUnit { get; set; }
		public decimal tbl_items_weight { get; set; }
		[StringLength(50)]
		public string tbl_items_dimensionUnit { get; set; }
		public decimal tbl_items_length { get; set; }
		public decimal tbl_items_width { get; set; }
		public decimal tbl_items_height { get; set; }
		public decimal tbl_items_volume { get; set; }
		public int tbl_items_number { get; set; }
		[StringLength(50)]
		public string tbl_items_skuCode { get; set; }
		[StringLength(150)]
		public string tbl_items_description { get; set; }
		[StringLength(150)]
		public string tbl_items_nativeDescription { get; set; }
		[StringLength(50)]
		public string tbl_items_hsCode { get; set; }
		[StringLength(50)]
		public string tbl_items_originCountry { get; set; }
		public decimal tbl_items_value { get; set; }
		[StringLength(50)]
		public string tbl_items_productUrl { get; set; }
		[StringLength(50)]
		public string tbl_items_batteryType { get; set; }
		[StringLength(50)]
		public string tbl_items_batteryPacking { get; set; }
		public byte tbl_items_dangerousGoods { get; set; }
		[StringLength(50)]
		public string tbl_items_batchNumber { get; set; }
	}
}
