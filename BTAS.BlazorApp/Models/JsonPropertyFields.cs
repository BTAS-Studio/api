using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Models
{

    public class JsonPropertyFields
    {
        public string jsonName { get; set; }
        public string fieldName { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public List<string> values { get; set; }
        public bool inGrid { get; set; }
        public bool isOptional { get; set; }
    }
}
