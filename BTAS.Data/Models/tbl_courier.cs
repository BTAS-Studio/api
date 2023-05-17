using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.Data.Models
{
    public class tbl_courier
    {
        [Key]
        public int idtbl_courier { get; set; }
        [StringLength(30)]
        public string tbl_courier_code { get; set; }
        public bool? tbl_courier_active { get; set; } = true;
    }
}
