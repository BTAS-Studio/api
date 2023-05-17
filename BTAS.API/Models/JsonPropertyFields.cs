using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{

    public class JsonPropertyFields
    {
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public List<string> values { get; set; }

        public bool isOptional { get; set; }
    }
}
