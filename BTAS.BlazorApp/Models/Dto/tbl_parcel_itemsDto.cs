using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Dto
{
    public class tbl_parcel_itemsDto
    {
		public int idtbl_parcel_items { get; set; }
		public int tbl_parcel_items_info_id { get; set; }
		public virtual tbl_parcel_infoDto tbl_parcel_info { get; set; }

		public decimal tbl_parcel_items_parcelWeight { get; set; }
		public decimal tbl_parcel_items_parcelLength { get; set; }
		public decimal tbl_parcel_items_parcelWidth { get; set; }
		public decimal tbl_parcel_items_parcelHeight { get; set; }
		[StringLength(50)]
		public string tbl_parcel_items_parcelWeightUnit { get; set; }
		[StringLength(50)]
		public string tbl_parcel_items_parcelDimensionUnit { get; set; }
		public byte tbl_parcel_items_parcelDangerousGoods { get; set; }
		[StringLength(150)]
		public string tbl_parcel_items_parcelDescription { get; set; }
		[StringLength(50)]
		public string tbl_parcel_items_parcelType { get; set; }
		[StringLength(50)]
		public string tbl_parcel_items_parcelReference { get; set; }
		public int tbl_parcel_items_parcelQty { get; set; }
		public int tbl_items_sku_id { get; set; }
		public virtual tbl_items_skuDto tbl_items_sku { get; set; }
	}
}
