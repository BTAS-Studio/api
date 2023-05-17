using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_return
    {
        public int tbl_returns_id { get; set; }
        public string tbl_returns_reference { get; set; }
        public string tbl_returns_name { get; set; }
        public string tbl_returns_address1 { get; set; }
        public string tbl_returns_address2 { get; set; }
        public string tbl_returns_address3 { get; set; }
        public string tbl_returns_city { get; set; }
        public string tbl_returns_suburb { get; set; }
        public string tbl_returns_state { get; set; }
        public string tbl_returns_postcode { get; set; }
        public string tbl_returns_country { get; set; }
        public string tbl_returns_option { get; set; }
        public string tbl_returns_status { get; set; }
    }
}
