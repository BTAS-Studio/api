using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Dto
{
	public class tbl_barcodeDto
	{
		public int tbl_barcode_id { get; set; }
		public int tbl_barcode_parcel_id { get; set; }
		public string tbl_barcode_code { get; set; }
		public int tbl_barcode_manifest_link_id { get; set; }
		public string tbl_barcode_sequence { get; set; }
		public int tbl_barcode_shipment_id { get; set; }
	}
}