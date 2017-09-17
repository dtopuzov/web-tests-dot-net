using CoreTestFramework.BaseTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.GitHub.Pages;

namespace Tests.GitHub.Login
{
    [TestClass]
    public class LoginTests : WebTest
    {
        private string expectedErrorOnLoginFail = "Incorrect username or password.";
        private LoginPage login;

        [TestInitialize]
        public void LoginTestInit()
        {
            login = new LoginPage(context).Navigate();
        }

        [TestMethod]
        public void LoginWithInvalidUser()
        {
            login.Login("fake@user.com", "fakePass");
            var actualError = login.GetErrorMessage();
            Assert.AreEqual(expectedErrorOnLoginFail, actualError, "Error massge is not correct!");
        }

        [TestMethod]
        public void LoginWithValidUserAndIvnalidPassword()
        {
            login.Login("dtopuzov@gmail.com", "fakePass");
            var actualError = login.GetErrorMessage();
            Assert.AreEqual(expectedErrorOnLoginFail, actualError, "Error massge is not correct!");
        }
    }
}
