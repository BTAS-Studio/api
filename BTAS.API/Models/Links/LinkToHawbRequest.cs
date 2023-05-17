using BTAS.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models.Links
{
    public class LinkToHouseRequest : LinkToBase
    {
        public tbl_houseDto house { get; set; }
    }
}
