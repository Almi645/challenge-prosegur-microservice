using Challenge.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Common.Utility
{
    public static class ExtendUtility
    {
        public static string GetValue(this object value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            var result = attribs.Length > 0 ? attribs[0].StringValue : null;
            return result;
        }
    }
}
