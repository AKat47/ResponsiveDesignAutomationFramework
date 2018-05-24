using System.Collections.Generic;

using OpenQA.Selenium;
using Builder.Element;
using Builder.Driver;

namespace Entities.Pages.Amazon
{
    public class HomePage : PageBase
    {
        public HomePage()
        {
            PartialUrls.Add("{0}");
        }
        
        public WebElement SearchBox
        {
            get
            {
                return DriverManager.Instance.FindElement(By.Id("nav-search-keywords"),
                    new List<By> { By.XPath("//div[contains(@class,'nav-search-field')]/input")  });
            }
        }

        public WebElement CartButton
        {
            get
            {
                return DriverManager.Instance.FindElement(By.Id("nav-cart"),
                    new List<By> { By.XPath("//div[contains(@class,'nav-cart')]/i") });
            }
        }

        public WebElement ResultItem(string itemName)
        {
            return DriverManager.Instance.FindElement(By.XPath(string.Format("//ul[contains(@id,'s-results')]/li//a/h2[contains(text(),'{0}')]", itemName)),
                new List<By> { By.XPath(string.Format("//ul[contains(@id,'resultItems')]/li//*[contains(text(),'{0}')]", itemName))
                });
        }

        public WebElement AddToCartButton
        {
            get
            {
                return DriverManager.Instance.FindElement(By.Id("add-to-wishlist-button-submit"));
            }
        }


    }
}