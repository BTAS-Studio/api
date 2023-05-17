using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.BlazorApp.Models.Dto
{
    public class tbl_mawbDto
    {
        public int idtbl_mawb { get; set; }
        [StringLength(50)]
        [JsonProperty("MasterBillNumber")]
        [InGrid]
        public string tbl_mawb_masterBillNumber { get; set; }
        [StringLength(50)]
        [JsonProperty("BookingNumber")]
        [InGrid]
        public string tbl_mawb_bookingNumber { get; set; }
        [StringLength(50)]
        [JsonProperty("BillNumber")]
        [InGrid]
        public string tbl_mawb_billNumber { get; set; }
        [StringLength(50)]
        [JsonProperty("Status")]
        [InGrid]
        public string tbl_mawb_status { get; set; }

        [StringLength(30)]
        [JsonProperty("MAWBType")]
        [InGrid]
        public string tbl_mawb_type { get; set; }
        [StringLength(30)]
        [JsonProperty("TransportType")]
        [InGrid]
        public string tbl_mawb_transportType { get; set; }
        [StringLength(30)]
        [JsonProperty("ContainerMode")]
        [InGrid]
        public string tbl_mawb_containerMode { get; set; }
        [JsonProperty("DateTimeCreated")]
        public DateTime? dateTimeCreated { get; set; }

        public int? tbl_client_header_origin_id { get; set; }
        [StringLength(30)]
        [InGrid]
        public string originAgentCode { get; set; }
        public virtual tbl_client_headerDto originAgent { get; set; }
        public int? tbl_client_header_destination_id { get; set; }
        [StringLength(30)]
        [InGrid]
        public string destinationAgentCode { get; set; }
        public virtual tbl_client_headerDto destinationAgent { get; set; }
        public int? tbl_client_header_carrier_id { get; set; }
        [StringLength(30)]
        public string carrierAgentCode { get; set; }
        public virtual tbl_client_headerDto carrierAgent { get; set; }
        public int? tbl_client_header_creditor_id { get; set; }
        [StringLength(30)]
        public string creditorAgentCode { get; set; }
        public virtual tbl_client_headerDto creditorAgent { get; set; }

        [JsonProperty("VoyageId")]
        public int? tbl_voyage_id { get; set; }
        [JsonProperty("VoyageNumber")]
        [StringLength(30)]
        public string voyageNumber { get; set; }
        [JsonProperty("Voyage")]
        public virtual tbl_voyageDto tbl_voyage { get; set; }

        public virtual ICollection<tbl_documentsDto> documents { get; set; } = new Collection<tbl_documentsDto>();
        public virtual ICollection<tbl_hawbDto> hawbs { get; set; } = new Collection<tbl_hawbDto>();
        public virtual ICollection<tbl_containerDto> containers { get; set; } = new Collection<tbl_containerDto>();
    }
}
