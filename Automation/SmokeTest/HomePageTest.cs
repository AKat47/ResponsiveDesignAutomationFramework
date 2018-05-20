using Builder.Driver;
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
            Page.homePage.SearchBox.Click();
            Page.homePageHelper.SearchItem("Milk");
        }

    }
}
