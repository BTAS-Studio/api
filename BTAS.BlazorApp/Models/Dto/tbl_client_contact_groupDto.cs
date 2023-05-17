using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BTAS.BlazorApp.Models.Dto
{
	public class tbl_client_contact_groupDto
	{
		public int idtbl_client_contact_group { get; set; }
		//public int tbl_client_header_id { get; set; }
		public int tbl_client_contact_group_number { get; set; }
		public byte tbl_client_contact_group_default { get; set; }
		public byte tbl_client_contact_group_active { get; set; }

		public virtual ICollection<tbl_client_contact_detailsDto> contactDetails { get; set; } = new Collection<tbl_client_contact_detailsDto>();
	}
}
