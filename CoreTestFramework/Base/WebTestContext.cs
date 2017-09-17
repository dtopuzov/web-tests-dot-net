using FunctionalTestinngCore.Selenium;
using FunctionalTestinngCore.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace FunctionalTestinngCore.Base
{
    public class WebTestContext
    {
        public TestContext TestContext { get; set; }
        public WebSettings Settings { get; set; }
        public IWebDriver Driver { get; set; }
        public Browser Browser { get; set; }

        public WebTestContext(WebSettings settings, IWebDriver driver, Browser browser)
        {
            this.Settings = settings;
            this.Driver = driver;
            this.Browser = browser;
        }
    }
}
