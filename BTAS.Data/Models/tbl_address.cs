using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_address
    {
        public tbl_address()
        {
            contactDetails = new HashSet<tbl_client_contact_detail>();
            billingAddresses = new HashSet<tbl_client_header>();
            deliveryAddresses = new HashSet<tbl_client_header>();
            pickupAddresses = new HashSet<tbl_client_header>();
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
        public virtual ICollection<tbl_client_header> billingAddresses { get; set; }
        public virtual ICollection<tbl_client_header> deliveryAddresses { get; set; }
        public virtual ICollection<tbl_client_header> pickupAddresses { get; set; }
    }
}
