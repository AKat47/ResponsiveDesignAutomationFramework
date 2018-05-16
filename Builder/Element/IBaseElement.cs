using OpenQA.Selenium;

namespace Builder.Element
{
    public interface IBaseElement
    {

        By ElementLocator { get; }

        IWebElement WrappedElement { get; }

    }
}