using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.API.Dto
{
    public class tbl_milestone_headerDto
    {
        [JsonProperty("Id")]
        [JsonIgnore]
        public int idtbl_milestone_header { get; set; }

        [StringLength(50)]
        [JsonProperty("Code")]
        public string tbl_milestone_header_code { get; set; }

        [StringLength(50)]
        [JsonProperty("Name")]
        public string tbl_milestone_header_name { get; set; }

        [StringLength(50)]
        [JsonProperty("Description")]
        public string tbl_milestone_header_description { get; set; }

        [StringLength(50)]
        [JsonProperty("CreatedBy")]
        public string tbl_milestone_header_createdBy { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime? tbl_milestone_header_createdDate { get; set; }

        public virtual ICollection<tbl_milestone_linkDto> milestoneLinks { get; set; } = new Collection<tbl_milestone_linkDto>();
    }
}
