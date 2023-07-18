using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using BTAS.Data;
using BTAS.Data.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTAS.API.Dto
{
    public class tbl_masterDto
    {
        //Added by HS on 09/02/2023
        [JsonProperty("Id")]
        [JsonIgnore]
        public int idtbl_master { get; set; }
        [StringLength(30)]
        [JsonProperty("Code")]
        public string tbl_master_code { get; set; }
        [StringLength(50)]
        [JsonProperty("BookingNumber")]
        public string tbl_master_bookingNumber { get; set; }
        [StringLength(50)]
        [JsonProperty("BillNumber")]
        public string tbl_master_billNumber { get; set; }
        [StringLength(50)]
        [JsonProperty("Status")]
        //[RegularExpression("")]
        public string tbl_master_status { get; set; }
        [StringLength(30)]
        [JsonProperty("Type")]
        public string tbl_master_type { get; set; }
        [StringLength(30)]
        [JsonProperty("TransportType")]
        public string tbl_master_transportType { get; set; }
        [StringLength(30)]
        [JsonProperty("ContainerMode")]
        public string tbl_master_containerMode { get; set; }
        [JsonProperty("CreatedDate")]
        public DateTime? tbl_master_createdDate { get; set; }
        
        [JsonProperty("VoyageId")]
        [JsonIgnore]
        public int? tbl_voyage_id { get; set; }
        [StringLength(30)]
        [JsonProperty("VoyageCode")]
        public string VoyageCode { get; set; }
        [JsonProperty("Voyage")]
        public virtual tbl_voyageDto voyage { get; set; }

        [JsonProperty("CarrierAgentId")]
        [JsonIgnore]
        public int? tbl_client_header_carrier_id { get; set; }
        [StringLength(30)]
        [JsonProperty("CarrierAgentCode")]
        public string carrierAgentCode { get; set; }
        public virtual tbl_client_headerDto carrierAgent { get; set; }

        [JsonProperty("CreditorAgentId")]
        [JsonIgnore]
        public int? tbl_client_header_creditor_id { get; set; }
        [StringLength(30)]
        [JsonProperty("CreditorAgentCode")]
        public string creditorAgentCode { get; set; }
        public virtual tbl_client_headerDto creditorAgent { get; set; }

        [JsonProperty("DestinationAgentId")]
        [JsonIgnore]
        public int? tbl_client_header_destination_id { get; set; }
        [StringLength(30)]
        [JsonProperty("DestinationAgentCode")]
        public string destinationAgentCode { get; set; }
        public virtual tbl_client_headerDto destinationAgent { get; set; }

        [JsonProperty("OriginAgentId")]
        [JsonIgnore]
        public int? tbl_client_header_origin_id { get; set; }
        [StringLength(30)]
        [JsonProperty("OriginAgentCode")]
        public string originAgentCode { get; set; }
        public virtual tbl_client_headerDto originAgent { get; set; }
        
        public virtual ICollection<tbl_containerDto> containers { get; set; } = new Collection<tbl_containerDto>();
        public virtual ICollection<tbl_documentDto> documents { get; set; } = new Collection<tbl_documentDto>();
        public virtual ICollection<tbl_houseDto> houses { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_noteDto> notes { get; set; } = new Collection<tbl_noteDto>();
        public virtual ICollection<tbl_milestone_linkDto> milestoneLinks { get; set; } = new Collection<tbl_milestone_linkDto>();

    }
}