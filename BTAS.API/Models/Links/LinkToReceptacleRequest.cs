using BTAS.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models.Links
{
    public class LinkToReceptacleRequest : LinkToBase
    {
        public tbl_receptacleDto receptacle { get; set; }
        //Added by HS on 01/02/2023
        //public string houseBillNo { get; set; }
    }
}
