using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_dynamic_filter
    {
        public int idtbl_dynamic_filters { get; set; }
        public string tbl_dynamic_filters_column { get; set; }
        public string tbl_dynamic_filters_condition { get; set; }
        public string tbl_dynamic_filters_value { get; set; }
        public string tbl_dynamic_filters_module { get; set; }
        public string tbl_dynamic_filters_user { get; set; }
    }
}
