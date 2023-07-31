using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_master
    {
        public tbl_master()
        {
            containers = new HashSet<tbl_container>();
            documents = new HashSet<tbl_document>();
            houses = new HashSet<tbl_house>();
            notes = new HashSet<tbl_note>();
            milestoneLinks = new HashSet<tbl_milestone_link>();
        }

        public int idtbl_master { get; set; }
        public string tbl_master_code { get; set; }
        public string tbl_master_bookingNumber { get; set; }
        public string tbl_master_billNumber { get; set; }
        public string tbl_master_status { get; set; }
        public string tbl_master_type { get; set; }
        public string tbl_master_transportType { get; set; }
        public string tbl_master_containerMode { get; set; }
        public DateTime? tbl_master_createdDate { get; set; }
        
        public int? tbl_client_header_origin_id { get; set; }
        public string originAgentCode { get; set; }
        public virtual tbl_client_header originAgent { get; set; }

        public int? tbl_client_header_destination_id { get; set; }
        public string destinationAgentCode { get; set; }
        public virtual tbl_client_header destinationAgent { get; set; }
        
        public int? tbl_client_header_carrier_id { get; set; }
        public string carrierAgentCode { get; set; }
        public virtual tbl_client_header carrierAgent { get; set; }

        public int? tbl_client_header_creditor_id { get; set; }
        public string creditorAgentCode { get; set; }
        public virtual tbl_client_header creditorAgent { get; set; }

        public int? tbl_voyage_id { get; set; }
        public string VoyageCode { get; set; }
        public virtual tbl_voyage voyage { get; set; }
        
        public virtual ICollection<tbl_container> containers { get; set; }
        public virtual ICollection<tbl_document> documents { get; set; }
        public virtual ICollection<tbl_house> houses { get; set; }
        public virtual ICollection<tbl_note> notes { get; set; }
        public virtual ICollection<tbl_milestone_link> milestoneLinks { get; set;}
    }
}
