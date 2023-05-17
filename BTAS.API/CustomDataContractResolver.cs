using BTAS.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BTAS.API
{
    public class CustomDataContractResolver : DefaultContractResolver
    {
        public static readonly CustomDataContractResolver Instance = new CustomDataContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(ShipmentDetails))
            {
                if (property.PropertyName.Equals("LongPropertyName", StringComparison.OrdinalIgnoreCase))
                {
                    property.PropertyName = "Short";
                }
            }
            return property;
        }
    }

}
