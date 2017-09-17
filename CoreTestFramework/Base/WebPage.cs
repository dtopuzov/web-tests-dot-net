using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace FunctionalTestinngCore.Base
{
    public abstract class WebPage
    {
        protected WebTestContext context;
        protected WebDriverWait wait;

        public WebPage(WebTestContext context)
        {
            this.context = context;
            this.wait = new WebDriverWait(this.context.Driver, TimeSpan.FromSeconds(this.context.Settings.Timeout));
            PageFactory.InitElements(this.context.Driver, this);
        }
    }
}
