using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class ShippingCostResponseError
    {
        public string status { get; set; }
        public List<ShippingCostResponseErrorMessage> errors { get; set; }
        public List<ShippingCostResponseErrorData> data { get; set; }
    }

    public class ShippingCostResponseErrorMessage
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class ShippingCostResponseErrorData
    {
        public string status { get; set; }
        public List<ShippingCostResponseErrorMessage> errors { get; set; }
        public string orderId { get; set; }
        public object billingItem { get; set; }
    }
}
