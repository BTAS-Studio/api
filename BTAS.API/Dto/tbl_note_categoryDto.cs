using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BTAS.API.Dto
{
    public class tbl_note_categoryDto
    {
        [JsonProperty("Id")]
        [DoNotInclude]
        public int idtbl_note_category { get; set; }

        [StringLength(50)]
        [JsonProperty("Code")]
        public string tbl_note_category_code { get; set; }

        [StringLength(50)]
        [JsonProperty("Name")]
        public string tbl_note_category_name { get; set; }

        [StringLength(50)]
        [JsonProperty("Color")]
        public string tbl_note_category_color { get; set; }

        [StringLength(50)]
        [JsonProperty("Value")]
        public string tbl_note_category_value { get; set; }

        public virtual ICollection<tbl_noteDto> notes { get; set; } = new Collection<tbl_noteDto>();
    }
}
