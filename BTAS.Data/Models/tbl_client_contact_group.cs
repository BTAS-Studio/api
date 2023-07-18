using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_client_contact_group
    {
        public tbl_client_contact_group()
        {
            contactDetails = new HashSet<tbl_client_contact_detail>();
        }

        public int idtbl_client_contact_group { get; set; }
        public string tbl_client_contact_group_code { get; set; }
        public string tbl_client_contact_group_name { get; set; }
        public bool? tbl_client_contact_group_isDefault { get; set; }
        public bool? tbl_client_contact_group_isActive { get; set; }

        public virtual ICollection<tbl_client_contact_detail> contactDetails { get; set; }
    }
}
