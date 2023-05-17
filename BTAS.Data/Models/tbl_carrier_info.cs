using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_carrier_info
    {
        public int idtbl_carrier_info { get; set; }
        public string tbl_carrier_name { get; set; }
        public string tbl_carrier_address1 { get; set; }
        public string tbl_carrier_address2 { get; set; }
        public string tbl_carrier_city { get; set; }
        public string tbl_carrier_suburb { get; set; }
        public string tbl_carrier_postCode { get; set; }
        public string tbl_carrier_state { get; set; }
        public string tbl_carrier_country_origin { get; set; }
        public string tbl_carrier_country_destination { get; set; }
        public string tbl_carrier_email { get; set; }
        public string tbl_carrier_phone { get; set; }
        public string tbl_carrier_contactName { get; set; }
        public string tbl_carrier_code { get; set; }
        public string tbl_carrier_type { get; set; }
        public sbyte tbl_carrier_active { get; set; }
    }
}
