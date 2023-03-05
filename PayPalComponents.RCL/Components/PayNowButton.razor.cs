using Microsoft.AspNetCore.Components;
using PayPal.Extensions;
using PayPalComponents.Extensions;
using PayPalComponents.Models;

namespace PayPalComponents
{
    public partial class PayNowButton
    {
        private IEnumerable<MarkupString> fields = Enumerable.Empty<MarkupString>();

        [Parameter]
        public PayPalEnvironment Environment { get; set; } = PayPalEnvironment.Sandbox;

        [Parameter]
        public Settings Settings { get; set; } = new();

        [Parameter]
        public string AmountFormat { get; set; } = "c2";

        protected override void OnInitialized()
        {
            fields = Settings.ToHiddenFormFields().Select(field => new MarkupString(field));
        }
    }
}