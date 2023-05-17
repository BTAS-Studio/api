using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Models
{
    public class DynamicSearchFilters
    {
        public string Column { get; set; }
        public string Condition { get; set; }
        public string Value { get; set; }
    }
}
