using Builder;
using Builder.Driver;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace Builder
{
    public class BaseElement : IBaseElement
    {
        protected readonly WebDriver _driver;

        public By ElementLocator { get; set; }

        protected IWebElement _wrappedElement = null;

        public BaseElement(WebDriver driver,IBaseElement element)
    : this(DriverManager.DriverManager.Instance, element.ElementLocator, element.WrappedElement)
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
                    var element = _driver.NativeDriver.FindElements(ElementLocator);
                    if (element.Count > 0)
                        return element.FirstOrDefault(e => e.Displayed);
                    else
                        throw new Exception(string.Format("Element of Locator : {0}", ElementLocator));
                }
                else
                {
                    return _wrappedElement;
                }
            }
        }


    }
    }
