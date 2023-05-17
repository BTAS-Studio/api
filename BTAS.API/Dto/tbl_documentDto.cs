using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Dto
{
    public class tbl_documentDto
    {
		public int idtbl_document { get; set; }
		public int master_reference { get; set; }
		public int house_reference { get; set; }
		public int lowers_reference { get; set; }
		public string document { get; set; }
		public string status { get; set; }
		public DateTime date_added { get; set; }
		public string added_by { get; set; }

		public virtual tbl_masterDto master { get; set; }
		[DoNotInclude]
		public virtual tbl_houseDto house { get; set; }
		[DoNotInclude]
		public virtual tbl_shipmentDto shipment { get; set; }
	}
}
