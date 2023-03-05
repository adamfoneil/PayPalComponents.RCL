using PayPalComponents;
using PayPalComponents.Extensions;
using PayPalComponents.Models;

namespace Testing
{
    [TestClass]
    public class FormFields
    {
        [TestMethod]
        public void SampleForm()
        {
            var settings = new Settings()
            {
                BusinessEmail = "adamoosftware@gmail.com",
                ItemName = "Whatever",
                ItemNumber = "2943-3433",
                Amount = 43.22m
            };

            var fieldMarkup = string.Join("\r\n", settings.ToHiddenFormFields());

            Assert.IsTrue(fieldMarkup.Equals(
@"<input type=""hidden"" name=""business"" value=""adamoosftware%40gmail.com""/>
<input type=""hidden"" name=""amount"" value=""43.22""/>
<input type=""hidden"" name=""item_name"" value=""Whatever""/>
<input type=""hidden"" name=""item_number"" value=""2943-3433""/>"));
        }
    }
}