using System;

namespace BTAS.API.Dto
{
    public class tbl_documentDto
    {
		public int idtbl_document { get; set; }

		public string tbl_document_code { get; set; }

		public bool tbl_document_status { get; set; }

		public DateTime tbl_document_createdDate { get; set; }

		public string tbl_document_name { get; set; }

		public string tbl_document_extension { get; set; }

		public string tbl_document_group { get; set; }

		public string tbl_document_description { get; set; }
		public bool tbl_doucument_internalAccess { get; set; }
		public bool tbl_doucument_externalAccess { get; set; }
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
		//public int? tbl_milestone_id { get; set; }
		//public string MilestoneCode { get; set; }
		public virtual tbl_masterDto master { get; set; }
		public virtual tbl_houseDto house { get; set; }
		public virtual tbl_shipmentDto shipment { get; set; }
		public virtual tbl_noteDto note { get; set; }
        //one to one relationship with tbl_milestone
        public int? tbl_milestone_master_id { get; set; }
        public string MilestoneMasterCode { get; set; }
        public virtual tbl_milestone_masterDto milestone_master { get; set; }
    }
}
