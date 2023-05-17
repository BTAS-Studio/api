using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{
    public class ManifestSenderModel
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
    }
}
