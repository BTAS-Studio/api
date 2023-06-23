using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.API.Dto
{
    public class tbl_noteDto
    {
        [JsonProperty("Id")]
        [DoNotInclude]
        public int idtbl_note { get; set; }

        [StringLength(50)]
        [JsonProperty("Code")]
        public string tbl_note_code { get; set; }

        [JsonProperty("Status")]
        [Required]
        public bool? tbl_note_status { get; set; }

        [StringLength(50)]
        [JsonProperty("Title")]
        public string tbl_note_title { get; set; }

        [StringLength(150)]
        [JsonProperty("Description")]
        public string tbl_note_description { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime? tbl_note_createdDate { get; set; }


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

        [JsonProperty("ClientId")]
        public int? tbl_client_header_id { get; set; }

        [StringLength(50)]
        [JsonProperty("ClientCode")]
        public string ClientHeaderCode { get; set; }

        public virtual tbl_masterDto master { get; set; }
        public virtual tbl_houseDto house { get; set; }
        public virtual tbl_shipmentDto shipment { get; set; }
        public virtual tbl_client_headerDto client_header { get; set; }

        [JsonProperty("NoteCategoryId")]
        public int? tbl_note_category_id { get; set; }

        [StringLength(50)]
        [JsonProperty("NoteCategoryCode")]
        public string NoteCategoryCode { get; set; }

        public virtual tbl_note_categoryDto note_category { get; set; }
        public virtual ICollection<tbl_documentDto> documents { get; set; } = new Collection<tbl_documentDto>();
        //ICollection of notes to be added in according tables.
    }
}
