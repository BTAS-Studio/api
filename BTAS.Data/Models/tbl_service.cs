using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_service
    {
        public int tbl_services_id { get; set; }
        public string tbl_services_name { get; set; }
        public string tbl_services_code { get; set; }
        public string tbl_services_carrierId { get; set; }
        public bool tbl_services_active { get; set; }
        public string tbl_services_carrierAccount { get; set; }
        public string tbl_services_carrierCode { get; set; }
        public string tbl_services_prefixCode { get; set; }
    }
}
