using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Models.Dto
{
    public class tbl_voyageDto
    {
        public int idtbl_voyage { get; set; }
        [StringLength(50)]
        public string tbl_voyage_number { get; set; }
        [StringLength(50)]
        public string tbl_voyage_vessel { get; set; }
        [StringLength(30)]
        public string tbl_voyage_aircrafType { get; set; }
        [StringLength(30)]
        public string tbl_voyage_aircraftReg { get; set; }
        [StringLength(30)]
        public string tbl_voyage_vinNumber { get; set; }
        [StringLength(30)]
        public string tbl_voyage_loadPort { get; set; }
        [StringLength(30)]
        public string tbl_voyage_dischargePort { get; set; }
        public DateTime tbl_voyage_etd { get; set; }
        public DateTime tbl_voyage_eta { get; set; }
        public DateTime tbl_voyage_atd { get; set; }
        public DateTime tbl_voyage_ata { get; set; }
    }
}
