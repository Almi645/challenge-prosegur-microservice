using Challenge.Common.Attributes;
using System.Reflection;

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
