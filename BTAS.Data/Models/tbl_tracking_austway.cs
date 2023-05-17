using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_tracking_austway
    {
        public int tbl_tracking_id { get; set; }
        public DateTime tbl_tracking_createDate { get; set; }
        public int tbl_tracking_shipmentID { get; set; }
        public string tbl_tracking_prefix { get; set; }
    }
}
