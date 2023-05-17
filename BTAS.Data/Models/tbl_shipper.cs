using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_shipper
    {
        public int tbl_shippers_id { get; set; }
        public string tbl_shippers_name { get; set; }
        public string tbl_shippers_code { get; set; }
        public bool tbl_shippers_active { get; set; }
        public DateTime tbl_shippers_creation_date { get; set; }
        public string tbl_shippers_country { get; set; }
        public string tbl_shipperscol { get; set; }
        public string tbl_shippers_prefix { get; set; }
        public string tbl_air_prefix { get; set; }
    }
}
