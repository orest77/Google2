using System.Collections.Generic;
using OpenQA.Selenium;

namespace TheBestProject.Tools.SearchWebElements
{
    public class SearchElement : ISearchStrategy
    {
        public ASearch Search { get; private set; }

        public SearchElement()
        {
            InitSearch();
        }

        private void InitSearch()
        {
            Search = new SearchImplicit();
        }

        public void SetStrategy(ASearch search)
        {
            Search = search;
        }

        public void SetImplicitStrategy()
        {
            SetStrategy(new SearchImplicit());
        }

        public void SetExplicitStrategy()
        {
            SetStrategy(new SearchExplicit());
        }

        // Implemented Interface ISearch
        public bool InvisibilityOfWebElementLocated(By by)
        {
            return Search.InvisibilityOfWebElementLocated(by);
        }

        public bool StalenessOfWebElement(IWebElement webElement)
        {
            return Search.StalenessOfWebElement(webElement);
        }

        // Search Element
        public IWebElement ElementByClassName(string className)
        {
            return Search.ElementByClassName(className);
        }

        public IWebElement ElementByCssSelector(string cssSelector)
        {
            return Search.ElementByCssSelector(cssSelector);
        }

        public IWebElement ElementById(string id)
        {
            return Search.ElementById(id);
        }

        public IWebElement ElementByLinkText(string linkText)
        {
            return Search.ElementByLinkText(linkText);
        }

        public IWebElement ElementByName(string name)
        {
            return Search.ElementByName(name);
        }

        public IWebElement ElementByPartialLinkText(string partialLinkText)
        {
            return Search.ElementByPartialLinkText(partialLinkText);
        }

        public IWebElement ElementByTagName(string tagName)
        {
            return Search.ElementByTagName(tagName);
        }

        public IWebElement ElementByXPath(string xpath)
        {
            return Search.ElementByXPath(xpath);
        }

        public IList<IWebElement> ElementsByClassName(string className)
        {
            return Search.ElementsByClassName(className);
        }

        public IList<IWebElement> ElementsByCssSelector(string cssSelector)
        {
            return Search.ElementsByCssSelector(cssSelector);
        }

        public IList<IWebElement> ElementsByLinkText(string linkText)
        {
            return Search.ElementsByLinkText(linkText);
        }

        public IList<IWebElement> ElementsByName(string name)
        {
            return Search.ElementsByName(name);
        }

        public IList<IWebElement> ElementsByPartialLinkText(string partialLinkText)
        {
            return Search.ElementsByPartialLinkText(partialLinkText);
        }

        public IList<IWebElement> ElementsByTagName(string tagName)
        {
            return Search.ElementsByTagName(tagName);
        }

        public IList<IWebElement> ElementsByXPath(string xpath)
        {
            return Search.ElementsByXPath(xpath);
        }              
    }
}
