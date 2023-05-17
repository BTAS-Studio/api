using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class CreateShippingResponseError
    {
        public string status { get; set; }
        public List<ErrorModel> errors { get; set; }
        public List<DatumModel> data { get; set; }
        public List<WarningModel> warnings { get; set; }
    }
}
