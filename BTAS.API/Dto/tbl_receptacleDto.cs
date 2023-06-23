using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BTAS.API.Dto
{
	public class tbl_receptacleDto
    { 
        [JsonProperty("Id")]
        public int idtbl_receptacle { get; set; }
        [JsonProperty("Code")]
        [StringLength(50)]
        public string tbl_receptacle_code { get; set; }
        [StringLength(50)] 
        [JsonProperty("ShipperCode")]
        public string tbl_receptacle_shipper_code { get; set; }
        [StringLength(50)]
        [JsonProperty("Mode")]
        public string tbl_receptacle_mode { get; set; }
        [StringLength(50)]
        [JsonProperty("Type")]
        public string tbl_receptacle_type { get; set; }
        [JsonProperty("Quantity")]
        public int? tbl_receptacle_qty { get; set; }
        [JsonProperty("Weight")]
        public decimal? tbl_receptacle_weight { get; set; }
        [StringLength(50)]
        [JsonProperty("Status")]
        public string tbl_receptacle_status { get; set; }
        [StringLength(50)]
        [JsonProperty("Origin")]
        public string tbl_receptacle_origin { get; set; }
        [StringLength(50)]
        [JsonProperty("Destination")]
        public string tbl_receptacle_destination { get; set; }
        [JsonProperty("CreatedDate")]
        public DateTime? tbl_receptacle_createdDate { get; set; }
        [JsonProperty("Length")]
        public decimal? tbl_receptacle_length { get; set; }
        [JsonProperty("Width")]
        public decimal? tbl_receptacle_width { get; set; }
        [JsonProperty("Height")]
        public decimal? tbl_receptacle_height { get; set; }

        [JsonProperty("HouseId")]
        public int? tbl_house_id { get; set; }
        [JsonProperty("HouseCode")]
        [StringLength(30)]
        public string HouseCode { get; set; }
        [DoNotInclude]
        public virtual tbl_houseDto house { get; set; }

        [DoNotInclude]
        public virtual ICollection<tbl_shipmentDto> shipments { get; set; } = new Collection<tbl_shipmentDto>();
    }
}
