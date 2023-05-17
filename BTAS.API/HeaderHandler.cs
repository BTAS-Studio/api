using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API
{
    public class HeaderHandler
    {
        private HttpContext _context;
        public HeaderHandler(HttpContext context)
        {
            _context = context;
        }
    }
}
