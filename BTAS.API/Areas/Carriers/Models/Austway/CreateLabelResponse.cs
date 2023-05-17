using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Austway
{
    public class CreateLabelResponse
    {
        public string Status { get; set; } = "Success";
        public string Base64Label { get; set; }
    }
}
