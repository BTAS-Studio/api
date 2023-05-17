using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_returns_sku
    {
        public int tbl_returns_sku_id { get; set; }
        public string tbl_returns_sku_description { get; set; }
        public string tbl_returns_sku_batch { get; set; }
        public string tbl_returns_sku_hscode { get; set; }
        public string tbl_returns_sku_dangerousgoods { get; set; }
        public string tbl_returns_sku_action { get; set; }
        public string tbl_returns_sku_value { get; set; }
    }
}
