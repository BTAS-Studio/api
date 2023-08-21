using BTAS.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.API.Dto
{
    public class tbl_addressDto
    {
        [JsonProperty("Id")]
        //[JsonIgnore]
        public int idtbl_address { get; set; }
        [StringLength(50)]
        [JsonProperty("Code")]
        public string tbl_address_code { get; set; }

        [JsonProperty("IsPickup")]
        public bool? tbl_address_isPickup { get; set; }
        [JsonProperty("IsDelivery")]
        public bool? tbl_address_isDelivery { get; set; }
        [JsonProperty("IsBilling")]
        public bool? tbl_address_isBilling { get; set; }
        [StringLength(150)]
        [JsonProperty("CompanyName")]
        [Required]
        public string tbl_address_companyName { get; set; }
        [StringLength(50)]
        [JsonProperty("ContactName")]
        public string tbl_address_contactName { get; set; }
        [StringLength(50)]
        [JsonProperty("Email")]
        public string tbl_address_email { get; set; }
        [StringLength(50)]
        [JsonProperty("Phone")]
        public string tbl_address_phone { get; set; }
        [StringLength(50)]
        [JsonProperty("ABN")]
        public string tbl_address_abn { get; set; }
        [StringLength(150)]
        [JsonProperty("Address1")]
        [Required]
        public string tbl_address_address1 { get; set; }
        [StringLength(150)]
        [JsonProperty("Address2")]
        public string tbl_address_address2 { get; set; }
        [StringLength(50)]
        [JsonProperty("Suburb")]
        public string tbl_address_suburb { get; set; }
        [StringLength(50)]
        [JsonProperty("City")]
        public string tbl_address_city { get; set; }
        [StringLength(50)]
        [JsonProperty("State")]
        public string tbl_address_state { get; set; }
        [StringLength(50)]
        [JsonProperty("Postcode")]
        [Required]
        public string tbl_address_postcode { get; set; }
        [StringLength(50)]
        [JsonProperty("Country")]
        public string tbl_address_country { get; set; }
        [JsonProperty("TailLift")]
        public bool? tbl_address_tailLift { get; set; }
        [JsonProperty("ForkLift")]
        public bool? tbl_address_forkLift { get; set; }
        [JsonProperty("CustomerUnloading")]
        public bool? tbl_address_customerUnloading { get; set; }
        [JsonProperty("HandUnloading")]
        public bool? tbl_address_handUnloading { get; set; }
        [JsonProperty("Crane")]
        public bool? tbl_address_crane { get; set; }
        [JsonProperty("Commercial")]
        public bool? tbl_address_commercial { get; set; }
        [JsonProperty("Description")]
        public string tbl_address_description { get; set; }
        [JsonProperty("StartTime")]
        public TimeOnly? tbl_address_startTime { get; set; }
        [JsonProperty("EndTime")]
        public TimeOnly? tbl_address_endTime { get; set; }

        public virtual ICollection<tbl_client_headerDto> clientHeaders { get; set; }

    }
}
