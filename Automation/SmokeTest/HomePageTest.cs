using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Automation
{
    [TestClass]
    public class UnitTest1 : TestBase
    {
        [TestMethod]
        public void AddCart()
        {
            Page.homePage.Navigate();
            Page.homePageHelper.NavigateTo("Frozen");
            Page.homePageHelper.SelectItem("aMagnum");
        }

    }
}
