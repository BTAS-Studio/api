using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_incoterm
    {
        public tbl_incoterm()
        {
            houses = new HashSet<tbl_house>();
            shipments = new HashSet<tbl_shipment>();
        }

        public int idtbl_incoterm { get; set; }
        public string tbl_incoterm_code { get; set; }
        public string tbl_incoterm_description { get; set; }

        public virtual ICollection<tbl_house> houses { get; set; }
        public virtual ICollection<tbl_shipment> shipments { get; set; }
    }
}
