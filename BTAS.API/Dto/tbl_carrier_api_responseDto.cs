using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BTAS.API.Dto
{
    //[NotMapped]
    public class tbl_carrier_api_responseDto
    {
        public string tbl_carrier_api_response_message { get; set; }
        public int? tbl_carrier_api_response_ind { get; set; }
        public int? tbl_carrier_api_response_parcelId { get; set; }
        public string tbl_carrier_api_trackingRef { get; set; }
        public int? tbl_carrier_api_manifestId { get; set; }
    }
}
