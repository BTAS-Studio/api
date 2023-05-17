using BTAS.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models.Links
{
    public class LinkToContainerRequest : LinkToBase
    {
        public tbl_containerDto container { get; set; }
    }
}
