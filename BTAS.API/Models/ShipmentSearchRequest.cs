using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{
    public class ShipmentSearchRequest
    {
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public List<string> shipID { get; set; }
        public string tracking { get; set; }
        public string shipperName { get; set; }
        public string carrierName { get; set; }
        public string deliveryName { get; set; }
        public int isManifested { get; set; }
    }
}
