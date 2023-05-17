using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class CreateLabelResponseSuccess
    {
        public string status { get; set; }
        public object errors { get; set; }
        public List<CreateLabelResponseData> data { get; set; }
    }

    public class CreateLabelResponseData
    {
        public string status { get; set; }
        public object errors { get; set; }
        public string labelContent { get; set; }
        public string orderId { get; set; }
        public string trackingNo { get; set; }
        public object labelContents { get; set; }
    }
}
