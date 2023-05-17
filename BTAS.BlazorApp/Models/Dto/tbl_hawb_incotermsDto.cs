using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Dto
{
	public class tbl_hawb_incotermsDto
	{
		public int idtbl_hawb_incoterms { get; set; }
		[StringLength(50)]
		public string tbl_hawb_incoterms_code { get; set; }
		[StringLength(150)]
		public string tbl_hawb_incoterms_description { get; set; }
	}
}
