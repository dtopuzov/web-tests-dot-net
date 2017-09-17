using CoreTestFramework.BaseTest;
using GitHubTests.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.GitHub.Pages;

namespace GitHubTests.Tests.Issues
{
    [TestClass]
    public class IssuesSmokeTests : WebTest
    {
        [TestMethod()]
        public void IssueDetails()
        {
            // Get issue details via REST API
            var issuesAPI = new IssuesAPI();
            var details = issuesAPI.GetIssueDetails(organization: "NativeScript", repository: "NativeScript", issueNumber: 10);

            // Get title via ui
            context.Browser.NavigateTo(@"https://github.com/NativeScript/NativeScript/issues/10");
            var issuesPage = new IssueDetailsPage(context);
            var title = issuesPage.Title.Text;

            // Compare API and UI data:
            Assert.AreEqual(details.title, title, "Title in UI does not match title in API!");
        }

    }
}
