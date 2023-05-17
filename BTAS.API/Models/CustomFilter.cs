using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Models
{
    public class CustomFilter<T> where T : class
    {
        //Mandatory
        public string tableName { get; set; }
        
        //Mandatory
        public string condition { get; set; }

        //Mandatory
        public object searchField { get; set; }

        //API private use only, the name property of serachField
        public string fieldName { get; set; }

        //API private use only, the value property of searchField
        public object fieldValue { get; set; }


    }
}
