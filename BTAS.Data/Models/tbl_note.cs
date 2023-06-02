using System;
using System.Collections.Generic;

namespace BTAS.Data.Models
{
    public partial class tbl_note
    {
        public tbl_note() 
        { 
            documents = new HashSet<tbl_document>();
        }
        public int idtbl_note { get; set; }
        public string tbl_note_code { get; set; }
        public bool tbl_note_status { get; set; }
        public string tbl_note_title { get; set; }
        //public string tbl_note_category { get; set; }
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
        public int? tbl_note_category_id { get; set; }
        public string NoteCategoryCode { get; set; }
        public virtual tbl_master master { get; set; }
        public virtual tbl_house house { get; set; }
        public virtual tbl_shipment shipment { get; set; }
        public virtual tbl_client_header clientHeader { get; set; }
        public virtual tbl_note_category noteCategory { get; set; }
        public virtual ICollection<tbl_document> documents { get; set; }
        //ICollection of notes to be added in according tables.
    }
}
