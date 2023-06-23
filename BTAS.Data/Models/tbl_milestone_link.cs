using System;

namespace BTAS.Data.Models
{
    public class tbl_milestone_link
    {
        public int idtbl_milestone_link { get; set; }
        public string tbl_milestone_link_code { get; set; }
        public DateTime? tbl_milestone_link_value { get; set; }
        public string tbl_milestone_link_createdBy { get; set; }
        public DateTime? tbl_milestone_link_createdDate { get; set; }
        public int? tbl_milestone_header_id { get; set; }
        public string MilestoneHeaderCode { get; set; }
        public int? tbl_master_id { get; set; }
        public string MasterCode { get; set; }
        public int? tbl_house_id { get; set; }
        public string HouseCode { get; set; }
        public int? tbl_shipment_id { get; set; }
        public string ShipmentCode { get; set; }
        public virtual tbl_milestone_header milestoneHeader{ get; set;}
        public virtual tbl_master master { get; set; }
        public virtual tbl_house house { get; set;}
        public virtual tbl_shipment shipment { get; set; }
    }
}
