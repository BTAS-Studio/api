using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Apg
{
    public class CreateLabelRequest
    {
        public List<string> orderIds { get; set; }
        public int labelType { get; set; }
        public bool packinglist { get; set; }
        public bool merged { get; set; }
        public string labelFormat { get; set; }
    }
}
