using Microsoft.VisualStudio.TestTools.UnitTesting;
using Harness.ReadSettings;
using Builder.DriverManager;
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
            Page.homePage.SideLinks.Click();
            Page.homePage.SelectMenu("Frozen").Click();
        }






    }
}
