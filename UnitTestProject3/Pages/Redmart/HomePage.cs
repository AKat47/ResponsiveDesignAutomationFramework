using System;
using System.Collections.Generic;
using Builder;
using Builder.DriverManager;
using OpenQA.Selenium;

namespace Entities
{
    public class HomePage : PageBase
    {
        public HomePage()
        {
            PartialUrls.Add("{0}");
        }

        public WebElement SideLinks
        {
            get
            {
                return DriverManager.Instance.FindElement(By.Id("megaMenu"),
                    new List<By>
                    {
                        By.XPath("//div[contains(@class,'header_left')]")
                    });
            }
        }

        public WebElement SelectMenu(string menuName)
        {
            var locator = string.Format("//section[@id='megaMenu']//a[text()='{0}']", menuName);
            var mobilelocator = string.Format("//section//a[text()='{0}']", menuName);
            return DriverManager.Instance.FindElement(By.XPath(locator),
                new List<By>
                {
                    By.XPath(mobilelocator)
                });
        }

        public WebElement Item(string itemName)
        {
            return DriverManager.Instance.FindElement
                (By.XPath("//a[span/h2[text()='Magnum Store']]"),
                new List<By>
                {
                    By.XPath("//section//div/a[text()='Magnum Store']")
                });
        }
    }
}