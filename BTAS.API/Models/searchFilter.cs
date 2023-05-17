using System;
using System.Collections.Generic;

namespace BTAS.API.Models
{
    public class searchFilter
    {
        //public DateTime? DateSpecific { get; set; }
        //public DateTime? DateFrom { get; set; }
        //public DateTime? DateTo { get; set; }
        //public string Status { get; set; }
        //public string ReferenceNo { get; set; }
        //public List<string> ReferenceList { get; set; }
        //public string AgentNo { get; set; }
        //public List<string> AgentList { get; set; }
        //public string Closed { get; set; }
        //public string Mode { get; set; }
        public int? Page { get; set; }
        public int PageSize { get; set; }
        //public bool includeChild { get; set; } = false;
        //public bool includeSubChild { get; set; } = false;
        public object searchFields { get; set; }
    }

    public class searchFilter<T> where T : class
    {
        public DateTime? DateSpecific { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<string> ReferenceList { get; set; }
        public List<string> AgentList { get; set; }
        public int? Page { get; set; }
        public int PageSize { get; set; }
        public T searchFields { get; set; }
    }
}
