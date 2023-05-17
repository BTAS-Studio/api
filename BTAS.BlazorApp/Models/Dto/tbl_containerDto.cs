using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Models.Dto
{
    public class tbl_containerDto
    {
        public int idtbl_container { get; set; }
        public int tbl_container_qty { get; set; }
        [StringLength(30)]
        public string tbl_container_sealNumber { get; set; }
        [StringLength(30)]
        public string tbl_container_mode { get; set; }
        [StringLength(30)]
        public string tbl_container_type { get; set; }
        public decimal tbl_container_grossWeight { get; set; }
        public DateTime tbl_container_createdDate { get; set; }
        [StringLength(30)]
        public string tbl_container_sealedBy { get; set; }
        public int tbl_mawb_id { get; set; }
        public virtual tbl_mawbDto tbl_mawb { get; set; }

        public ICollection<tbl_hawbDto> hawbs { get; set; } = new Collection<tbl_hawbDto>();
    }
}
