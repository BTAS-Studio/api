using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Dto
{
    public class indexerDto
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        // Indexer property to access the property values using the indexing syntax
        public object this[string propertyName]
        {
            get
            {
                if (properties.ContainsKey(propertyName))
                {
                    return properties[propertyName];
                }
                return null;
            }
            set
            {
                properties[propertyName] = value;
            }
        }
    }
}
