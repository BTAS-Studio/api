using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class CloseShipmentResponseSuccess
    {
        public string status { get; set; }
        public object errors { get; set; }
        public List<CloseShipmentSuccessData> data { get; set; }
    }

    public class CloseShipmentSuccessData
    {
        public string status { get; set; }
        public object errors { get; set; }
        public string orderId { get; set; }
        public string trackingNo { get; set; }
    }

    
}
