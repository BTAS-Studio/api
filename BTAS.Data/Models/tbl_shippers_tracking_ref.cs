using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_shippers_tracking_ref
    {
        public int idshippers_tracking_ref { get; set; }
        public DateTime? tbl_shippers_tracking_createDate { get; set; }
        public int? tbl_shippers_tracking_shipmentId { get; set; }
        public string tbl_shippers_tracking_prefix { get; set; }
        public string tbl_shippers_tracking_batch_id { get; set; }
        public decimal? tbl_shippers_tracking_est_cost { get; set; }
    }
}
