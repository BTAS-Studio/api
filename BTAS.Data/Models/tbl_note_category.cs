using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.Data.Models
{
    public partial class tbl_note_category
    {
        public tbl_note_category() 
        {
            notes = new HashSet<tbl_note>();
        }
        public int idtbl_note_category { get; set; }
        public string tbl_note_category_code { get; set; }
        public string tbl_note_category_name { get; set; }
        public string tbl_note_category_color { get; set; }
        public string tbl_note_category_value { get; set; }

        public virtual ICollection<tbl_note> notes { get; set; }
    }
}
