using OpenQA.Selenium;

namespace Builder
{
    public interface IBaseElement
    {

        By ElementLocator { get; }

        IWebElement WrappedElement { get; }

    }
}