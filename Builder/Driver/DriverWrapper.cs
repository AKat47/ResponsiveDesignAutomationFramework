using System;
using System.Collections.Generic;
using System.Threading;
using Builder.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Builder
{
    public sealed class DriverWrapper : WebDriver
    {
        private IWebDriver WebDriver;

        private string browserName;

        public DriverWrapper(IWebDriver chromeDriver)
        {
            this.WebDriver = chromeDriver;
        }

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
            set
            {
                NativeDriver = new ChromeDriver();
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
                if(JsExecutor.ExecuteScript("return document.readyState").ToString().Equals("complete"))
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
                    if ((bool)JsExecutor.ExecuteScript("return jQuery.active == 0;")) return;

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

        public IJavaScriptExecutor JsExecutor
        {
            get
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)NativeDriver;
                return js;
            }
        }

        public WebElement FindElement(By elementLocator)
        {
            var element = NativeDriver.FindElements(elementLocator);
            if (element.Count > 0)
                return new WebElement(this,elementLocator);
            else
                throw new Exception(string.Format("Element not found : {0}", elementLocator));

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
    }
}