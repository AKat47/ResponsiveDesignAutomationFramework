using Entities.Pages.Redmart;
using OpenQA.Selenium;

namespace Entities.Helper.Desktop
{
    public class HomePageHelper
    {
        protected PageNavigation R;

        public HomePageHelper(PageNavigation page)
        {
            this.R = page;
        }

        public void SearchItem(string itemName)
        {
            R.homePage.SearchBox.ClearandSend(itemName + Keys.Enter);
        }
    }
}
