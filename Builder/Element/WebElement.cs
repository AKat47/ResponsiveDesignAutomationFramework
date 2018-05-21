using System;
using Builder.Driver;
using OpenQA.Selenium;

namespace Builder.Element
{
    public class WebElement : BaseElement,IElement
    {
          
        public WebElement(WebDriver driver,By elementLocator)
            : base(driver, elementLocator)
        {
        }

        public WebElement(WebDriver driver, By elementLocator,IWebElement element)
            : base(driver, elementLocator,element)
        {
        }

        public void Click()
        {
            WrappedElement.Click();
            _driver.WaitForPageLoad();
        }
        
        public void ClearandSend(string value)
        {
            WrappedElement.Clear();
            _driver.WaitForPageLoad();
            WrappedElement.SendKeys(value);
            _driver.WaitForPageLoad();
        }


    }
}
