using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_voyage
    {
        public tbl_voyage()
        {
            masters = new HashSet<tbl_master>();
            routings = new HashSet<tbl_routing>();
        }

        public int idtbl_voyage { get; set; }
        public string tbl_voyage_code { get; set; }
        public string tbl_voyage_type { get; set; }
        public string tbl_voyage_status { get; set; }
        public string tbl_voyage_vesselNumber { get; set; }
        public string tbl_voyage_number { get; set; }
        public string tbl_voyage_carrierCode { get; set; }
        public string tbl_voyage_loadPort { get; set; }
        public string tbl_voyage_dischargePort { get; set; }
        public string tbl_voyage_destinationPort { get; set; }
        public DateTime tbl_voyage_etd { get; set; }
        public DateTime tbl_voyage_eta { get; set; }
        public DateTime? tbl_voyage_etaDischarge { get; set; }
        public DateTime tbl_voyage_atd { get; set; }
        public DateTime tbl_voyage_ata { get; set; }

        public virtual ICollection<tbl_master> masters { get; set; }
        public virtual ICollection<tbl_routing> routings { get; set; }
    }
}
