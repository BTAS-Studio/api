using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.Data.Models
{
    public class tbl_manifest
    {
        [Key]
        public int idtbl_manifest {get; set; }
        public DateTime tbl_manifest_created_date { get; set; }
        public DateTime? tbl_manifest_sent_date { get; set; }
        public string tbl_manifest_carrier { get; set; }
        public int tbl_manifest_active { get; set; }
        public string tbl_manifest_prefix { get; set; }
    }
}
