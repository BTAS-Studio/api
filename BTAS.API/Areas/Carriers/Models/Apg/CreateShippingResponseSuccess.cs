using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class CreateShippingResponseSuccess
    {
        public string status { get; set; }
        public object errors { get; set; }
        public List<Datum> data { get; set; }
        public List<WarningModel> warnings { get; set; }
    }

    public class Datum
    {
        public string status { get; set; }
        public object errors { get; set; }
        public List<WarningModel> warnings { get; set; }
        public string orderId { get; set; }
        public string referenceNo { get; set; }
        public string trackingNo { get; set; }
        public object connoteId { get; set; }
    }
}
