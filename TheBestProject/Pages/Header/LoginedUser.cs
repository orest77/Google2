using OpenQA.Selenium;

namespace TheBestProject.Pages.Header
{
    public class LoginedUser : TopBar
    {
        protected IWebElement AccountButton => Search.ElementByXPath("(//div[@class='gb_Va']/..)[2]");      

        public void ClickAccountButton()
        {
            AccountButton.Click();
        }
    }
}
