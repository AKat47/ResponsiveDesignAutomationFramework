using Harness;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;

namespace Builder.Driver
{

    public static class Browser
    {
        public const string Chrome = "chrome";
        public const string Firefox = "Firefox";
        public const string IE = "IE";
        public const string Safari = "Safari";
        public const string Edge = "Edge";
    }


    public sealed class DriverManager
    {
        [ThreadStatic]
        private static DriverManager instance = null;

        private WebDriver driver = null;

        private AndroidDriver<IWebElement> androidDriver = null;

        private string browserName
        {
            get
            {
                return Configurations.browserName;
            }
        }
        
        private DriverManager()
        {
            var mode = Mode;

            if(String.IsNullOrEmpty(Configurations.deviceName) && String.IsNullOrEmpty(Configurations.browserName))
            {
                throw new Exception("Both deviceName & browserName setting are empty");
            }

            if(Configurations.realDevice)
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();

                capabilities.SetCapability("Platform", PlatformType.Android);
                capabilities.SetCapability("deviceName", "HT71S1600359");
                capabilities.SetCapability(MobileCapabilityType.BrowserName, "Chrome");
                driver = new MobileWrapper(new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"),capabilities));
                driver.Context = "CHROMIUM";
            }
            else if (browserName == Browser.Chrome)
            {
                if (String.IsNullOrEmpty(Configurations.deviceName))
                {
                    driver = new DriverWrapper(new ChromeDriver());
                    driver.NativeDriver.Manage().Window.Maximize();
                }
                else
                {
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("no-sandbox");
                    chromeOptions.EnableMobileEmulation(Configurations.deviceName);
                    driver = new DriverWrapper(new ChromeDriver(chromeOptions));
                }
            }
            else if(browserName == Browser.IE)
            {
                driver = new DriverWrapper(new InternetExplorerDriver());
            }
            else if(browserName == Browser.Firefox)
            {
                driver = new DriverWrapper(new FirefoxDriver());
            }
            else if(browserName == Browser.Edge)
            {
                driver = new DriverWrapper(new EdgeDriver());
            }

        }

        public static WebDriver Instance
        {
            get
            {
                if (instance != null) return instance.driver;
                instance = new DriverManager();
                return instance.driver;
            }
        }

        public static void SwitchWindow()
        {
            string currentHandle = Instance.NativeDriver.CurrentWindowHandle;
            Instance.WebDriverWait(TimeoutSettings.GlobalWait).Until((e) =>
            {
                return Instance.NativeDriver.WindowHandles.Count > 1;
            });

            Instance.NativeDriver.SwitchTo().Window(Instance.NativeDriver.WindowHandles.Last(x => x != currentHandle));

        }

        public static void Reset()
        {
            instance.driver = null;
            instance = null;
        }

        public sealed class DeviceMode : ReferenceTypeEnumBase<string>
        {
            private DeviceMode(string value)
                : base(value)
            {
            }

            public static DeviceMode Desktop = new DeviceMode("Desktop");
            public static DeviceMode Mobile = new DeviceMode("Mobile");
            public static DeviceMode Tablet = new DeviceMode("Tablet");
        }

        public static DeviceMode Mode
        {
            get
            {
                string[] mobileList = new string[] { "iPhone 6" };
                string[] tabletList = new string[] { "iPad Pro" };

                var deviceName = Configurations.deviceName;

                if (String.IsNullOrEmpty(deviceName))
                    return DeviceMode.Desktop;
                else if (tabletList.Any(e => e.Equals(Configurations.deviceName, StringComparison.InvariantCultureIgnoreCase)))
                    return DeviceMode.Tablet;
                else if (mobileList.Any(e => e.Equals(Configurations.deviceName, StringComparison.InvariantCultureIgnoreCase)))
                    return DeviceMode.Mobile;
                else
                    throw new Exception(string.Format("Invalid deviceName:{0} specified",deviceName));

            }
        }
    }
}


    
