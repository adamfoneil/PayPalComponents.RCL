using System.Reflection;
using System.Web;
using PayPalComponents.Attributes;

namespace PayPalComponents.Extensions
{
    public static class ObjectExtensions
    {
        public static IEnumerable<KeyValuePair<string, object>> ToStringKeyPairs(this object @object) =>
            ToEnumerable(@object, (name, value) => new KeyValuePair<string, object>(name, value));
        
        public static IEnumerable<T> ToEnumerable<T>(this object @object, Func<string, object, T> propertyMethod)
        {
            ArgumentNullException.ThrowIfNull(@object, nameof(@object));

            var properties = @object.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(@object);
                if (value is not null)
                {
                    var fieldAttr = property.GetCustomAttribute<FieldNameAttribute>() ?? new FieldNameAttribute(property.Name);
                    yield return propertyMethod.Invoke(fieldAttr.FieldName, value);
                }
            }
        }

        public static T ToObject<T>(this IEnumerable<(string FieldName, string PropertyName)> fieldMappings, Dictionary<string, object> fieldValues) where T : new()
        {
            T result = new();
            var props = typeof(T).GetProperties().Where(pi => pi.CanWrite);

            var mappings = fieldMappings
                .Join(props, m => m.PropertyName, pi => pi.Name, (m, pi) => new { m.FieldName, Property = pi })
                .ToDictionary(item => item.FieldName, item => item.Property);

            foreach (var kp in mappings)
            {
                if (fieldValues.TryGetValue(kp.Key, out object value))
                {
                    var conversion = new Dictionary<Type, Func<object, object>>()
                    {
                        [typeof(decimal)] = (val) => Convert.ToDecimal(val),
                        [typeof(DateTime)] = (val) => Convert.ToDateTime(val)
                    };

                    var setValue = (conversion.ContainsKey(kp.Value.PropertyType)) ? 
                        conversion[kp.Value.PropertyType].Invoke(value) : 
                        value;
                    
                    kp.Value.SetValue(result, setValue);
                }
            }

            return result;
        }

        public static Dictionary<string, object> ToDictionary(this object @object) => 
            ToStringKeyPairs(@object).ToDictionary(kp => kp.Key, kp => kp.Value);

        public static IEnumerable<string> ToHiddenFormFields(this object @object) => ToStringKeyPairs(@object)
            .Select(kp => $"<input type=\"hidden\" name=\"{kp.Key}\" value=\"{HttpUtility.HtmlEncode(kp.Value)}\"/>");        
    }
}
