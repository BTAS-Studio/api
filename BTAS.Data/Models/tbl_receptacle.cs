using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_receptacle
    {
        public tbl_receptacle()
        {
            shipments = new HashSet<tbl_shipment>();
        }

        public int idtbl_receptacle { get; set; }
        public string tbl_receptacle_code { get; set; }
        public string tbl_receptacle_shipper_code { get; set; }
        public string tbl_receptacle_mode { get; set; }
        public string tbl_receptacle_type { get; set; }
        public int? tbl_receptacle_qty { get; set; }
        public decimal? tbl_receptacle_weight { get; set; }
        public string tbl_receptacle_status { get; set; }
        public string tbl_receptacle_origin { get; set; }
        public string tbl_receptacle_destination { get; set; }
        public DateTime? tbl_receptacle_createdDate { get; set; }
        public decimal? tbl_receptacle_length { get; set; }
        public decimal? tbl_receptacle_width { get; set; }
        public decimal? tbl_receptacle_height { get; set; }

        public int? tbl_house_id { get; set; }
        public string HouseCode { get; set; }
        public virtual tbl_house house { get; set; }

        public virtual ICollection<tbl_shipment> shipments { get; set; }
    }
}
