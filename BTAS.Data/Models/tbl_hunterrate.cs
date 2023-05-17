using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_hunterrate
    {
        public string tbl_hunterrates_injectionport { get; set; }
        public int tbl_hunterrates_zone { get; set; }
        public decimal tbl_hunterrates_min { get; set; }
        public decimal tbl_hunterrates_base { get; set; }
        public decimal tbl_hunterrates_perkg { get; set; }
    }
}
