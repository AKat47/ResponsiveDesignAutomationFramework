using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Driver
{
    public class MobileWrapper  : DriverWrapper, WebDriver
    {
        private readonly AndroidDriver<IWebElement> _appiumDriver;
        public MobileWrapper(AndroidDriver<IWebElement> driver)
            : base(driver)
        {
            _appiumDriver = driver;
        }

        public new IWebDriver NativeDriver
        {
            get
            {
                return _appiumDriver;
            }
        }

        public new string Context
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


    }
}
