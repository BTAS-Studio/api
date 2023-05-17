using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Models
{
    public class TabulatorViewModel
    {
        public IEnumerable<dynamic> Data { get; set; }
        public int Last_page { get; set; }
    }
}
