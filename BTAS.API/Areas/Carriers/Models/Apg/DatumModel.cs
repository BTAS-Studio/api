using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class DatumModel
    {
        public string status { get; set; }
        public List<ErrorModel> errors { get; set; }
        public List<WarningModel> warnings { get; set; }
        public object orderId { get; set; }
        public string referenceNo { get; set; }
        public string trackingNo { get; set; }
        public object connoteId { get; set; }
    }
}
