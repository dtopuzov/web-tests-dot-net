using CoreTestFramework.Settings;
using FunctionalTestinngCore.Utils;
using System.IO;

namespace FunctionalTestinngCore.Settings
{
    public class RestSettings
    {
        public string BaseUrl { get; set; }
        public short Timeout { get; set; }
        public string TestResultsFolder { get; set; }

        public RestSettings()
        {
            this.BaseUrl = ConfigurationHelper.Get<string>("BaseUrl");
            this.Timeout = ConfigurationHelper.Get<short>("Timeout");
            this.TestResultsFolder = Path.Combine(OSUtils.SolutionDirectory, "TestResults");
        }
    }
}
