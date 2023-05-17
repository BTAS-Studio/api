using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class CreateLabelResponseError
    {
        public string status { get; set; }
        public List<ErrorModel> errors { get; set; }
        public List<CreateLabelResponseErrorData> data { get; set; }
    }

    public class CreateLabelResponseErrorData
    {
        public string status { get; set; }
        public List<ErrorModel> errors { get; set; }
        public object labelContent { get; set; }
        public string orderId { get; set; }
        public object trackingNo { get; set; }
        public object labelContents { get; set; }
    }
}
