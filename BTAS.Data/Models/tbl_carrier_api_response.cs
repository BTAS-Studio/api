using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_carrier_api_response
    {
        public int idtbl_carrier_api_response { get; set; }
        public string tbl_carrier_api_response_message { get; set; }
        public int? tbl_carrier_api_response_ind { get; set; }
        public int? tbl_carrier_api_response_parcelId { get; set; }
        public string tbl_carrier_api_trackingRef { get; set; }
        public int? tbl_carrier_api_manifestId { get; set; }
    }
}
