using Builder.Driver;
using Harness;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public abstract class PageBase
    {
        protected List<string> PartialUrls = new List<string>();

        public void Navigate()
        {
            if (IsOnExpectedPage()) return;
            DriverManager.Instance.Navigate(Urls().First());
        }

        public bool IsOnExpectedPage()
        {
            if (!Urls().Any()) return false;

            return Urls().Any(e => DriverManager.Instance.Url.StartsWith(e.ToString(), System.StringComparison.InvariantCultureIgnoreCase));

        }

        private List<Uri> Urls()
        {
            if (PartialUrls == null || !PartialUrls.Any())
            {
                throw new Exception("Url has not been set!");
            }

            List<Uri> result = new List<Uri>();

            PartialUrls.ForEach(e => result.Add(new Uri(string.Format(e.ToString(), Configurations.url))));

            return result;
        }

        public bool IsTextDisplayed(string text)
        {
           var element = DriverManager.Instance.FindElement(By.XPath("//body"));
           return element.Text.Contains(text);
        }


    }
}