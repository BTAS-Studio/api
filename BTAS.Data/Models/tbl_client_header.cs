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
            consigneeHouses = new HashSet<tbl_house>();
            consignorHouses = new HashSet<tbl_house>();
            pickupClientHouses = new HashSet<tbl_house>();
            deliveryClientHouses = new HashSet<tbl_house>();
            carrierMasters = new HashSet<tbl_master>();
            creditorMasters = new HashSet<tbl_master>();
            destinationClientMasters = new HashSet<tbl_master>();
            originClientMasters = new HashSet<tbl_master>();
            notes = new HashSet<tbl_note>();
        }

        public int idtbl_client_header { get; set; }
        public string tbl_client_header_code { get; set; }
        public bool? tbl_client_header_active { get; set; }
        public bool? tbl_client_header_isAgent { get; set; }
        public bool? tbl_client_header_isConsignee { get; set; }
        public bool? tbl_client_header_isConsignor { get; set; }
        public bool? tbl_client_header_isBroker { get; set; }
        public bool? tbl_client_header_isCarrier { get; set; }
        public bool? tbl_client_header_isPayable { get; set; }
        public bool? tbl_client_header_isReceivable { get; set; }
        public bool? tbl_client_header_isWarehouse { get; set; }
        public string tbl_client_header_createdBy { get; set; }
        public DateTime tbl_client_header_createdDate { get; set; }
        public string tbl_client_header_companyName { get; set; }
        public string tbl_client_header_contactName { get; set; }
        public string tbl_client_header_email { get; set; }
        public string tbl_client_header_phone { get; set; }
        public string tbl_client_header_closestPort { get; set; }
        public string tbl_client_header_abn { get; set; }

        public virtual tbl_address legalEntityAddress { get; set; }

        public virtual ICollection<tbl_client_contact_detail> contactDetails { get; set; }
        public virtual ICollection<tbl_house> consigneeHouses { get; set; }
        public virtual ICollection<tbl_house> consignorHouses { get; set; }
        public virtual ICollection<tbl_house> pickupClientHouses { get; set; }
        public virtual ICollection<tbl_house> deliveryClientHouses { get; set; }
        public virtual ICollection<tbl_master> carrierMasters { get; set; }
        public virtual ICollection<tbl_master> creditorMasters { get; set; }
        public virtual ICollection<tbl_master> destinationClientMasters { get; set; }
        public virtual ICollection<tbl_master> originClientMasters { get; set; }
        public virtual ICollection<tbl_note> notes { get; set; }
    }
}
