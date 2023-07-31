using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static BTAS.API.NoMapAttribute;

namespace BTAS.API.Dto
{
    public class tbl_voyageDto
    {
        [JsonProperty("Id")]
        [JsonIgnore]
        public int idtbl_voyage { get; set; }

        [StringLength(50)]
        [JsonProperty("Code")]
        public string tbl_voyage_code { get; set; }

        [StringLength(50)]
        [JsonProperty("Type")]
        public string tbl_voyage_type { get; set; }

        [StringLength(50)]
        [JsonProperty("Status")]
        public string tbl_voyage_status { get; set; }

        [StringLength(50)]
        [JsonProperty("Number")]
        [Description("Flight No./ Voyage No.")]
        [Required]
        public string tbl_voyage_number { get; set; }

        [StringLength(50)]
        [JsonProperty("CarrierCode")]
        [Description("Airline Code/ Principal Agent Id(Vessel Company Code)")]
        [Required]
        public string tbl_voyage_carrierCode { get; set; }

        [StringLength(50)]
        [JsonProperty("VesselNumber")]
        [Description("Vessel Number, used in sea freight only")]
        public string tbl_voyage_vesselNumber { get; set; }

        [StringLength(50)]
        [JsonProperty("LoadPort")]
        public string tbl_voyage_loadPort { get; set; }

        [StringLength(50)]
        [JsonProperty("DischargePort")]
        public string tbl_voyage_dischargePort { get; set; }

        [StringLength(50)]
        [JsonProperty("DestinationPort")]
        public string tbl_voyage_destinationPort { get; set; }

        [JsonProperty("ETD")]
        [Required]
        public DateTime? tbl_voyage_etd { get; set; }

        [JsonProperty("ETA")]
        public DateTime? tbl_voyage_eta { get; set; }

        [JsonProperty("ETADischarge")]
        public DateTime? tbl_voyage_etaDischarge { get; set; }

        [JsonProperty("ATD")]
        public DateTime? tbl_voyage_atd { get; set; }

        [JsonProperty("ATA")]
        public DateTime? tbl_voyage_ata { get; set; }

        public virtual ICollection<tbl_masterDto> masters { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_houseDto> houses { get; set; } = new Collection<tbl_houseDto>();
    }
}
