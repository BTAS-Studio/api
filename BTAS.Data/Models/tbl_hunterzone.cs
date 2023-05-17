using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_hunterzone
    {
        public string tbl_hunterzones_suburb { get; set; }
        public int tbl_hunterzones_postcode { get; set; }
        public string tbl_hunterzones_state { get; set; }
        public string tbl_hunterzones_routescan { get; set; }
        public string tbl_hunterzones_labelzone { get; set; }
        public int? tbl_hunterzones_zone { get; set; }
    }
}
