using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Dto
{
    public class tbl_shipping_billingDto
    {
        public int idtbl_shipping_billing { get; set; }
        [JsonProperty("OrderId")]
        [StringLength(30)]
        public string tbl_shipping_billing_orderId { get; set; }
        [JsonProperty("ReferenceNo")]
        [StringLength(30)]
        public string tbl_shipping_billing_referenceNo { get; set; }
        [JsonProperty("TrackingNo")]
        [StringLength(30)]
        public string tbl_shipping_billing_trackingNo { get; set; }
        [JsonProperty("ShippingCost")]
        public decimal? tbl_shipping_billing_shippingCost { get; set; }
        [JsonProperty("DateAdded")]
        public DateTime? tbl_shipping_billing_dateAdded { get; set; }
        [JsonProperty("Status")]
        [StringLength(30)]
        public string tbl_shipping_billing_status { get; set; }
        [JsonProperty("ParcelInfoId")]
        public int tbl_parcel_info_id { get; set; }
        [JsonProperty("ParcelInfo")]
        public virtual tbl_shipmentDto ParcelInfo { get; set; }
    }
}
