using FunctionalTestinngCore.Base;
using OpenQA.Selenium;

namespace Tests.GitHub.Pages
{
    class SearchResultsPage : WebPage
    {
        public SearchResultsPage(WebTestContext context) : base(context) { }

        public bool ResultsContainsUrl(string linkText)
        {
            return this.context.Driver.FindElement(By.LinkText(linkText)).Displayed;
        }
    }
}
