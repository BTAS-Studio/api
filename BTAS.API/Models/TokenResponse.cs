using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{
    public class TokenResponse
    {
        public bool success { get; set; } = true;
        public int response { get; set; } = 200;
        public string responseDescription { get; set; } = "success";
        public TokenResponseDetails dataArray { get; set; }
    }

    public class TokenResponseDetails
    {
        public string token { get; set; }
    }
}
