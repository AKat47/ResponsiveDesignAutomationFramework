using Entities.Pages.Redmart;

namespace Entities.Helper
{
    public class HomePageHelper
    {
        protected PageNavigation R;

        public HomePageHelper(PageNavigation page)
        {
            this.R = page;
        }
        public void NavigateTo(string page)
        {
            R.homePage.Navigate();
            R.homePage.SideLinks.Click();
            R.homePage.SelectMenu("Frozen").Click();
        }

        public void SelectItem(string itemName)
        {
            R.homePage.Item(itemName).Click();
        }
    }
}
