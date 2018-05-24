using Entities.Pages.Amazon;

namespace Entities
{
    public class UIAutomation
    {
        private PageNavigation _page;

        private UIAutomation()
        {
            _page = new PageNavigation();

        }

        private static UIAutomation Instance
        {
            get
            {
                return new UIAutomation();
            }
        }
        

        public static PageNavigation Page
        {
            get { return Instance._page; }
        }
    }
}
