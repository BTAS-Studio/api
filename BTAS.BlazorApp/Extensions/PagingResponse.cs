using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Extensions
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
    }
}
