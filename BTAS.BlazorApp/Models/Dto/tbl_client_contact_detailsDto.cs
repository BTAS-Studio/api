using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Dto
{
	public class tbl_client_contact_detailsDto
	{
		
		public int idtbl_client_contact_detail { get; set; }
		[StringLength(50)]
		public string tbl_client_contact_details_first_name { get; set; }
		[StringLength(50)]
		public string tbl_client_contact_details_last_name { get; set; }
		[StringLength(50)]
		public string tbl_client_contact_details_tel { get; set; }
		[StringLength(50)]
		public string tbl_client_contact_details_email { get; set; }
		[StringLength(50)]
		public string tbl_client_contact_details_position { get; set; }
		[StringLength(50)]
		public string tbl_client_contact_details_type { get; set; }
		public byte tbl_client_contact_details_active { get; set; }

        public int tbl_client_header_id { get; set; }
        public virtual tbl_client_headerDto tbl_client_header { get; set; }

		public virtual ICollection<tbl_client_contact_groupDto> contactGroups { get; set; } = new Collection<tbl_client_contact_groupDto>();
	}
}
