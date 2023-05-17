using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class GenericResponseError
    {
        public string status { get; set; }
        public List<ErrorModel> errors { get; set; }
        public object data { get; set; }
    }
}
