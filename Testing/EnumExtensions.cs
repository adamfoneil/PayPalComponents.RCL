using TestApp.Extensions;

namespace Testing
{
    public enum SampleEnum
    {
        This,
        That,
        Other
    }

    [TestClass]
    public class EnumExtensions
    {
        [TestMethod]
        public void EnumDropDown()
        {
            var data = DropDownData.FromEnum<SampleEnum>().ToDictionary(item => item.Value, item => item.Text);
            Assert.IsTrue(data.ContainsKey(0));
            Assert.IsTrue(data[0].Equals("This"));
            Assert.IsTrue(data.ContainsKey(SampleEnum.This));
            Assert.IsTrue(data[SampleEnum.That].Equals("That"));
            Assert.IsTrue(data.ContainsKey(SampleEnum.Other));
            Assert.IsTrue(data[SampleEnum.Other].Equals("Other"));
        }
    }
}
