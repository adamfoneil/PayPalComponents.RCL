using System.Reflection;
using System.Web;
using PayPalComponents.Attributes;

namespace PayPalComponents.Extensions
{
    public static class ObjectExtensions
    {
        public static IEnumerable<string> ToHiddenFormFields(this object @object)
        {
            ArgumentNullException.ThrowIfNull(@object, nameof(@object));
            
            var properties = @object.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(@object);
                if (value != null)
                {
                    var fieldAttr = property.GetCustomAttribute<FieldNameAttribute>() ?? new FieldNameAttribute(property.Name);
                    yield return $"<input type=\"hidden\" name=\"{fieldAttr.FieldName}\" value=\"{HttpUtility.UrlEncode(value.ToString())}\"/>";                        
                }
            }
        }
    }
}
