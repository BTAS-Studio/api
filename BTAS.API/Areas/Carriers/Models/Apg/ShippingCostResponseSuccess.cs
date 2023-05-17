using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class ShippingCostResponseSuccess
    {
        public string status { get; set; }
        public object errors { get; set; }
        public List<ShippingCostResponseSuccessData> data { get; set; }
    }

    public class BillingItem
    {
        public double estimateShippingFee { get; set; }
        public string currency { get; set; }
        public double actualShippingFee { get; set; }
        public double chargeWeight { get; set; }
        public double declaredWeight { get; set; }
        public string trackingNumber { get; set; }
        public string estimateCurrency { get; set; }
    }

    public class ShippingCostResponseSuccessData
    {
        public string status { get; set; }
        public object errors { get; set; }
        public string orderId { get; set; }
        public BillingItem billingItem { get; set; }
    }
}
