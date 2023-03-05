namespace TestApp.Extensions
{
    public record DropdownOption<TValue> where TValue : struct
    {
        public DropdownOption(TValue value, string text)
        {
            Value = value;
            Text = text;
        }

        public TValue Value { get; init; } = default!;
        public string Text { get; init; } = default!;

        public override string ToString() => Text;        
    }

    public static class DropDownData
    {
        public static IEnumerable<DropdownOption<TEnum>> FromEnum<TEnum>() where TEnum : struct            
        {            
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
            var names = Enum.GetNames(typeof(TEnum));

            List<DropdownOption<TEnum>> results = new();

            for (int i = 0; i < values.Length; i++)
            {
                results.Add(new DropdownOption<TEnum>(values[i], names[i]));
            }
            
            return results;
        }
    }
}
