using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Dto
{
	public class tbl_receptacleDto
	{
		public int idtbl_receptacle { get; set; }

		public int? tbl_hawb_id { get; set; }
		public virtual tbl_hawbDto tbl_hawb { get; set; }

		[StringLength(50)]
		public string tbl_receptacle_shipper_id { get; set; }

		[StringLength(50)]
		public string tbl_receptacle_ref { get; set; }
		[StringLength(50)]
		public string tbl_receptacle_mode { get; set; }
		[StringLength(50)]
		public string tbl_receptacle_type { get; set; }
		public int tbl_receptacle_no_items { get; set; }
		public decimal tbl_receptacle_weight { get; set; }
		[StringLength(50)]
		public string tbl_receptacle_status { get; set; }
		[StringLength(50)]
		public string tbl_receptacle_origin { get; set; }
		[StringLength(50)]
		public string tbl_receptacle_dest { get; set; }
		public DateTime tbl_receptacle_creation { get; set; }
		public decimal tbl_receptacle_length { get; set; }
		public decimal tbl_receptacle_width { get; set; }
		public decimal tbl_receptacle_height { get; set; }

		public virtual ICollection<tbl_parcel_infoDto> parcelInfos { get; set; } = new Collection<tbl_parcel_infoDto>();
	}
}
