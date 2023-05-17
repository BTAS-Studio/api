using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class GetTrackingResponsePartial
    {
        public string status { get; set; }
        public List<GenericGetTrackingResponseError> errors { get; set; }
        public List<GetTrackingResponseSuccessData> data { get; set; }
    }

    public class GenericGetTrackingResponseError
    {
        public int code { get; set; }
        public string message { get; set; }
    }
}
