using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_default_setting
    {
        public int idtbl_default_settings { get; set; }
        public string tbl_address_type { get; set; }
        public int tbl_incoterm_id { get; set; }
        public bool isBillTo { get; set; }
        public int tbl_contact_group_id { get; set; }
        public bool tbl_default_settings_active { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }
}
