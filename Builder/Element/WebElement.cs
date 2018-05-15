using System;
using Builder.Driver;
using OpenQA.Selenium;

namespace Builder
{
    public class WebElement : BaseElement,IElement
    {
          
        public WebElement(WebDriver driver,By elementLocator)
            : base(driver, elementLocator)
        {
        }
       
        public void Click()
        {
            WrappedElement.Click();
            _driver.WaitForPageLoad();
        }



    }
}
