using CoreTestFramework.BaseTest;
using FunctionalTestinngCore.Utils;
using GitHubTests.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tests.GitHub.Pages;

namespace Tests.GitHub.Login
{
    [TestClass]
    public class LoginUITests : WebTest
    {
        private string imageLocation;
        private LoginPage login;

        [TestInitialize]
        public void LoginUITestInit()
        {
            // Set base image location
            this.imageLocation = Path.Combine(OSUtils.ProjectDirectory, "Images");

            // Set standart HD resolution
            context.Browser.SetResolution(new System.Drawing.Size(1366, 768));

            // Navigate to login page
            this.login = new LoginPage(context).Navigate();
        }

        [TestMethod]
        public void LoginFormShouldLooksOK()
        {
            // Set expected image path
            var expectedImageName = String.Format("login_form_hd_{0}.png", context.Settings.BrowserType.ToString());
            var expectedImagePath = Path.Combine(this.imageLocation, expectedImageName);

            // Ensure login form looks OK
            context.Browser.ElementMatch(element:this.login.LoginForm, path: expectedImagePath, timeout: context.Settings.Timeout);
        }

        [TestMethod]
        public void LoginPageShouldLooksOK()
        {
            // Set expected image path
            var expectedImageName = String.Format("login_page_hd_{0}.png", context.Settings.BrowserType.ToString());
            var expectedImagePath = Path.Combine(this.imageLocation, expectedImageName);

            // Ensure entire login page looks OK
            context.Browser.ScreenMatch(path: expectedImagePath, timeout: context.Settings.Timeout);
        }
    }
}
