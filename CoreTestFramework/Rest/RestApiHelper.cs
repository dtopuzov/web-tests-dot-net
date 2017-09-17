using RestSharp;
using System;

namespace FunctionalTestinngCore.Rest
{
    public class RestApiHelper
    {
        private RestClient client;

        public RestApiHelper(string baseUrl)
        {
            client = new RestClient();
            client.BaseUrl = new Uri(baseUrl);
            client.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
        }
    }
}
