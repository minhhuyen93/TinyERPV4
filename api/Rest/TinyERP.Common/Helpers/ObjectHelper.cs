using System;
using System.Reflection;

namespace TinyERP.Common.Helpers
{
    public class ObjectHelper
    {
        public static TAttributeType GetAttribute<TAttributeType>(Type type) where TAttributeType : System.Attribute
        {
            return type.GetCustomAttribute<TAttributeType>();
        }
    }
}
