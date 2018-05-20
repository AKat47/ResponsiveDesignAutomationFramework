using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Builder.Driver
{
    public class MobileWrapper  : DriverWrapper, WebDriver,MobileDriver
    {
        private readonly AndroidDriver<IWebElement> _appiumDriver;
        public MobileWrapper(AndroidDriver<IWebElement> driver)
        {
            _appiumDriver = driver;
        }

        public new AndroidDriver<IWebElement> androidDriver
        {
            get
            {
                return _appiumDriver;
            }
        }

        public string Context
        {
            get
            {
                return _appiumDriver.Context;
            }
            set
            {
                _appiumDriver.Context = value;
            }
        }

        public new string Url
        {
            get
            {
                return _appiumDriver.Url;
            }
        }

        public new void Navigate(Uri url)
        {
            _appiumDriver.Navigate().GoToUrl(url);
            WaitForPageLoad();
        }

        public new void WaitForPageLoad()
        {
            WaitForDocumentReady();
            WaitForAjaxJQuery();
        }

        private new void WaitForDocumentReady()
        {
            for (int i = 0; i < 10; i++)
            {
                if (JsExecutor().ExecuteScript("return document.readyState").ToString().Equals("complete"))
                {
                    return;
                }
                Thread.Sleep(1000);
            }

            throw new Exception("Page hasnt completely loaded");
        }

        private new void WaitForAjaxJQuery()
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
        public new IJavaScriptExecutor JsExecutor()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_appiumDriver;
            return js;
        }


    }
}
