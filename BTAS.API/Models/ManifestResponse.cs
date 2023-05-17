using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{
    public class ManifestResponse : GeneralResponse
    {
        public DataArray dataArray { get; set; } = new DataArray();
    }

    public class DataArray
    {
        public List<ManifestMessage> message { get; set; } = new List<ManifestMessage>();
    }

    public class ManifestMessage
    {
        public bool success { get; set; } = true;
        public string manifest_ref { get; set; }
        public int manifested_count { get; set; } = 0;
        public int manifested_failed_count { get; set; } = 0;
        public List<string> failed_consignments { get; set; } = new List<string>();
        public string response { get; set; }
    }
}
