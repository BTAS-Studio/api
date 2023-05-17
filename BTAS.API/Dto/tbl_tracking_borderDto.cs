using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Dto
{
    public class tbl_tracking_borderDto
    {
        public int tbl_tracking_id { get; set; }
        [JsonProperty("DateCreated")]
        [Description("Date Created")]
        public DateTime tbl_tracking_createDate { get; set; }
        [JsonProperty("ShipmentId")]
        [Description("Shipment Id")]
        public int tbl_tracking_shipmentID { get; set; }
        [JsonProperty("Prefix")]
        [Description("Tracking prefix")]
        [StringLength(10)]
        public string tbl_tracking_prefix { get; set; }
    }
}
