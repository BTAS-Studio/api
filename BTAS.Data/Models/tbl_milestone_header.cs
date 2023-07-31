using System;
using System.Collections.Generic;

namespace BTAS.Data.Models
{
    public class tbl_milestone_header
    {
        public tbl_milestone_header() 
        { 
            milestoneLinks = new HashSet<tbl_milestone_link>();
        }
        public int idtbl_milestone_header { get; set; }
        public string tbl_milestone_header_code { get; set; }
        public string tbl_milestone_header_name { get; set; }
        public string tbl_milestone_header_description { get; set; }
        public string tbl_milestone_header_createdBy { get; set; }
        public DateTime? tbl_milestone_header_createdDate { get; set; }
        public virtual ICollection<tbl_milestone_link> milestoneLinks { get; set; }
    }
}
