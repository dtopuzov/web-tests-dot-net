using FunctionalTestinngCore.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.GitHub.Pages
{
    class LoginPage : WebPage
    {
        private string _url = "login";

        [FindsBy(How = How.Id, Using = "login_field")]
        private IWebElement User { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "commit")]
        private IWebElement SignIn { get; set; }

        [FindsBy(How = How.Id, Using = "js-flash-container")]
        private IWebElement ErrorDialog { get; set; }

        [FindsBy(How = How.XPath, Using = "//form")]
        public IWebElement LoginForm { get; set; }

        public LoginPage(WebTestContext context) : base(context) { }

        public LoginPage Navigate()
        {
            this.context.Browser.NavigateTo(this.context.Settings.BaseUrl + this._url);
            return this;
        }

        public void Login(string user, string password)
        {
            this.User.SendKeys(user);
            this.Password.SendKeys(password);
            this.SignIn.Click();
        }

        public string GetErrorMessage()
        {
            try
            {
                return this.ErrorDialog.FindElement(By.ClassName("container")).Text;
            }
            catch { return null; }
        }
    }
}
