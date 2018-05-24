using System;
using Builder.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automation
{
    [TestClass]
    public class SmokeTest : TestBase
    {
        [DataTestMethod]
        [DataRow(BrowserName.Chrome)]
        [DataRow(BrowserName.Firefox)]
        [DataRow(BrowserName.IE)]
        [DataRow(BrowserName.Edge)]        
        public void AddCart_OnBrowsers(string browserName)
        {
            InititializeConfig(browserName);
            Page.homePage.Navigate();
            Page.homePage.SearchBox.Click();
            Page.homePageHelper.SearchItem("Milk");
        }

        [DataTestMethod]
        [DataRow(BrowserName.Chrome,"iPhone 6",false)]
        public void AddCart_OnEmulators(string browserName,string deviceName,bool realDevice)
        {
            InititializeConfig(browserName,deviceName,realDevice);
            Page.homePage.Navigate();
            Page.homePage.SearchBox.Click();
            Page.homePageHelper.SearchItem("Milk");
        }

        [DataTestMethod]
        [DataRow(BrowserName.Chrome, "HT71S1632212", true)]
        public void AddCart_OnRealDevices(string browserName, string deviceName, bool realDevice)
        {
            InititializeConfig(browserName, deviceName, realDevice);
            Page.homePage.Navigate();
            Page.homePage.SearchBox.Click();
            Page.homePageHelper.SearchItem("Milk");
        }

    }
}
