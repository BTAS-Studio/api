using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BTAS.API.Dto
{
    public class tbl_routingDto
    {
        [JsonProperty("Id")]
        public int idtbl_routing { get; set; }
        
        [JsonProperty("CutoffDate")]
        public DateTime tbl_routing_cutoffDate { get; set; }
        [StringLength(50)]
        [JsonProperty("LoadPort")]
        public string tbl_voyage_loadPort { get; set; }
        [StringLength(50)]
        [JsonProperty("DischargePort")]
        public string tbl_voyage_dischargePort { get; set; }
        [JsonProperty("EDT")]
        public DateTime tbl_voyage_etd { get; set; }
        [JsonProperty("ETA")]
        public DateTime tbl_voyage_eta { get; set; }
        [JsonProperty("ATD")]
        public DateTime tbl_voyage_atd { get; set; }
        [JsonProperty("ATA")]
        public DateTime tbl_voyage_ata { get; set; }

        [JsonProperty("VoyageId")]
        public int? tbl_voyage_id { get; set; }
        [JsonProperty("VoyageNumber")]
        [StringLength(30)]
        public string VoyageNumber { get; set; }
        public virtual tbl_voyageDto voyage { get; set; }
    }
}
