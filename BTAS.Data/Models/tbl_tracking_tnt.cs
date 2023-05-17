using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_tracking_tnt
    {
        public int tbl_tracking_tnt_id { get; set; }
        public DateTime? tbl_tracking_tnt_createDate { get; set; }
        public int? tbl_tracking_tnt_shipmentID { get; set; }
        public string tbl_tracking_tnt_prefix { get; set; }
    }
}
