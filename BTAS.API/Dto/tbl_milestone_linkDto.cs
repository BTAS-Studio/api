using BTAS.Data.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace BTAS.API.Dto
{
    public class tbl_milestone_linkDto
    {
        [JsonProperty("Id")]
        [DoNotInclude]
        public int idtbl_milestone_link { get; set; }
        [StringLength(50)]
        [JsonProperty("Code")]
        public string tbl_milestone_link_code { get; set; }

        [JsonProperty("Value")]
        public DateTime? tbl_milestone_link_value { get; set; }

        [StringLength(50)]
        [JsonProperty("CreatedBy")]
        public string tbl_milestone_link_createdBy { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime? tbl_milestone_link_createdDate { get; set; }

        [JsonProperty("MilestoneHeaderId")]
        public int? tbl_milestone_header_id { get; set; }

        [StringLength(50)]
        [JsonProperty("MilestoneHeaderCode")]
        public string MilestoneHeaderCode { get; set; }

        [JsonProperty("MasterId")]
        public int? tbl_master_id { get; set; }

        [StringLength(50)]
        [JsonProperty("MasterCode")]
        public string MasterCode { get; set; }

        [JsonProperty("HouseId")]
        public int? tbl_house_id { get; set; }

        [StringLength(50)]
        [JsonProperty("HouseCode")]
        public string HouseCode { get; set; }

        [JsonProperty("ShipmentId")]
        public int? tbl_shipment_id { get; set; }

        [StringLength(50)]
        [JsonProperty("ShipmentCode")]
        public string ShipmentCode { get; set; }

        public virtual tbl_milestone_headerDto milestoneHeader { get; set; }
        public virtual tbl_master master { get; set; }
        public virtual tbl_house house { get; set; }
        public virtual tbl_shipment shipment { get; set; }
    }
}
