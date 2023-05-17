using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Dto
{
	public class tbl_hawb_itemsDto
	{
		public int idtbl_hawb_items { get; set; }

		public int tbl_hawb_id { get; set; }
		public virtual tbl_hawbDto tbl_hawb { get; set; }

		public decimal tbl_hawb_items_weight { get; set; }
		public decimal tbl_hawb_items_length { get; set; }
		public decimal tbl_hawb_items_width { get; set; }
		public decimal tbl_hawb_items_height { get; set; }
		[StringLength(50)]
		public string tbl_hawb_items_weightUnit { get; set; }
		[StringLength(50)]
		public string tbl_hawb_items_lenghtUnit { get; set; }
		public byte tbl_hawb_items_dg { get; set; }
		[StringLength(150)]
		public string tbl_hawb_items_description { get; set; }
		[StringLength(50)]
		public string tbl_hawb_items_type { get; set; }
		[StringLength(50)]
		public string tbl_hawb_items_reference { get; set; }
		public int tbl_hawb_items_qty { get; set; }
	}
}
