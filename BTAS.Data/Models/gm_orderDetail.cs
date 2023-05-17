using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.Data.Models
{
    public class gm_orderDetail
    {
        [Key]
        public int Id { get; set; }
        public string paymentId { get; set; }
        public string productId { get; set; }

    }
}
