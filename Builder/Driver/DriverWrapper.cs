using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Builder.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Builder.Element;
using Harness;
using System.IO;
using OpenQA.Selenium.Appium.Android;

namespace Builder.Driver
{
    public class DriverWrapper : WebDriver
    {
        private IWebDriver WebDriver;

        private AndroidDriver<IWebElement> appiumDriver = null;

        private string browserName;

        public DriverWrapper(IWebDriver chromeDriver)
        {
            this.WebDriver = chromeDriver;
        }

        public DriverWrapper(){}

        public DriverWrapper(string browserName)
        {
            this.browserName = browserName;
        }

        public IWebDriver NativeDriver
        {
            get
            {
                return WebDriver;
            }

        }

        public void Navigate(Uri url)
        {
            WebDriver.Navigate().GoToUrl(url);
            WaitForPageLoad();
        }

        public void WaitForPageLoad()
        {
            WaitForDocumentReady();
            WaitForAjaxJQuery();
        }

        private void WaitForDocumentReady()
        {
            for(int i=0;i<10;i++)
            {
                if(JsExecutor().ExecuteScript("return document.readyState").ToString().Equals("complete"))
                {
                    return;
                }
                Thread.Sleep(1000);
            }

            throw new Exception("Page hasnt completely loaded");
        }

        private void WaitForAjaxJQuery()
        {
            try
            {
                for (int i = 0; i < 25; i++)
                {
                    if ((bool)JsExecutor().ExecuteScript("return jQuery.active == 0;")) return;

                    Thread.Sleep(1000);
                }
            }
            catch
            {
                return;
            }
            throw new Exception(string.Format("Timed Out: jQuery still in progress after {0} seconds", 25));
        }

        public void Screenshot()
        {
            throw new NotImplementedException();
        }



        public WebDriverWait WebDriverWait(TimeSpan waitTime)
        {
            return WebDriverWait(waitTime);
        }

        public void SwitchToFrame(By elementlocator)
        {
            var element = NativeDriver.FindElement(elementlocator);
            NativeDriver.SwitchTo().Frame(element);
        }

        public string Url
        {
            get
            {
                return WebDriver.Url;
            }
        }

        public string TestName
        {
            get
            {
                return "Demo";
            }
        }

        AndroidDriver<IWebElement> WebDriver.androidDriver => throw new NotImplementedException();

        public string Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IJavaScriptExecutor JsExecutor()
        {
                IJavaScriptExecutor js = (IJavaScriptExecutor)NativeDriver;
                return js;            
        }

        public void TakeFailureScreenshot()
        {
            if (String.IsNullOrEmpty(TestName))
            {
                TakeScreenshot("Not called with a valid Test Context" + DateTime.Now.ToString("_HH_mm_ss"), ScreenshotType.Failure);

                return;
            }

            TakeScreenshot(TestName, ScreenshotType.Failure);
        }

        private void TakeScreenshot(string fileName, ScreenshotType screenshotType)
        {
            if ((screenshotType == ScreenshotType.Information) && (Configurations.screenShotLocation == null)) return;

            string screenshotLocation = Configurations.screenShotLocation;

            if (!Directory.Exists(screenshotLocation))
            {
                try
                {
                    Directory.CreateDirectory(screenshotLocation);
                }
                // Ignore the following cases:
                catch (IOException) { /* The directory specified by path is a file .-or-The network name is not known. */ }
                catch (UnauthorizedAccessException) { /* The caller does not have the required permission. */ }
            }

            try
            {
                ((ITakesScreenshot)(NativeDriver))
                    .GetScreenshot()
                    .SaveAsFile(screenshotLocation + "\\" + fileName + screenshotType.Value + ".png", ScreenshotImageFormat.Bmp);
            }
            catch (Exception) { /* The test will not fail if saving the screenshot is not successful. */ }
        }


        public WebElement FindElement(By elementLocator)
        {
            try
            {
                var element = NativeDriver.FindElements(elementLocator);
                if (element.Count > 0)
                    return new WebElement(this, elementLocator);
                else
                    throw new Exception(string.Format("Element not found : {0}", elementLocator));
            }
            catch(Exception)
            {
                throw new Exception(string.Format("Element not found : {0}", elementLocator));
            }
        }

        public IList<WebElement> FindElements(By elementLocator)
        {
            IList<WebElement> WebElements = null;
            var elements = NativeDriver.FindElements(elementLocator);
            
            if (elements.Count > 0)
            {
                foreach(IWebElement element in elements)
                {
                    var obj = new WebElement(this,elementLocator);
                    WebElements.Add(obj);
                }
                return WebElements;
            }
            else
                throw new Exception(string.Format("Element not found : {0}", elementLocator));
        }

        protected IList<WebElement> GetCustomElements(By locator) 
        {
            List<WebElement> result = new List<WebElement>();

            NativeDriver.FindElements(locator).ToList().ForEach(e => result.Add(new WebElement(this, locator,e)));

            return result;
        }

        public IList<WebElement> FindElements(IEnumerable<By> locatorList) 
        {
            WaitForPageLoad();

            List<WebElement> result = new List<WebElement>();

            locatorList.ToList().ForEach(e => result.AddRange(GetCustomElements(e)));

            return result;
        }

        public WebElement FindElement(By primaryLocator, IList<By> secondaryLocatorList) 
        {
            List<By> locators = new List<By>();

            if (primaryLocator != null) locators.Add(primaryLocator);

            if (secondaryLocatorList != null) locators.AddRange(secondaryLocatorList);

            try
            {
                var element = FindElements(locators).FirstOrDefault(e => e.Displayed);

                if (element != null) return element;
            }
            catch (Exception) { }

            return (new WebElement(this, primaryLocator));
        }

        public sealed class ScreenshotType : ReferenceTypeEnumBase<string>
        {
            private ScreenshotType(string value)
                : base(value)
            {
            }

            public static ScreenshotType Failure = new ScreenshotType("_FAIL");
            public static ScreenshotType Information = new ScreenshotType("_INFO");
        }
    }
}