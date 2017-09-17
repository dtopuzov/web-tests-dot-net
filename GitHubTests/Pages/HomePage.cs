using FunctionalTestinngCore.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.GitHub.Pages
{
    class HomePage : WebPage
    {
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement SearchBox { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign in")]
        private IWebElement SignIn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign up")]
        private IWebElement SignUp { get; set; }

        public HomePage(WebTestContext context) : base(context) { }

        public SearchResultsPage SearchFor(string term)
        {
            this.SearchBox.SendKeys(term);
            this.SearchBox.SendKeys(Keys.Enter);
            return new SearchResultsPage(this.context);
        }
    }
}
