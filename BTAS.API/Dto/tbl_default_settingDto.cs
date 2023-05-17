using System;
using Newtonsoft.Json;

namespace BTAS.API.Dto
{
    public class tbl_default_settingDto
    {
        [JsonProperty("Id")]
        public int idtbl_default_setting { get; set; }
        [JsonProperty("Type")]
        public string tbl_address_type { get; set; }
        [JsonProperty("IncotermsId")]
        public int tbl_incoterm_id { get; set; }
        [JsonProperty("IsBillTo")]
        public bool isBillTo { get; set; } = false;
        [JsonProperty("ContactGroupId")]
        public int tbl_contact_group_id { get; set; }
        [JsonProperty("IsActive")]
        public bool tbl_default_settings_active { get; set; }
        [JsonProperty("DateAdded")]
        public DateTime DateAdded { get; set; }
        [JsonProperty("AddedBy")]
        public string AddedBy { get; set; }
    }
}
