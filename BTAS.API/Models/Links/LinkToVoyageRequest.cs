using BTAS.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models.Links
{
    public class LinkToVoyageRequest : LinkToBase
    {
        public tbl_voyageDto voyage { get; set; }
    }
}
