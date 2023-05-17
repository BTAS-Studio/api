using System.ComponentModel.DataAnnotations;

namespace BTAS.Data.Models
{
    public class tbl_servicecode
    {
        [Key]
        public int idtbl_serviceCode { get; set; }
        [StringLength(30)]
        public string tbl_serviceCode_name { get; set; }
        public bool? tbl_serviceCode_active { get; set; } = true;
    }
}
