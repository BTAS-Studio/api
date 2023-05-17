using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_item_sku
    {
        public tbl_item_sku()
        {
            houseItems = new HashSet<tbl_house_item>();
            shipmentItems = new HashSet<tbl_shipment_item>();
        }

        public int idtbl_item_sku { get; set; }
        public string tbl_item_sku_code { get; set; }
        public decimal tbl_items_weight { get; set; }
        public string tbl_items_weightUnit { get; set; }
        public decimal tbl_items_length { get; set; }
        public decimal tbl_items_width { get; set; }
        public decimal tbl_items_height { get; set; }
        public decimal tbl_items_volume { get; set; }
        public string tbl_items_volumeUnit { get; set; }
        public int tbl_items_qty { get; set; }
        public string tbl_items_description { get; set; }
        public string tbl_items_nativeDescription { get; set; }
        public string tbl_items_hsCode { get; set; }
        public string tbl_items_originCountry { get; set; }
        public decimal tbl_items_value { get; set; }
        public string tbl_items_productUrl { get; set; }
        public string tbl_items_batteryType { get; set; }
        public string tbl_items_batteryPacking { get; set; }
        public byte tbl_items_dangerousGoods { get; set; }
        public string tbl_items_batchNumber { get; set; }

        public virtual ICollection<tbl_house_item> houseItems { get; set; }
        public virtual ICollection<tbl_shipment_item> shipmentItems { get; set; }
    }
}
