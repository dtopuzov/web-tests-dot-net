using CoreTestFramework.Selenium;
using CoreTestFramework.Settings;
using FunctionalTestinngCore.Utils;
using System.Drawing;
using System.IO;

namespace FunctionalTestinngCore.Settings
{
    public class WebSettings
    {
        public BrowserType BrowserType { get; set; }
        public Size BrowserSize { get; set; }
        public string BaseUrl { get; set; }
        public short Timeout { get; set; }
        public short PageLoadTimeout { get; set; }
        public string TestResultsFolder { get; set; }

        public WebSettings()
        {
            this.BrowserType = ConfigurationHelper.Get<BrowserType>("BrowserType");
            var sizeString = ConfigurationHelper.Get<string>("BrowserSize");
            this.BrowserSize = new Size(int.Parse(sizeString.Split('x')[0]), int.Parse(sizeString.Split('x')[1]));
            this.BaseUrl = ConfigurationHelper.Get<string>("BaseUrl");
            this.Timeout = ConfigurationHelper.Get<short>("Timeout");
            this.PageLoadTimeout = ConfigurationHelper.Get<short>("PageLoadTimeout");
            this.TestResultsFolder = Path.Combine(OSUtils.SolutionDirectory, "TestResults");
        }
    }
}
