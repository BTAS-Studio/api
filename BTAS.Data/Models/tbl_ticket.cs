using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_ticket
    {
        public int tbl_tickets_id { get; set; }
        public string tbl_tickets_owner { get; set; }
        public DateTime? tbl_tickets_timestamp { get; set; }
        public string tbl_tickets_status { get; set; }
        public string tbl_tickets_type { get; set; }
        public string tbl_tickets_comments { get; set; }
        public int? tbl_tickets_priority { get; set; }
    }
}
