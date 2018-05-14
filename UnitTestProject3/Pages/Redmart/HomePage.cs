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
                return DriverManager.Instance.FindElement(By.Id("megaMenu"));
            }
        }

        public WebElement SelectMenu(string menuName)
        {
            var locator = string.Format("//section[@id='megaMenu']//a[text()='{0}']", menuName);
            return DriverManager.Instance.FindElement(By.XPath(locator));
        }





    }
}