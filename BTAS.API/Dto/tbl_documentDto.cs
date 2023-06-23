using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace BTAS.API.Dto
{
    public class tbl_documentDto
    {
        [JsonProperty("Id")]
        [DoNotInclude]
        public int idtbl_document { get; set; }

        [StringLength(50)]
        [JsonProperty("Code")]
        public string tbl_document_code { get; set; }

        [JsonProperty("Status")]
        public bool? tbl_document_status { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime? tbl_document_createdDate { get; set; }

        [StringLength(50)]
        [JsonProperty("Name")]
        public string tbl_document_name { get; set; }

        [StringLength(50)]
        [JsonProperty("Extension")]
        public string tbl_document_extension { get; set; }

        [StringLength(50)]
        [JsonProperty("Group")]
        public string tbl_document_group { get; set; }

        [StringLength(150)]
        [JsonProperty("Description")]
        public string tbl_document_description { get; set; }

        [JsonProperty("InternalAccess")]
        public bool? tbl_doucument_internalAccess { get; set; }

        [JsonProperty("ExternalAccess")]
        public bool? tbl_doucument_externalAccess { get; set; }

        [StringLength(50)]
        [JsonProperty("BlobToken")]
        public string tbl_document_blobToken { get; set; }

        [StringLength(50)]
        [JsonProperty("Route")]
        public string tbl_document_route { get; set; }

        [StringLength(50)]
        [JsonProperty("UpdatedBy")]
        public string tbl_doucument_updatedBy { get; set; }

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

        [JsonProperty("NoteId")]
        public int? tbl_note_id { get; set; }

        [StringLength(50)]
        [JsonProperty("NoteCode")]
        public string NoteCode { get; set; }

		public virtual tbl_masterDto master { get; set; }
		public virtual tbl_houseDto house { get; set; }
		public virtual tbl_shipmentDto shipment { get; set; }
		public virtual tbl_noteDto note { get; set; }
    }
}
