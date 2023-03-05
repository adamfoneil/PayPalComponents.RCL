namespace PayPalComponents.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class FieldNameAttribute : Attribute
    {
        public FieldNameAttribute(string name)
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            FieldName = name;
        }

        public string FieldName { get; }
    }
}
