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
        [DoNotInclude]
        public int idtbl_client_contact_detail { get; set; }
        [StringLength(50)]
		[JsonProperty("Code")]
		[Description("Contact details code")]
        public string tbl_client_contact_detail_code { get; set; }
        //Edited by HS on 25/01/2023
        [JsonProperty("IsActive")]
        [Description("Contact details active or inactive")]
        [RegularExpression("true|false")]
        public bool tbl_client_contact_detail_isActive { get; set; }
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
		[StringLength(150)]
		//[JsonProperty("Address1")]
		//[Description("Contact details address1")]
		//public string tbl_client_contact_detail_address1 { get; set; }

  //      [StringLength(150)]
  //      [JsonProperty("Address2")]
  //      [Description("Contact details address2")]
  //      public string tbl_client_contact_detail_address2 { get; set; }
  //      [StringLength(50)]
  //      [JsonProperty("Suburb")]
  //      [Description("Contact suburb")]
  //      public string tbl_client_contact_detail_suburb { get; set; }
  //      [StringLength(50)]
  //      [JsonProperty("City")]
  //      [Description("Contact city")]
  //      public string tbl_client_contact_detail_city { get; set; }
  //      [StringLength(50)]
  //      [JsonProperty("State")]
  //      [Description("Contact State")]
  //      public string tbl_client_contact_detail_state { get; set; }
  //      [StringLength(50)]
  //      [JsonProperty("Postcode")]
  //      [Description("Contact postcode")]
  //      public string tbl_client_contact_detail_postcode { get; set; }
  //      [StringLength(50)]
  //      [JsonProperty("Country")]
  //      [Description("Contact country")]
  //      public string tbl_client_contact_detail_country{ get; set; }
        [JsonProperty("ClientId")]
		[Description("Set Client Header Id to link/relate this client")]
		public int? tbl_client_header_id { get; set; }
        [StringLength(50)]
        [JsonProperty("ClientCode")]
        [Description("A reference to link this contact to its client")]
        public string ClientHeaderCode { get; set; }
		public virtual tbl_client_headerDto clientHeader { get; set; }
        [JsonProperty("AddressId")]
        [Description("Set Client Address Id to link/relate this client")]
        //one to one relationship
        public virtual tbl_addressDto address{ get; set; }
        public virtual ICollection<tbl_client_contact_groupDto> contactGroups { get; set; } = new Collection<tbl_client_contact_groupDto>();
	}
}
