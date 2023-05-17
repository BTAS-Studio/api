using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_container
    {
        public tbl_container()
        {
            houses = new HashSet<tbl_house>();
        }

        public int idtbl_container { get; set; }
        public string tbl_container_code { get; set; }
        public string tbl_container_status { get; set; }
        public string tbl_container_number { get; set; }
        public string tbl_container_isoType { get; set; }
        public string tbl_container_cargoType { get; set; }
        public string tbl_container_sealNumber { get; set; }
        public int tbl_container_qty { get; set; }
        public decimal tbl_container_grossWeight { get; set; }
        public DateTime tbl_container_createdDate { get; set; }
        public string tbl_container_sealedBy { get; set; }
        
        public int? tbl_master_id { get; set; }
        public string MasterCode { get; set; }
        public virtual tbl_master master { get; set; }

        public virtual ICollection<tbl_house> houses { get; set; }
    }
}
