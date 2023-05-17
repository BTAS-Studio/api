using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_barcode
    {
        public int tbl_barcodes_id { get; set; }
        public int tbl_barcodes_parcel_id { get; set; }
        public string tbl_barcodes_code { get; set; }
        public int? tbl_barcodes_manifest_link_id { get; set; }
        public string tbl_barcodes_sequence { get; set; }
        public int tbl_barcodes_shipment_id { get; set; }
    }
}
