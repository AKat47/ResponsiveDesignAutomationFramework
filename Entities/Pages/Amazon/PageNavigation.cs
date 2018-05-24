using Builder.Driver;
using Entities.Helper;
using Entities.Helper.Desktop;
using Entities.Helper.Mobile;
using Entities.Helper.Tablet;
using static Builder.Driver.DriverManager;

namespace Entities.Pages.Amazon
{
    public class PageNavigation
    {

        public HomePage homePage;
        public HomePageHelper homePageHelper;
        public HomePageMobileHelper homePageMobileHelper;
        public HomePageTabletHelper homePageTabletHelper;

        public PageNavigation()
        {
            homePage = new HomePage();

            if (DriverManager.Mode == DeviceMode.Desktop)
                homePageHelper = new HomePageHelper(this);
            else if (DriverManager.Mode == DeviceMode.Mobile)
                homePageHelper = new HomePageMobileHelper(this);
            else
                homePageHelper = new HomePageTabletHelper(this);
        }
    }


}
