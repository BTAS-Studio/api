using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_shippers_air_ref
    {
        public int idtbl_shippers_air_ref { get; set; }
        public DateTime? tbl_shippers_air_createDate { get; set; }
        public int? tbl_shippers_air_shipmentId { get; set; }
        public string tbl_shippers_air_prefix { get; set; }
        public string tbl_shippers_air_batch_id { get; set; }
    }
}
