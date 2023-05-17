using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_routing
    {
        public int idtbl_routing { get; set; }
        public DateTime tbl_routing_cutoffDate { get; set; }
        public string tbl_voyage_loadPort { get; set; }
        public string tbl_voyage_dischargePort { get; set; }
        public DateTime tbl_voyage_etd { get; set; }
        public DateTime tbl_voyage_eta { get; set; }
        public DateTime tbl_voyage_atd { get; set; }
        public DateTime tbl_voyage_ata { get; set; }

        public int? tbl_voyage_id { get; set; }
        public string VoyageNumber { get; set; }
        public virtual tbl_voyage voyage { get; set; }
    }
}
