using Newtonsoft.Json;


namespace BTAS.API.Dto
{
    public class tbl_carrier_infoDto
    {
        [JsonProperty("Id")]
        public int idtbl_carrier_info { get; set; }
        [JsonProperty("CarrierName")]
        public string tbl_carrier_name { get; set; }
        [JsonProperty("Address1")]
        public string tbl_carrier_address1 { get; set; }
        [JsonProperty("Address2")]
        public string tbl_carrier_address2 { get; set; }
        [JsonProperty("City")]
        public string tbl_carrier_city { get; set; }
        [JsonProperty("Suburb")]
        public string tbl_carrier_suburb { get; set; }
        [JsonProperty("PostCode")]
        public string tbl_carrier_postCode { get; set; }
        [JsonProperty("State")]
        public string tbl_carrier_state { get; set; }
        [JsonProperty("CountryOrigin")]
        public string tbl_carrier_country_origin { get; set; }
        [JsonProperty("CountryDestination")]
        public string tbl_carrier_country_destination { get; set; }
        [JsonProperty("Email")]
        public string tbl_carrier_email { get; set; }
        [JsonProperty("Phone")]
        public string tbl_carrier_phone { get; set; }
        [JsonProperty("ContactName")]
        public string tbl_carrier_contactName { get; set; }
        [JsonProperty("CarrierCode")]
        public string tbl_carrier_code { get; set; }
        [JsonProperty("CarrierType")]
        public string tbl_carrier_type { get; set; }
        [JsonProperty("IsActive")]
        public bool tbl_carrier_active { get; set; }
    }
}
