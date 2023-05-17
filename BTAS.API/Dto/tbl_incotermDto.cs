using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BTAS.API.Dto
{
	public class tbl_incotermDto
	{
		[JsonProperty("Id")]
        [DoNotInclude]
        public int idtbl_incoterm { get; set; }
		[StringLength(50)]
		[JsonProperty("IncotermsCode")]
		public string tbl_incoterm_code { get; set; }
		[StringLength(150)]
		[JsonProperty("Description")]
		public string tbl_incoterm_description { get; set; }
		//[JsonProperty("HOUSE")]
		//public virtual tbl_houseDto house { get; set; }
		public virtual ICollection<tbl_houseDto> houses { get; set; } = new Collection<tbl_houseDto>();
		public virtual ICollection<tbl_shipmentDto> shipments { get; set; } = new Collection<tbl_shipmentDto>();
	}
}
