using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class GenericResponsePartial
    {
        public string status { get; set; }
        public List<ErrorModel> errors { get; set; }
        public List<GenericResponsePartialData> data { get; set; }
    }

    public class GenericResponsePartialData
    {
        public string status { get; set; }
        public List<ErrorModel> errors { get; set; }
        public string orderId { get; set; }
        public string trackingNo { get; set; }
    }
}
