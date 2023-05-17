using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{
    public class ManifestRequest
    {
        public string shipperId { get; set; }
        public string carrier { get; set; }
        public List<string> consignmentId { get; set; }

        public string PickupDate { get; set; }
    }
}