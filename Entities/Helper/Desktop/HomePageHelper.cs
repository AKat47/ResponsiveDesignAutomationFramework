using System;
using Entities.Pages.Amazon;
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

        public void AddToCart(string productName,string itemName)
        {
            R.homePage.SearchBox.Click();
            SearchItem(productName);
            R.homePage.ResultItem(itemName).Click();
            R.homePage.AddToCartButton.Click();
        }
    }
}
