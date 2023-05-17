using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Grid
{
	public class gridHawb
	{
		[JsonProperty("Id")]
		[DoNotInclude]
		public int idtbl_hawb { get; set; }

		[Description("Job No.")]
		public string JobNumber { get; set; } // HawbReference
		
		[Description("House Bill")]
		public string HouseBill { get; set; } // HawbBillNumber

		[Description("Consignee Name")]
		public string ConsigneeName { get; set; } // Get from Address Book

		[Description("Shipper Name")]
		public string ShipperName { get; set; } // Get from Address Book

		[Description("Pkgs")]
		public string Pkgs { get; set; }

		[Description("Act. Weight")]
		public string ActualWeight { get; set; } // Hawb Weight

		[Description("Act. Wt Units")]
		public string ActualWtUnits { get; set; } // Hawb Weight Unit

		[Description("Chg. Weight")]
		public string ChgWeight { get; set; } // Hawb Chargeable Weight

		[Description("Chg. Weight Units")]
		public string ChgWtUnits{ get; set; } // Hawb Chargeable Weight Unit
	}
}
