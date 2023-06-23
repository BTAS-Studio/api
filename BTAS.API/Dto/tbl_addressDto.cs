using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.API.Dto
{
    public class tbl_addressDto
    {
        [JsonProperty("Id")]
        [DoNotInclude]
        public int idtbl_address { get; set; }
        [StringLength(50)]
        [JsonProperty("Code")]
        public string tbl_address_code { get; set; }
        [StringLength(50)]
        [JsonProperty("Type")]
        public string tbl_address_type { get; set; }
        [StringLength(150)]
        [JsonProperty("Address1")]
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
        public string tbl_address_postcode { get; set; }
        [StringLength(50)]
        [JsonProperty("Country")]
        public string tbl_address_country { get; set; }
        public virtual ICollection<tbl_client_headerDto> billingClients { get; set; } = new Collection<tbl_client_headerDto>();
        public virtual ICollection<tbl_client_headerDto> deliveryClients { get; set; } = new Collection<tbl_client_headerDto>();
        public virtual ICollection<tbl_client_headerDto> pickupClients { get; set; } = new Collection<tbl_client_headerDto>();
        public virtual ICollection<tbl_client_contact_detailDto> contactDetails { get; set; } = new Collection<tbl_client_contact_detailDto>();
    }
}
