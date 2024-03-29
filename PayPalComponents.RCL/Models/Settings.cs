﻿using PayPalComponents.Attributes;
using PayPalComponents.Extensions;

namespace PayPalComponents.Models
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

        [FieldName("currency_code")]
        public string CurrencyCode { get; set; } = "USD";

        [FieldName("no_shipping")]
        public bool ShippingDisabled { get; set; }

        public static Settings FromDictionary(Dictionary<string, object> dictionary) => new[]
        {
            ("business", nameof(BusinessEmail)),
            ("amount", nameof(Amount)),
            ("item_name", nameof(ItemName)),
            ("item_number", nameof(ItemNumber)),
            ("return", nameof(ReturnUrl)),
            ("notify_url", nameof(NotifyUrl)),
            ("no_shipping", nameof(ShippingDisabled))
        }.ToObject<Settings>(dictionary);        
    }
}
