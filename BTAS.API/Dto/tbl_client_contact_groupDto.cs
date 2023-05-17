using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BTAS.API.Dto
{
	public class tbl_client_contact_groupDto
	{
		[JsonProperty("Id")]
		[DoNotInclude]
		public int idtbl_client_contact_group { get; set; }
		//public int tbl_client_header_id { get; set; }
		[JsonProperty("GroupCode")]
		[Description("Contact group reference code")]
		public int tbl_client_contact_group_code { get; set; }
		[JsonProperty("IsDefault")]
		[Description("Indicate if contact group is the default")]
		public bool? tbl_client_contact_group_isDefault { get; set; }
		[JsonProperty("IsActive")]
		[Description("Indicate if contact group is active or inactive")]
		[RegularExpression("True|False")]
		public bool? tbl_client_contact_group_isActive { get; set; }
		//[DoNotInclude]
		public virtual ICollection<tbl_client_contact_detailDto> contactDetails { get; set; } = new Collection<tbl_client_contact_detailDto>();
	}
}
