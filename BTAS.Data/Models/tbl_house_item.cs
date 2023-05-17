using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_house_item
    {
        public tbl_house_item()
        {
            itemSkus = new HashSet<tbl_item_sku>();
        }

        public int idtbl_house_item { get; set; }
        public string tbl_house_item_code { get; set; }
        public string tbl_house_item_type { get; set; }
        public int tbl_house_item_qty { get; set; }
        public decimal tbl_house_item_weight { get; set; }
        public string tbl_house_item_weightUnit { get; set; }
        public decimal tbl_house_item_length { get; set; }
        public decimal tbl_house_item_width { get; set; }
        public decimal tbl_house_item_height { get; set; }
        public string tbl_house_item_volumeUnit { get; set; }
        public byte tbl_house_item_dg { get; set; }
        public string tbl_house_item_description { get; set; }

        public int? tbl_house_id { get; set; }
        public string HouseCode { get; set; }
        public virtual tbl_house house { get; set; }

        public virtual ICollection<tbl_item_sku> itemSkus { get; set; }
    }
}
