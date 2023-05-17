using Newtonsoft.Json;

namespace BTAS.API.Dto
{
    public class tbl_servicesDto
    {
        [JsonProperty("Id")]
        public int tbl_services_id { get; set; }
        [JsonProperty("Name")]
        public string tbl_services_name { get; set; }
        [JsonProperty("Code")]
        public string tbl_services_code { get; set; }
        [JsonProperty("CarrierId")]
        public string tbl_services_carrierId { get; set; }
        [JsonProperty("IsActive")]
        public bool tbl_services_active { get; set; }
        [JsonProperty("CarrierAccount")]
        public string tbl_services_carrierAccount { get; set; }
        [JsonProperty("CarrierCode")]
        public string tbl_services_carrierCode { get; set; }
        [JsonProperty("Prefix")]
        public string tbl_services_prefixCode { get; set; }
    }
}
