using OpenQA.Selenium;
using TheBestProject.Tools;
using TheBestProject.Tools.SearchWebElements;

namespace TheBestProject.Pages.Header
{
    public abstract class TopBar
    {
        public ISearch Search => Application.Get().Search;

        protected IWebElement GmailButton => Search.ElementByXPath("(//a[@data-pid='23'])[1]");

        protected IWebElement ImagesButton => Search.ElementByXPath("(//a[@data-pid='2'])[1]");

        protected IWebElement AppButton => Search.ElementByCssSelector(".gb_Kf");      

    }
}
