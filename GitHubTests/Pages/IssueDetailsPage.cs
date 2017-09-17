using FunctionalTestinngCore.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.GitHub.Pages
{
    public class IssueDetailsPage : WebPage
    {
        [FindsBy(How = How.ClassName, Using = "js-issue-title")]
        public IWebElement Title { get; set; }

        public IssueDetailsPage(WebTestContext context) : base(context) { }

    }
}
