using BTAS.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTAS.API.Dto
{
    public class tbl_client_headerDto
    {
        [JsonProperty("Id")]
        [JsonIgnore]
        public int idtbl_client_header { get; set; }

        [StringLength(50)]
        [JsonProperty("Code")]
        [Description("Client details reference code")]
        public string tbl_client_header_code { get; set; }

        [JsonProperty("IsActive")]
        [Description("Set client details as active or inactive")]
        public bool? tbl_client_header_active { get; set; }

        [JsonProperty("IsAgent")]
        [Description("Set client details as agent")]
        public bool? tbl_client_header_isAgent { get; set; }
        [JsonProperty("IsConsignee")]
        [Description("Set client details as consignee")]
        public bool? tbl_client_header_isConsignee { get; set; }
        [JsonProperty("IsConsignor")]
        [Description("Set client details as consignor")]
        public bool? tbl_client_header_isConsignor { get; set; }
        [JsonProperty("IsBroker")]
        [Description("Set client details as broker")]
        public bool? tbl_client_header_isBroker { get; set; }
        [JsonProperty("IsCarrier")]
        [Description("Set client details as carrier")]
        public bool? tbl_client_header_isCarrier { get; set; }
        [JsonProperty("IsPayable")]
        [Description("Set client details for payables")]
        public bool? tbl_client_header_isPayable { get; set; }
        [JsonProperty("IsReceivable")]
        [Description("Set client details for receivables")]
        public bool? tbl_client_header_isReceivable { get; set; }
        [JsonProperty("IsWarehouse")]
        public bool? tbl_client_header_isWarehouse { get; set; }

        [StringLength(50)]
        [JsonProperty("CreatedBy")]
        //[DoNotInclude]
        public string tbl_client_header_createdBy { get; set; }
        [JsonProperty("CreatedDate")]
        //[DoNotInclude]
        public DateTime? tbl_client_header_createdDate { get; set; }
        [StringLength(100)]
        [JsonProperty("CompanyName")]
        [Description("Client's company name")]
        public string tbl_client_header_companyName { get; set; }
        [StringLength(50)]
        [JsonProperty("ContactName")]
        [Description("Set client's main contact person")]
        public string tbl_client_header_contactName { get; set; }
        [StringLength(50)]
        [JsonProperty("ContactEmail")]
        [Description("Set client's contact email")]
        public string tbl_client_header_email { get; set; }
        [StringLength(50)]
        [JsonProperty("ContactPhone")]
        [Description("Set client's contact number")]
        public string tbl_client_header_phone { get; set; }
        [StringLength(50)]
        [JsonProperty("ClosestPort")]
        [Description("Set client details closest port (if available)")]
        public string tbl_client_header_closestPort { get; set; }
        [StringLength(50)]
        [JsonProperty("ABN")]
        [Description("Set client's ABN")]
        public string tbl_client_header_abn { get; set; }

        //Added by HS on 10/07/2023 for legal entity address fields
        [StringLength(150)]
        [JsonProperty("Address1")]
        public string tbl_client_header_address1 { get; set; }
        [StringLength(150)]
        [JsonProperty("Address2")]
        public string tbl_client_header_address2 { get; set; }
        [StringLength(50)]
        [JsonProperty("Suburb")]
        public string tbl_client_header_suburb { get; set; }
        [StringLength(50)]
        [JsonProperty("City")]
        public string tbl_client_header_city { get; set; }
        [StringLength(50)]
        [JsonProperty("State")]
        public string tbl_client_header_state { get; set; }
        [StringLength(50)]
        [JsonProperty("Postcode")]
        public string tbl_client_header_postcode { get; set; }
        [StringLength(50)]
        [JsonProperty("Country")]
        public string tbl_client_header_country { get; set; }

        public virtual ICollection<tbl_addressDto> addresses { get; set; } = new Collection<tbl_addressDto>();

        public virtual ICollection<tbl_client_contact_detailDto> contactDetails { get; set; } = new Collection<tbl_client_contact_detailDto>(); 

        public virtual ICollection<tbl_houseDto> consigneeHouses { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_houseDto> consignorHouses { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_houseDto> pickupClientHouses { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_houseDto> deliveryClientHouses { get; set; } = new Collection<tbl_houseDto>();

        public virtual ICollection<tbl_masterDto> carrierMasters { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_masterDto> creditorMasters { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_masterDto> destinationClientMasters { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_masterDto> originClientMasters { get; set; } = new Collection<tbl_masterDto>();

        public virtual ICollection<tbl_noteDto> notes { get; set; } = new Collection<tbl_noteDto>();
    }
}
