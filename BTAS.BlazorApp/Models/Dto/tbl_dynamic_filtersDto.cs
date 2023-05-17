using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Models.Dto
{
    public class tbl_dynamic_filterDto
    {
        public int idtbl_dynamic_filters { get; set; }
        public string tbl_dynamic_filters_column { get; set; }
        public string tbl_dynamic_filters_condition { get; set; }
        public string tbl_dynamic_filters_value { get; set; }
        public string tbl_dynamic_filters_module { get; set; }
        public string tbl_dynamic_filters_user { get; set; }
    }
}
