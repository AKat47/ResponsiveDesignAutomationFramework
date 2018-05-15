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
            var element = DriverManager.Instance.FindElement(By.XPath("//div[contains(@class,'header_left')]"));
            DriverManager.Instance.JsExecutor().ExecuteScript("arguments[0].click();", element.WrappedElement);
            Page.homePageHelper.NavigateTo("Frozen");
            Page.homePageHelper.SelectItem("Magnum");
        }






    }
}
