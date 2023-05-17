using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BTAS.API.Dto
{
    public class tbl_manifestDto
    {
        [JsonProperty("Id")]
        public int idtbl_manifest {get; set; }
        [JsonProperty("CreatedDate")]
        public DateTime tbl_manifest_created_date { get; set; } = DateTime.Now;
        [JsonProperty("SentDate")]
        public DateTime tbl_manifest_sent_date { get; set; }
        [JsonProperty("Carrier")]
        public string tbl_manifest_carrier { get; set; }
        [JsonProperty("IsActive")]
        public bool? tbl_manifest_active { get; set; } = true;
        [JsonProperty("Prefix")]
        public string tbl_manifest_prefix { get; set; }
    }
}
