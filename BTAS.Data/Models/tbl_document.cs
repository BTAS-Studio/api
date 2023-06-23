using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_document
    {

        public int idtbl_document { get; set; }
        public string tbl_document_code { get; set; }
        public bool? tbl_document_status { get; set; }
        public DateTime? tbl_document_createdDate { get; set; }
        public string tbl_document_name { get; set; }
        public string tbl_document_extension { get; set; }
        public string tbl_document_group { get; set; }
        public string tbl_document_description { get; set; }
        public bool? tbl_doucument_internalAccess { get; set; }
        public bool? tbl_doucument_externalAccess { get; set; }
        public string tbl_document_blobToken { get; set; }
        public string tbl_document_route { get; set; }
        public string tbl_doucument_updatedBy { get; set; }

        public int? tbl_master_id { get; set; }
        public string MasterCode { get; set; }
        public int? tbl_house_id { get; set; }
        public string HouseCode { get; set; }
        public int? tbl_shipment_id { get; set; }
        public string ShipmentCode { get; set; }
        public int? tbl_note_id { get; set; }
        public string NoteCode { get; set; }

        public virtual tbl_master master { get; set; }
        public virtual tbl_house house { get; set; }
        public virtual tbl_shipment shipment { get; set; }
        public virtual tbl_note note { get; set; }
    }
}
