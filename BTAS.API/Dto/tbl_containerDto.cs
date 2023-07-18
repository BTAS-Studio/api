using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BTAS.API.Dto
{
    public class tbl_containerDto
    {
        [JsonProperty("Id")]
        [JsonIgnore]
        public int idtbl_container { get; set; }

        [StringLength(50)]
        [JsonProperty("Code")]
        [Description("Container code")]
        public string tbl_container_code { get; set; }

        [StringLength(50)]
        [JsonProperty("Status")]
        [Description("Container current status")]
        public string tbl_container_status { get; set; }

        [StringLength(50)]
        [JsonProperty("Number")]
        [Description("Container number")]
        public string tbl_container_number { get; set; }

        [StringLength(50)]
        [JsonProperty("ISOType")]
        [Description("Container ISO type")]
        public string tbl_container_isoType { get; set; }

        [StringLength(50)]
        [JsonProperty("CargoType")]
        [Description("Container cargo type")]
        public string tbl_container_cargoType { get; set; }

        [StringLength(50)]
        [JsonProperty("SealNumber")]
        [Description("Container seal number")]
        public string tbl_container_sealNumber { get; set; }

        [JsonProperty("Quantity")]
        [Description("Container quantity")]
        public int? tbl_container_qty { get; set; }

        [JsonProperty("GrossWeight")]
        [Description("Container gross weight")]
        public decimal? tbl_container_grossWeight { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime? tbl_container_createdDate { get; set; }

        [StringLength(50)]
        [JsonProperty("SealedBy")]
        [Description("Person who sealed the container")]
        public string tbl_container_sealedBy { get; set; }


        [JsonProperty("MasterId")]
        [JsonIgnore]
        public int? tbl_master_id { get; set; }
        [StringLength(50)]
        [JsonProperty("MasterCode")]
        [Description("Master waybill linked to this container")]
        public string MasterCode { get; set; }
        [JsonProperty("Master")]
        [Description("Json array of Master waybill linked to this container")]
        public virtual tbl_masterDto master { get; set; }

        public ICollection<tbl_houseDto> houses { get; set; } = new Collection<tbl_houseDto>();
    }
}
