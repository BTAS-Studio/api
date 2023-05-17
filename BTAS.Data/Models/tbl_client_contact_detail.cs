using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_client_contact_detail
    {
        public tbl_client_contact_detail()
        {
            contactGroups = new HashSet<tbl_client_contact_group>();
        }

        public int idtbl_client_contact_detail { get; set; }
        public string tbl_client_contact_details_code { get; set; }
        public bool? tbl_client_contact_details_isActive { get; set; }
        public string tbl_client_contact_details_type { get; set; }
        public string tbl_client_contact_details_companyName { get; set; }
        public string tbl_client_contact_details_contactName { get; set; }
        public string tbl_client_contact_details_phone { get; set; }
        public string tbl_client_contact_details_email { get; set; }

        public int? tbl_client_header_id { get; set; }
        public string ClientHeaderCode { get; set; }
        public virtual tbl_client_header clientHeader { get; set; }

        public int? tbl_address_id { get; set; }
        public string AddressCode { get; set; }
        public virtual tbl_address address { get; set; }

        public virtual ICollection<tbl_client_contact_group> contactGroups { get; set; }
    }
}
