using CoreTestFramework.Selenium;
using FunctionalTestinngCore.Base;
using FunctionalTestinngCore.Selenium;
using FunctionalTestinngCore.Settings;
using FunctionalTestinngCore.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CoreTestFramework.BaseTest
{
    [TestClass]
    public abstract class WebTest
    {
        public TestContext TestContext { get; set; }
        protected static WebTestContext context;

        static WebTest()
        {
            var settings = new WebSettings();
            OSUtils.CreatePath(settings.TestResultsFolder);

            var driver = new DriverFactory(settings).Create();
            var browser = new Browser(driver);

            context = new WebTestContext(settings, driver, browser);

            // Register a finalizer here:
            AppDomain.CurrentDomain.DomainUnload += BaseTestCleanup;
        }

        [TestInitialize]
        public void BaseTestInit()
        {
            context.TestContext = this.TestContext;
            context.Browser.SetResolution(context.Settings.BrowserSize);
            context.Browser.NavigateTo(context.Settings.BaseUrl);
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            if (context.TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
                this.CollectTestArtefacts(context);
        }

        private static void BaseTestCleanup(object sender, EventArgs e)
        {
            try
            {
                context.Driver.Quit();
            }
            catch { }
        }

        private void CollectTestArtefacts(WebTestContext context)
        {
            try
            {
                var testName = OSUtils.NormalizePath(context.TestContext.TestName);
                var testOutDir = Path.Combine(context.Settings.TestResultsFolder, testName);

                // Save actual screenshot of browser
                var screenshotFile = testName + ".png";
                var failedScreenPath = Path.Combine(testOutDir, screenshotFile);
                context.Browser.SaveScreen(failedScreenPath);

                // Save page source as XML
                var pageSourceFile = testName + ".xml";
                var pageSourcePath = Path.Combine(testOutDir, pageSourceFile);
                File.WriteAllText(pageSourcePath, context.Driver.PageSource);
            }
            catch { }
        }
    }
}
