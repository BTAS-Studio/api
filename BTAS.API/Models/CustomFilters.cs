using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{
    public class CustomFilters<T> where T : class
    {
        //public string UserName { get; set; }
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 20;
        //public T Parent { get; set; }
        public List<CustomFilter<dynamic>> Filters { get; set; }
    }
}
