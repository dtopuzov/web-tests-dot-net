using RestSharp;
using System;
using static GitHubTests.API.Contracts;

namespace GitHubTests.API
{
    class IssuesAPI
    {
        private string baseUrl = "https://api.github.com";
        private RestClient client;

        public IssuesAPI()
        {
            client = new RestClient();
            client.BaseUrl = new Uri(this.baseUrl);
            client.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
        }

        public IssueDetails GetIssueDetails(string organization, string repository, int issueNumber)
        {
            var uri = string.Format("repos/{0}/{1}/issues/{2}", organization, repository, issueNumber.ToString());
            var request = new RestRequest(uri, Method.GET);
            return this.client.Execute<IssueDetails>(request).Data;
        }
    }
}
