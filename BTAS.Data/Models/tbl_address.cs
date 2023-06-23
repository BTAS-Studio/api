using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_address
    {
        public tbl_address()
        {
            contactDetails = new HashSet<tbl_client_contact_detail>();
            billingClients = new HashSet<tbl_client_header>();
            deliveryClients = new HashSet<tbl_client_header>();
            pickupClients = new HashSet<tbl_client_header>();

        }

        public int idtbl_address { get; set; }
        public string tbl_address_code { get; set; }
        public string tbl_address_type { get; set; }
        public string tbl_address_address1 { get; set; }
        public string tbl_address_address2 { get; set; }
        public string tbl_address_suburb { get; set; }
        public string tbl_address_city { get; set; }
        public string tbl_address_state { get; set; }
        public string tbl_address_postcode { get; set; }
        public string tbl_address_country { get; set; }

        public virtual ICollection<tbl_client_contact_detail> contactDetails { get; set; }
        public virtual ICollection<tbl_client_header> billingClients { get; set; }
        public virtual ICollection<tbl_client_header> deliveryClients { get; set; }
        public virtual ICollection<tbl_client_header> pickupClients { get; set; }
    }
}
