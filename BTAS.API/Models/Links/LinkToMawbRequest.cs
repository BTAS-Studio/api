using BTAS.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models.Links
{
    public class LinkToMasterRequest : LinkToBase
    {
        public tbl_masterDto master { get; set; }
    }
}
