using Entities.Pages.Redmart;

namespace Entities.Helper
{
    public class HomePageHelper
    {
        public PageNavigation R;

        public HomePageHelper(PageNavigation page)
        {
            this.R = page;
        }
        public void NavigateTo()
        {
            R.homePage.Navigate();           
        }
    }
}
