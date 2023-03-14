using System.Reflection;
using System.Web;
using PayPalComponents.Attributes;

namespace PayPalComponents.Extensions
{
    public static class ObjectExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> ToStringKeyPairs(this object @object) =>
            ToEnumerable(@object, (name, value) => new KeyValuePair<string, string>(name, value));
        
        public static IEnumerable<T> ToEnumerable<T>(this object @object, Func<string, string, T> propertyMethod)
        {
            ArgumentNullException.ThrowIfNull(@object, nameof(@object));

            var properties = @object.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(@object);
                if (value is not null)
                {
                    var fieldAttr = property.GetCustomAttribute<FieldNameAttribute>() ?? new FieldNameAttribute(property.Name);
                    yield return propertyMethod.Invoke(fieldAttr.FieldName, value.ToString());
                }
            }
        }

        public static Dictionary<string, string> ToStringDictionary(this object @object) => 
            ToStringKeyPairs(@object).ToDictionary(kp => kp.Key, kp => kp.Value);

        public static IEnumerable<string> ToHiddenFormFields(this object @object) => ToStringKeyPairs(@object)
            .Select(kp => $"<input type=\"hidden\" name=\"{kp.Key}\" value=\"{HttpUtility.HtmlEncode(kp.Value)}\"/>");        
    }
}
