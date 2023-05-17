using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_shipment_item
    {
        public tbl_shipment_item()
        {
            itemSkus = new HashSet<tbl_item_sku>();
        }

        public int idtbl_shipment_item { get; set; }
        public string tbl_shipment_item_code { get; set; }
        public decimal? tbl_shipment_item_weight { get; set; }
        public string tbl_shipment_item_weightUnit { get; set; }
        public decimal? tbl_shipment_item_length { get; set; }
        public decimal? tbl_shipment_item_width { get; set; }
        public decimal? tbl_shipment_item_height { get; set; }
        public string tbl_shipment_item_volumeUnit { get; set; }
        public sbyte? tbl_shipment_item_dangerousGoods { get; set; }
        public string tbl_shipment_item_description { get; set; }
        public string tbl_shipment_item_type { get; set; }
        public int? tbl_shipment_item_qty { get; set; }
        public int? tbl_shipment_id { get; set; }
        public string ShipmentCode { get; set; }

        public virtual tbl_shipment shipment { get; set; }
        public virtual ICollection<tbl_item_sku> itemSkus { get; set; }
    }
}
