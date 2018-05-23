using Builder.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Automation
{
    [TestClass]
    public class SmokeTest : TestBase
    {
        [DataRow(BrowserName.Chrome)]
        [DataRow(BrowserName.Firefox)]
        [DataRow(BrowserName.IE)]
        [DataRow(BrowserName.Edge)]
        [TestMethod]
        public void AddCart()
        {
            Page.homePage.Navigate();
            Page.homePage.SearchBox.Click();
            Page.homePageHelper.SearchItem("Milk");
        }

    }
}
