using System;
using System.ComponentModel.DataAnnotations;

namespace BTAS.API.Models
{
    public class HouseRequest
    {
		public int idtbl_house { get; set; }

		public int tbl_master_id { get; set; }

		[StringLength(50)]
		public string tbl_house_incotermCode { get; set; }
		[StringLength(50)]
		public string tbl_house_airJobReference { get; set; }
		[StringLength(50)]
		public string tbl_house_shipperId { get; set; }
		public int tbl_house_pieces { get; set; }
		public decimal tbl_house_weight { get; set; }
		public decimal tbl_house_volume { get; set; }
		[StringLength(50)]
		public string tbl_house_originAirport { get; set; }
		[StringLength(50)]
		public string tbl_house_destinationAirport { get; set; }
		public int tbl_house_value { get; set; }
		[StringLength(150)]
		public string tbl_house_description { get; set; }
		public byte tbl_house_FTA { get; set; }
		[StringLength(50)]
		public string tbl_house_shipperRef { get; set; }
		[StringLength(50)]
		public string tbl_house_coloaderCode { get; set; }
		[StringLength(50)]
		public string tbl_house_latestTracking { get; set; }
		public DateTime tbl_house_timestamp { get; set; }
		[StringLength(50)]
		public string tbl_house_status { get; set; }
		[StringLength(50)]
		public string tbl_house_service { get; set; }
		public DateTime tbl_house_deliverydate { get; set; }
		[StringLength(150)]
		public string tbl_house_deliveryInstructions { get; set; }
		[StringLength(50)]
		public string tbl_house_clearancedate { get; set; }
		public byte tbl_house_coo { get; set; }
		[StringLength(50)]
		public string tbl_house_type { get; set; }
		public byte tbl_house_tailLiftO { get; set; }
		public byte tbl_house_tailLiftD { get; set; }
		public byte tbl_house_DG { get; set; }

		public string tbl_house_UN { get; set; }
		[StringLength(50)]
		public string tbl_house_packaging { get; set; }
		[StringLength(50)]
		public string tbl_house_class { get; set; }
		[StringLength(50)]
		public string tbl_house_currency { get; set; }

		public int tbl_house_incoterms_id { get; set; }
	}
}
