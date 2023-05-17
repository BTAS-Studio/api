using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BTAS.API.Dto
{
    public class tbl_shippers_tracking_refDto
    {
        public int idshippers_tracking_ref { get; set; }
        public int tbl_shippers_tracking_shipmentId { get; set; }
        public string tbl_shippers_tracking_prefix { get; set; }
        public string tbl_shippers_tracking_batch_id { get; set; }
        public DateTime tbl_shippers_tracking_createDate { get; set; }
        public string tbl_shippers_tracking_est_cost { get; set; }
    }
}
