using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Dto
{
	public class tbl_client_headerDto
	{
        [JsonProperty("Id")]
        public int idtbl_client_header { get; set; }
        [StringLength(50)]
        [JsonProperty("Code")]
        [Description("Client details reference code")]
        public string tbl_client_header_code { get; set; }
        [StringLength(50)]
        [JsonProperty("Name")]
        [Description("Client's name")]
        [Required(ErrorMessage = "Name is required.")]
        public string tbl_client_header_name { get; set; }
        [JsonProperty("IsActive")]
        [Description("Set client details as active or inactive")]
        public bool tbl_client_header_active { get; set; } = true;
        [JsonProperty("IsAgent")]
        [Description("Set client details as agent")]
        public bool tbl_client_header_is_agent { get; set; }
        [JsonProperty("IsConsignee")]
        [Description("Set client details as consignee")]
        public bool tbl_client_header_is_consignee { get; set; }
        [JsonProperty("IsConsignor")]
        [Description("Set client details as consignor")]
        public bool tbl_client_header_is_consignor { get; set; }
        [JsonProperty("IsBroker")]
        [Description("Set client details as broker")]
        public bool tbl_client_header_is_broker { get; set; }
        [JsonProperty("IsCarrier")]
        [Description("Set client details as carrier")]
        public bool tbl_client_header_is_carrier { get; set; }
        [JsonProperty("IsPayable")]
        [Description("Set client details for payables")]
        public bool tbl_client_header_is_payable { get; set; }
        [JsonProperty("IsReceivable")]
        [Description("Set client details for receivables")]
        public bool tbl_client_header_is_receivable { get; set; }
        [JsonProperty("CreatedBy")]
        public int tbl_client_header_created_by { get; set; }
        [JsonProperty("CreatedDate")]
        public DateTime tbl_client_header_created_date { get; set; }
        [StringLength(150)]
        [JsonProperty("Address1")]
        [Required(ErrorMessage = "Address is required.")]
        [Description("Set client details address line #1")]
        public string tbl_client_header_address1 { get; set; }
        [StringLength(150)]
        [JsonProperty("Address2")]
        [Description("Set client details address line #2")]
        public string tbl_client_header_address2 { get; set; }
        [StringLength(50)]
        [JsonProperty("Suburb")]
        [Required(ErrorMessage = "Suburb is required.")]
        [Description("Set client details suburb (if available)")]
        public string tbl_client_header_suburb { get; set; }
        [StringLength(50)]
        [JsonProperty("City")]
        [Required(ErrorMessage = "City is required.")]
        [Description("Set client details city")]
        public string tbl_client_header_city { get; set; }
        [StringLength(50)]
        [JsonProperty("PostCode")]
        [Required(ErrorMessage = "Post code is required.")]
        [Description("Set client details post code")]
        public string tbl_client_header_postcode { get; set; }
        [StringLength(50)]
        [JsonProperty("State")]
        [Description("Set client details state (if available)")]
        public string tbl_client_header_state { get; set; }
        [StringLength(50)]
        [JsonProperty("Country")]
        [Required(ErrorMessage = "Country is required.")]
        [Description("Set client details country")]
        public string tbl_client_header_country { get; set; }
        [StringLength(50)]
        [JsonProperty("Port")]
        [Description("Set client details closest port (if available)")]
        public string tbl_client_header_closest_port { get; set; }
        [StringLength(50)]
        [JsonProperty("ABN")]
        [Description("Set client's ABN")]
        public string tbl_client_header_abn { get; set; }
        [StringLength(50)]
        [JsonProperty("MainEmail")]
        [Required(ErrorMessage = "Email is required.")]
        [Description("Set client's main contact email")]
        public string tbl_client_header_main_email { get; set; }
        [StringLength(50)]
        [JsonProperty("MainPhone")]
        [Required(ErrorMessage = "Contact phone is required.")]
        [Description("Set client's main contact phone")]
        public string tbl_client_header_main_phone { get; set; }
        [StringLength(50)]
        [JsonProperty("MainContact")]
        [Description("Set client's main contact person")]
        public string tbl_client_header_main_contact { get; set; }

        //public int? tbl_mawb_origin_id { get; set; }
        //public virtual tbl_mawb mawbOrigin { get; set; }
        //public int? tbl_mawb_destination_id { get; set; }
        //public virtual tbl_mawb mawbDestination { get; set; }
        //public int? tbl_mawb_carrier_id { get; set; }
        //public virtual tbl_mawb mawbCarrier { get; set; }
        //public int? tbl_mawb_creditor_id { get; set; }
        //public virtual tbl_mawb mawbCreditor { get; set; }
        [JsonProperty("IncotermsId")]
        public int? tbl_hawb_incoterms_id { get; set; }
        [JsonProperty("Incoterms")]
        [Description("A json array of Incoterms request paramaters.")]
        public virtual tbl_hawb_incotermsDto tbl_hawb_incoterms { get; set; }
        [JsonProperty("HawbId")]
        public int? tbl_hawb_id { get; set; }
        [JsonProperty("HawbNumber")]
        [Description("House Bill reference number for cross-searching.")]
        public string HawbNumber { get; set; }
        [JsonProperty("HAWB")]
        [Description("A json array of HAWB request paramaters for auto creating in a single request")]
        public virtual tbl_hawbDto tbl_hawb{ get; set; }
        [JsonProperty("ContactDetails")]
        [Description("A json array of contact details request paramaters for auto creating in a single request.")]
        public virtual ICollection<tbl_client_contact_detailsDto> contactDetails { get; set; } = new Collection<tbl_client_contact_detailsDto>();
    }
}
