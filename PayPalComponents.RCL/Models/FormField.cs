using PayPalComponents.Extensions;

namespace PayPalComponents.Models
{
    internal class FormField
    {
        public FormField()
        {            
        }

        public FormField(string name, string? value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; } = default!; 
        public string? Value { get; set; } = default!;

        internal static IEnumerable<FormField> FromSettings(Settings settings) => settings
            .ToDictionary()
            .Select(kp => new FormField(kp.Key, kp.Value?.ToString()));
    }
}
