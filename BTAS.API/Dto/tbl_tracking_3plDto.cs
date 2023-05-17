using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.API.Dto
{
    public class tbl_tracking_3plDto
    {
        public int tbl_tracking_id { get; set; }
        public DateTime tbl_tracking_createDate { get; set; }
        public int tbl_tracking_shipmentID { get; set; }
        public string tbl_tracking_prefix { get; set; }
    }
}
