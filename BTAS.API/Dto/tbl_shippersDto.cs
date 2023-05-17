using System;
using Newtonsoft.Json;

namespace BTAS.API.Dto
{
    public class tbl_shippersDto
    {
        [JsonProperty("Id")]
        public int tbl_shippers_id { get; set; }
        [JsonProperty("Name")]
        public string tbl_shippers_name { get; set; }
        [JsonProperty("Code")]
        public string tbl_shippers_code { get; set; }
        [JsonProperty("IsActive")]
        public bool? tbl_shippers_active { get; set; } = true;
        [JsonProperty("DateCreated")]
        public DateTime tbl_shippers_creation_date { get; set; }
        [JsonProperty("Country")]
        public string tbl_shippers_country { get; set; }
        [JsonProperty("ShippersCol")]
        public string tbl_shipperscol { get; set; }
        [JsonProperty("Prefix")]
        public string tbl_shippers_prefix { get; set; }
        [JsonProperty("AirPrefix")]
        public string tbl_air_prefix { get; set; }
    }
}
