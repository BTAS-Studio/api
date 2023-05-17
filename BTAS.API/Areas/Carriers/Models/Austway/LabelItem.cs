using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Austway
{
    public class LabelItem
    {
        public int ItemId { get; set; }
        public int HouseId { get; set; }
        public int ParcelId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string RoutingCode { get; set; }
        public string ParcelPallet { get; set; }
        public string Instructions { get; set; }
        public string CustomerCode { get; set; }
        public string Tracking { get; set; }
        public string Consignment { get; set; }
        public decimal Weight { get; set; }
    }
}
