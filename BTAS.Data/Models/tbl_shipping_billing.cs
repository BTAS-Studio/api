using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_shipping_billing
    {
        public int idtbl_shipping_billing { get; set; }
        public string tbl_shipping_billing_orderId { get; set; }
        public string tbl_shipping_billing_referenceNo { get; set; }
        public string tbl_shipping_billing_trackingNo { get; set; }
        public decimal? tbl_shipping_billing_shippingCost { get; set; }
        public DateTime? tbl_shipping_billing_dateAdded { get; set; }
        public string tbl_shipping_billing_status { get; set; }
        
        public int tbl_shipment_id { get; set; }
        public virtual tbl_shipment shipment { get; set; }
    }
}
