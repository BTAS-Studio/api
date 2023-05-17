using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.Data.Models
{
    public class gm_orderHeader
    {
        [Key]
        public int Id { get; set; }
        public string shippingId { get; set; }
        public decimal? totalAmount { get; set; }
        public string paymentId { get; set; }
    }
}
