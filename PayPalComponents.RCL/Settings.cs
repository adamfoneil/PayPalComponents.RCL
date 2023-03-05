using PayPalComponents.Attributes;

namespace PayPalComponents
{
    public class Settings
    {
        [FieldName("business")]
        public string BusinessEmail { get; set; } = default!;

        [FieldName("amount")]
        public decimal Amount { get; set; }

        [FieldName("item_name")]
        public string ItemName { get; set; } = default!;

        [FieldName("item_number")]
        public string ItemNumber { get; set; } = default!;

        [FieldName("return")]
        public string ReturnUrl { get; set; } = default!;

        [FieldName("notify_url")]
        public string NotifyUrl { get; set; } = default!;
    }
}
