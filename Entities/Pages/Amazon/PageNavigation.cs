using Entities.Helper;
using Entities.Helper.Desktop;

namespace Entities.Pages.Amazon
{
    public class PageNavigation
    {

        public HomePage homePage;
        public HomePageHelper homePageHelper;

        public PageNavigation()
        {
            homePage = new HomePage();
            homePageHelper = new HomePageHelper(this);
        }
    }


}
