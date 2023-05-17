using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_parcel_tracking
    {
        public int tbl_parcel_tracking_id { get; set; }
        public string tbl_parcel_tracking_shipmentId { get; set; }
        public sbyte tbl_parcel_tracking_received { get; set; }
    }
}
