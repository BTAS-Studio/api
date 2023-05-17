using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_pluscourier
    {
        public int tbl_pluscourier_id { get; set; }
        public string tbl_pluscourier_suburb { get; set; }
        public string tbl_pluscourier_postcode { get; set; }
        public int? tbl_pluscourier_distance { get; set; }
    }
}
