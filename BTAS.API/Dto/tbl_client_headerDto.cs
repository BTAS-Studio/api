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
        //[StringLength(150)]
        //[JsonProperty("Address1")]
        //[Description("Set client details address line #1")]
        //public string tbl_client_header_address1 { get; set; }
        //[StringLength(150)]
        //[JsonProperty("Address2")]
        //[Description("Set client details address line #2")]
        //public string tbl_client_header_address2 { get; set; }
        //[StringLength(50)]
        //[JsonProperty("Suburb")]
        //[Description("Set client details suburb (if available)")]
        //public string tbl_client_header_suburb { get; set; }
        //[StringLength(50)]
        //[JsonProperty("City")]
        //[Description("Set client details city")]
        //public string tbl_client_header_city { get; set; }
        //[StringLength(50)]
        //[JsonProperty("PostCode")]
        //[Description("Set client details post code")]
        //public string tbl_client_header_postcode { get; set; }
        //[StringLength(50)]
        //[JsonProperty("State")]
        //[Description("Set client details state (if available)")]
        //public string tbl_client_header_state { get; set; }
        //[StringLength(50)]
        //[JsonProperty("Country")]
        //[Description("Set client details country")]
        //public string tbl_client_header_country { get; set; }

        //public int? tbl_master_origin_id { get; set; }
        //public virtual tbl_master masterOrigin { get; set; }
        //public int? tbl_master_destination_id { get; set; }
        //public virtual tbl_master masterDestination { get; set; }
        //public int? tbl_master_carrier_id { get; set; }
        //public virtual tbl_master masterCarrier { get; set; }
        //public int? tbl_master_creditor_id { get; set; }
        //public virtual tbl_master masterCreditor { get; set; }
        [JsonProperty("DeliveryAddressId")]
        [DoNotInclude]
        public int? tbl_delivery_address_id { get; set; }
        [StringLength(50)]
        [JsonProperty("DeliveryAddressCode")]
        public string DeliveryAddressCode { get; set; }
        [ForeignKey("tbl_delivery_address_id")]
        [JsonProperty("DeliveryAddress")]
        [DoNotInclude]
        public virtual tbl_address deliveryAddress { get; set; }
        [JsonProperty("BillingAddressId")]
        [DoNotInclude]
        public int? tbl_billing_address_id { get; set; }
        [StringLength(50)]
        [JsonProperty("BillingAddressCode")]
        [Description("The billing address code linked to this client")]
        public string BillingAddressCode { get; set; }
        [JsonProperty("BillingAddress")]
        [DoNotInclude]
        public virtual tbl_address billingAddress { get; set; }
        [JsonProperty("PickupAddressId")]
        [DoNotInclude]
        public int? tbl_pickup_address_id { get; set; }
        [StringLength(50)]
        [JsonProperty("PickupAddressCode")]
        [Description("The pickup address code linked to this client")]
        public string PickupAddressCode { get; set; }
        [JsonProperty("PickupAddress")]
        [DoNotInclude]
        public virtual tbl_address pickupAddress { get; set; }
        [JsonProperty("ContactDetails")]
        [Description("A json array of contact details request paramaters for auto creating in a single request.")]
        [DoNotInclude]
        public virtual ICollection<tbl_client_contact_detailDto> contactDetails { get; set; } = new Collection<tbl_client_contact_detailDto>(); 
        public virtual ICollection<tbl_noteDto> notes { get; set; } = new Collection<tbl_noteDto>();
        public virtual ICollection<tbl_houseDto> consignees { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_houseDto> consignors { get; set; } = new Collection<tbl_houseDto>();
        public virtual ICollection<tbl_masterDto> carriers { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_masterDto> creditors { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_masterDto> destinations { get; set; } = new Collection<tbl_masterDto>();
        public virtual ICollection<tbl_masterDto> origins { get; set; } = new Collection<tbl_masterDto>();
    }
}
