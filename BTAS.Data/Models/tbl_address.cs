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
            clientHeaders = new HashSet<tbl_client_header>();
        }
        public int idtbl_address { get; set; }
        public string tbl_address_code { get; set; }

        public bool? tbl_address_isPickup { get; set; }
        public bool? tbl_address_isDelivery { get; set; }
        public bool? tbl_address_isBilling { get; set; }

        public string tbl_address_companyName { get; set; }
        public string tbl_address_contactName { get; set; }
        public string tbl_address_email { get; set; }
        public string tbl_address_phone { get; set; }
        public string tbl_address_abn { get; set; }
        public string tbl_address_address1 { get; set; }
        public string tbl_address_address2 { get; set; }
        public string tbl_address_suburb { get; set; }
        public string tbl_address_city { get; set; }
        public string tbl_address_state { get; set; }
        public string tbl_address_postcode { get; set; }
        public string tbl_address_country { get; set; }
        public bool? tbl_address_tailLift { get; set; }
        public bool? tbl_address_forkLift { get; set; }
        public bool? tbl_address_customerUnloading { get; set; }
        public bool? tbl_address_handUnloading { get; set; }
        public bool? tbl_address_crane { get; set; }
        public bool? tbl_address_commercial { get; set; }
        public string tbl_address_description { get; set; }
        public TimeOnly? tbl_address_startTime { get; set; }
        public TimeOnly? tbl_address_endTime { get; set; }

        public virtual ICollection<tbl_client_header> clientHeaders{ get; set;}

        //public int? tbl_client_contact_detail_id { get; set; }
        //public string ClientContactDetailCode { get; set; }
        //public virtual tbl_client_contact_detail contactDetail { get; set; }
    }
}
