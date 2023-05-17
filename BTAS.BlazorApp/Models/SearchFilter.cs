using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Models
{
    public class SearchFilter
    {
        public DateTime? DateSpecific { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Status { get; set; }
        public string ReferenceNo { get; set; }
        public List<string> ReferenceList { get; set; }
        public string AgentNo { get; set; }
        public List<string> AgentList { get; set; }
        public string Closed { get; set; }
        public string Mode { get; set; }

    }
}
