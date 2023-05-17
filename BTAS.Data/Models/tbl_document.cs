using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_document
    {
        public int idtbl_document { get; set; }

        public string document { get; set; }
        public string status { get; set; }
        public DateTime date_added { get; set; }
        public string added_by { get; set; }

        public int master_reference { get; set; }
        public virtual tbl_master master { get; set; }

        public int house_reference { get; set; }
        public virtual tbl_house house { get; set; }

        public int shipment_reference { get; set; }
        public virtual tbl_shipment shipment { get; set; }
    }
}
