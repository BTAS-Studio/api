using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BTAS.API.Dto
{
    public class tbl_note_categoryDto
    {
        public int idtbl_note_category { get; set; }
        public string tbl_note_category_code { get; set; }
        public string tbl_note_category_name { get; set; }
        public string tbl_note_category_color { get; set; }
        public string tbl_note_category_value { get; set; }

        public virtual ICollection<tbl_noteDto> notes { get; set; } = new Collection<tbl_noteDto>();
    }
}
