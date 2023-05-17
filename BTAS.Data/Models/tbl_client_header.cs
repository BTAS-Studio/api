using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_client_header
    {
        public tbl_client_header()
        {
            contactDetails = new HashSet<tbl_client_contact_detail>();
            consignees = new HashSet<tbl_house>();
            consignors = new HashSet<tbl_house>();
            carriers = new HashSet<tbl_master>();
            creditors = new HashSet<tbl_master>();
            destinations = new HashSet<tbl_master>();
            origins = new HashSet<tbl_master>();
        }

        public int idtbl_client_header { get; set; }
        public string tbl_client_header_code { get; set; }
        public bool tbl_client_header_active { get; set; }
        public bool tbl_client_header_is_agent { get; set; }
        public bool tbl_client_header_is_consignee { get; set; }
        public bool tbl_client_header_is_consignor { get; set; }
        public bool tbl_client_header_is_broker { get; set; }
        public bool tbl_client_header_is_carrier { get; set; }
        public bool tbl_client_header_is_payable { get; set; }
        public bool tbl_client_header_is_receivable { get; set; }
        public string tbl_client_header_createdBy { get; set; }
        public DateTime tbl_client_header_createdDate { get; set; }
        public string tbl_client_header_companyName { get; set; }
        public string tbl_client_header_contactName { get; set; }
        public string tbl_client_header_email { get; set; }
        public string tbl_client_header_phone { get; set; }
        public string tbl_client_header_closestPort { get; set; }
        public string tbl_client_header_abn { get; set; }

        public int? tbl_delivery_address_id { get; set; }
        public string DeliveryAddressCode { get; set; }
        public virtual tbl_address deliveryAddress { get; set; }

        public int? tbl_billing_address_id { get; set; }
        public string BillingAddressCode { get; set; }
        public virtual tbl_address billingAddress { get; set; }

        public int? tbl_pickup_address_id { get; set; }
        public string PickupAddressCode { get; set; }
        public virtual tbl_address pickupAddress { get; set; }

        public virtual ICollection<tbl_client_contact_detail> contactDetails { get; set; }
        public virtual ICollection<tbl_house> consignees { get; set; }
        public virtual ICollection<tbl_house> consignors { get; set; }
        public virtual ICollection<tbl_master> carriers { get; set; }
        public virtual ICollection<tbl_master> creditors { get; set; }
        public virtual ICollection<tbl_master> destinations { get; set; }
        public virtual ICollection<tbl_master> origins { get; set; }
    }
}
