using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_pluscourier_rate
    {
        public int tbl_pluscourier_rate_id { get; set; }
        public decimal? tbl_pluscourier_rate_pallet { get; set; }
        public int? tbl_pluscourier_rate_km { get; set; }
        public string tbl_pluscourier_rate_notes { get; set; }
    }
}
