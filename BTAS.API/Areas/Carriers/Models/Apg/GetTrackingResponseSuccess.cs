using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class GetTrackingResponseSuccess
    {
        public string status { get; set; }
        public object errors { get; set; }
        public List<GetTrackingResponseSuccessData> data { get; set; }
    }

    public class GetTrackingResponseSuccessData
    {
        public string orderId { get; set; }
        public string status { get; set; }
        public object errors { get; set; }
        public string trackingNo { get; set; }
    }

    public class Event
    {
        public string trackingNo { get; set; }
        public DateTime eventTime { get; set; }
        public string eventCode { get; set; }
        public string activity { get; set; }
        public string location { get; set; }
        public object referenceTrackingNo { get; set; }
        public string destCountry { get; set; }
        public string country { get; set; }
        public string timeZone { get; set; }
    }
}
