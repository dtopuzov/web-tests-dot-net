using CoreTestFramework.BaseTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.GitHub.Pages;

namespace Tests.GitHub.Search
{
    [TestClass]
    public class SearchTests : WebTest
    {
        [TestMethod()]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Tests\Search\SearchTests.csv", "SearchTests#csv", DataAccessMethod.Sequential)]
        public void SimpleSearch()
        {
            // Get data from test context
            var searchTerm = Convert.ToString(this.TestContext.DataRow[0]);
            var resultLinkText = Convert.ToString(this.TestContext.DataRow[1]);

            // Search and check results
            var home = new HomePage(context);
            var results = home.SearchFor(searchTerm);
            Assert.IsTrue(results.ResultsContainsUrl(resultLinkText), "Results do not contain " + resultLinkText);
        }
    }
}
