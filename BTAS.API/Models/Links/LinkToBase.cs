using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models.Links
{
    public class LinkToBase
    {
        public string shipperId { get; set; }
        public string parentReference { get; set; }
        public bool isCreateParent { get; set; }
        public List<string> ReferencesToLink { get; set; }
    }
}
