using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BTAS.API.Dto
{
    //Edited by HS on 11/01/2023
	public class tbl_client_contact_detailDto
	{
        [JsonProperty("Id")]
        [JsonIgnore]
        public int idtbl_client_contact_detail { get; set; }
        [StringLength(50)]
		[JsonProperty("Code")]
		[Description("Contact details code")]
        public string tbl_client_contact_detail_code { get; set; }
        [JsonProperty("IsActive")]
        [Description("Contact details active or inactive")]
        //[RegularExpression("true|false")]
        public bool? tbl_client_contact_detail_isActive { get; set; }
        [StringLength(50)]
        [JsonProperty("Type")]
        [Description("Contact details type")]
        //[RegularExpression("Staff|Service")]
        public string tbl_client_contact_detail_type { get; set; }
        [StringLength(50)]
		[JsonProperty("CompanyName")]
		[Description("Contact details company name")]
		public string tbl_client_contact_detail_companyName { get; set; }
		[StringLength(50)]
        [JsonProperty("ContactName")]
        [Description("Contact details contact name")]
        public string tbl_client_contact_detail_contactName { get; set; }
        [StringLength(50)]
        [JsonProperty("ContactNumber")]
		[Description("Contact details telephone or mobile number")]
		public string tbl_client_contact_detail_phone { get; set; }
		[StringLength(50)]
		[JsonProperty("ContactEmail")]
		[Description("Contact details email address")]
		public string tbl_client_contact_detail_email { get; set; }

        [JsonProperty("ClientId")]
        [Description("Set Client Header Id to link/relate this client")]
        [JsonIgnore]
        public int? tbl_client_header_id { get; set; }
        [StringLength(50)]
        [JsonProperty("ClientHeaderCode")]
        [Description("A reference to link this contact to its client")]
        public string ClientHeaderCode { get; set; }
		public virtual tbl_client_headerDto clientHeader { get; set; }
       
        public virtual ICollection<tbl_client_contact_groupDto> contactGroups { get; set; } = new Collection<tbl_client_contact_groupDto>();
    }
}
