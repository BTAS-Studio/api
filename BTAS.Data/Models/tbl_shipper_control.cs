using System.ComponentModel.DataAnnotations;

namespace BTAS.Data.Models
{
    public class tbl_shipper_control
    {
        [Key]
        public int idtbl_shipper_control { get; set; }
        [StringLength(30)]
        public string tbl_shipperId { get; set; }
        [StringLength(30)]
        public string tbl_shipper_control_shipperId { get; set; }
        [StringLength(30)]
        public string tbl_shipper_control_courier { get; set; }
        public bool? tbl_shipper_control_active { get; set; } = true;
    }
}
