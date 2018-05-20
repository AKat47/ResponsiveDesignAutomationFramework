using Builder;
using Builder.Driver;
using Harness;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace Builder.Element
{
    public class BaseElement : IBaseElement
    {
        protected readonly WebDriver _driver;

        public By ElementLocator { get; set; }

        protected IWebElement _wrappedElement = null;

        public BaseElement(WebDriver driver,IBaseElement element)
    : this(DriverManager.Instance, element.ElementLocator, element.WrappedElement)
        {
        }

        public BaseElement(WebDriver driver, By elementLocator)
            : this(driver, elementLocator, null)
        {
        }

        public BaseElement(WebDriver driver, By elementLocator, IWebElement element)
        {
            _driver = driver;
            ElementLocator = elementLocator;
            _wrappedElement = element;
        }

        public IWebElement WrappedElement
        {
            get
            {
                if (_wrappedElement == null)
                {
                    if (Configurations.realDevice)
                    {
                        var element = _driver.androidDriver.FindElements(ElementLocator);
                        if (element.Count > 0)
                            return element.FirstOrDefault(e => e.Displayed);
                        else
                            throw new Exception(string.Format("Element of Locator : {0} not found", ElementLocator));

                    }
                    else
                    {
                        var element = _driver.NativeDriver.FindElements(ElementLocator);
                        if (element.Count > 0)
                            return element.FirstOrDefault(e => e.Displayed);
                        else
                            throw new Exception(string.Format("Element of Locator : {0} not found", ElementLocator));
                    }
                }
                else
                {
                    return _wrappedElement;
                }
            }
        }

        public string Text
        {
            get
            {
                return string.IsNullOrEmpty(_wrappedElement.Text)? "" : _wrappedElement.Text ;
            }
        }

        public bool Displayed
        {
            get
            {
                try
                {
                    return _wrappedElement.Displayed;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }

    }
    }
