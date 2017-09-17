using FunctionalTestinngCore.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace CoreTestFramework.Selenium
{
    public enum BrowserType
    {
        InternetExplorer,
        Chrome,
        Firefox
    }

    public class DriverFactory
    {
        private WebSettings _settings;
        private static readonly FirefoxProfile FirefoxProfile = CreateFirefoxProfile();

        public DriverFactory(WebSettings settings)
        {
            this._settings = settings;
        }

        public IWebDriver Create()
        {
            IWebDriver driver;
            var browserType = this._settings.BrowserType;

            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory, new InternetExplorerOptions(), TimeSpan.FromMinutes(5));
                    break;
                case BrowserType.Firefox:
                    var firefoxProfile = FirefoxProfile;
                    driver = new FirefoxDriver(firefoxProfile);
                    driver.Manage().Window.Maximize();
                    break;
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // driver.Manage().Window.Maximize();
            var timeouts = driver.Manage().Timeouts();
            timeouts.ImplicitWait = TimeSpan.FromSeconds(this._settings.Timeout);
            timeouts.PageLoad = TimeSpan.FromSeconds(this._settings.PageLoadTimeout);

            // Suppress the onbeforeunload event first. This prevents the application hanging on a dialog box that does not close.
            ((IJavaScriptExecutor)driver).ExecuteScript("window.onbeforeunload = function(e){};");
            return driver;
        }

        private static FirefoxProfile CreateFirefoxProfile()
        {
            var firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("network.automatic-ntlm-auth.trusted-uris", "http://localhost");
            return firefoxProfile;
        }
    }
}
