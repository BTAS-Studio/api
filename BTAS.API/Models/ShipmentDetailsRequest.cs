using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{
    public class ShipmentDetailsRequest
    {
        public string tracking { get; set; }
        public string shipperId { get; set; }
    }
}
