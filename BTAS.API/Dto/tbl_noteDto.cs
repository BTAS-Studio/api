using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BTAS.API.Dto
{
    public class tbl_noteDto
    {
        public int idtbl_note { get; set; }
        public string tbl_note_code { get; set; }
        public bool tbl_note_status { get; set; }
        public string tbl_note_title { get; set; }

        public string tbl_note_description { get; set; }
        public DateTime tbl_note_createdDate { get; set; }

        public int? tbl_master_id { get; set; }
        public string MasterCode { get; set; }
        public int? tbl_house_id { get; set; }
        public string HouseCode { get; set; }
        public int? tbl_shipment_id { get; set; }
        public string ShipmentCode { get; set; }
        public int? tbl_client_header_id { get; set; }
        public string ClientHeaderCode { get; set; }
        public virtual tbl_masterDto master { get; set; }
        public virtual tbl_houseDto house { get; set; }
        public virtual tbl_shipmentDto shipment { get; set; }
        public virtual tbl_client_headerDto client_header { get; set; }
        public virtual int? tbl_note_category_id { get; set; }
        public virtual string NoteCategoryCode { get; set; }
        public virtual tbl_note_categoryDto note_category { get; set; }
        public virtual ICollection<tbl_documentDto> documents { get; set; } = new Collection<tbl_documentDto>();
        //ICollection of notes to be added in according tables.
    }
}
