using OpenQA.Selenium;

namespace TheBestProject.Pages.Header
{
    public interface ISingInPage
    {
    }

    public class NoLoginedsUser : TopBar, ISingInPage
    {
        protected IWebElement LoginButton => Search.ElementByClassName("#gb_70");
       
        public ISingInPage ClickLoginButton()
        {
            LoginButton.Click();
            return this;
        }

    }
}
