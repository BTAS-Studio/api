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
        //Edited by HS on 30/01/2023
        [DoNotInclude]
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
        public bool? tbl_client_header_is_agent { get; set; }
        [JsonProperty("IsConsignee")]
        [Description("Set client details as consignee")]
        public bool? tbl_client_header_is_consignee { get; set; }
        [JsonProperty("IsConsignor")]
        [Description("Set client details as consignor")]
        public bool? tbl_client_header_is_consignor { get; set; }
        [JsonProperty("IsBroker")]
        [Description("Set client details as broker")]
        public bool? tbl_client_header_is_broker { get; set; }
        [JsonProperty("IsCarrier")]
        [Description("Set client details as carrier")]
        public bool? tbl_client_header_is_carrier { get; set; }
        [JsonProperty("IsPayable")]
        [Description("Set client details for payables")]
        public bool? tbl_client_header_is_payable { get; set; }
        [JsonProperty("IsReceivable")]
        [Description("Set client details for receivables")]
        public bool? tbl_client_header_is_receivable { get; set; }
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
        [JsonProperty("ContactPerson")]
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

        public virtual tbl_addressDto legalEntityAddress { get; set; }
        //public virtual ICollection<tbl_addressDto> addresses { get; set; } = new Collection<tbl_addressDto>();
        public virtual ICollection<tbl_client_contact_detailDto> contactDetails { get; set; } = new Collection<tbl_client_contact_detailDto>(); 
        public virtual ICollection<tbl_noteDto> notes { get; set; } = new Collection<tbl_noteDto>();
        public virtual ICollection<tbl_houseDto> consigneeHouses { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_houseDto> consignorHouses { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_houseDto> pickupClientHouses { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_houseDto> deliveryClientHouses { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_masterDto> carrierMasters { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_masterDto> creditorMasters { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_masterDto> destinationClientMasters { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_masterDto> originClientMasters { get; set; } = new Collection<tbl_masterDto>();
    }
}
