using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Models.Dto
{
    public class tbl_documentsDto
    {
		public int idtbl_documents { get; set; }
		public int mawb_reference { get; set; }
		public int hawb_reference { get; set; }
		public int lowers_reference { get; set; }
		public string document { get; set; }
		public string status { get; set; }
		public DateTime date_added { get; set; }
		public string added_by { get; set; }

		public virtual tbl_mawbDto tbl_mawb { get; set; }
		public virtual tbl_hawbDto tbl_hawb { get; set; }
		public virtual tbl_parcel_infoDto tbl_parcel_info { get; set; }
	}
}
