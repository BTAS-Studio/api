using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BTAS.BlazorApp.Models
{
    public class DoNotIncludeAttribute : Attribute
    {
    }

    public static class ExtensionsOfPropertyInfo
    {
        public static IEnumerable<T> GetAttributes<T>(this PropertyInfo propertyInfo) where T : Attribute
        {
            return propertyInfo.GetCustomAttributes(typeof(T), true).Cast<T>();
        }
        public static bool IsMarkedWith<T>(this PropertyInfo propertyInfo) where T : Attribute
        {
            return propertyInfo.GetAttributes<T>().Any();
        }
    }
}
