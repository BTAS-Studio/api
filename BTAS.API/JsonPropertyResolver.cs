using BTAS.API.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API
{
    public static class JsonPropertyResolver
    {
        public static JsonPropertyFields[] PropertyNames(this IContractResolver resolver, Type type)
        {
            if (resolver == null || type == null)
                throw new ArgumentNullException();
            var contract = resolver.ResolveContract(type) as JsonObjectContract;
            if (contract == null)
                return new JsonPropertyFields[0];
            return contract.Properties.Where(p => !p.Ignored).Select(p => new JsonPropertyFields { name = p.PropertyName, type = p.PropertyType.Name }).ToArray();
        }
    }
}
