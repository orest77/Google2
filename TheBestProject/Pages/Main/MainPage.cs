using OpenQA.Selenium;
using System.Threading;
using TheBestProject.Pages.SearchPages;
using TheBestProject.Tools;
using TheBestProject.Tools.SearchWebElements;

namespace TheBestProject.Pages.Main
{
    public class MainPage
    {
        protected ISearch Search => Application.Get().Search;

        protected IWebElement ImageGoogle => Search.ElementByXPath("//div[@id='lga']/img");

        protected IWebElement SearchBox => Search.ElementByName("q");

        protected IWebElement SearchGoogleButton => Search.ElementByName("btnK");

        protected IWebElement FeelingLuckyButton => Search.ElementByXPath("(//center/input[@name='btnI'])[2]");

        protected IWebElement ChangeLanguageLink => Search.ElementByCssSelector("#SIvCob a");

        //Methods for title google image
        public bool IsDisplayedImage()
        {
            return ImageGoogle.Displayed;
        }

        //Methods for Search Box
        public void ClickOnSearchBox()
        {
            SearchBox.Click();
        }

        public void ClearSearchBox()
        {
            SearchBox.Clear();
        }

        public void EnterSearchBox(string someText)
        {
            SearchBox.SendKeys(someText);
        }

        //Methods for Search Google Button
        public string GetTextSearchGoogleButton()
        {
            return SearchGoogleButton.Text;
        }

        public void ClickSearchGoogleButton()
        {
            SearchGoogleButton.Click();
        }

        //Methods for Feeling Lucky Button
        public string GetTextFeelingLuckyButton()
        {
            return SearchGoogleButton.Text;
        }

        public void ClickFeelingLuckyButton()
        {
            SearchGoogleButton.Click();
        }

        // Logic method
        public MainPage ClearClickEnterSearchBox(string someText)
        {
            ClickOnSearchBox();
            ClearSearchBox();
            EnterSearchBox(someText);
            return this;
        }

        public SearchPage SetSearchBoxAndClickButton(string someText)
        {
            ClearClickEnterSearchBox(someText);
            ClickSearchGoogleButton();
            return new SearchPage();
        }
    }
}
