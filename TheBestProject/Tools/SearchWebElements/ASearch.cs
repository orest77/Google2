using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace TheBestProject.Tools.SearchWebElements
{
    public abstract class ASearch : ISearch
    {
        public const long WITHOUT_MILLISECONDS = 10000000;
        public const int TIME_SLEEP_MILLISECONDS = 500;
        private const string NO_SUCH_ELEMENT = "Unable to locate element";
        private const string NO_SUCH_ELEMENT_LIST = "Unable to locate element(s)";

        //Time Stamp
        protected long GetSecondStamp()
        {
            return DateTime.Now.ToFileTime() / WITHOUT_MILLISECONDS;
        }

        //Abstract Methods 
        public abstract IWebElement GetWebElement(By by);
        public abstract IList<IWebElement> GetWebElements(By by);

        public abstract bool StalenessOfWebElement(IWebElement webElement);
        public abstract bool InvisibilityOfWebElementLocated(By by);

        public abstract void ResetWaits();

        private IWebElement SearchWebElement(By by)
        {
            try
            {
                return GetWebElement(by);
            }
            catch (Exception)
            {
                throw new Exception(NO_SUCH_ELEMENT);
            }
        }

        private IList<IWebElement> SearchWebElements(By by)
        {
            try
            {
                return GetWebElements(by);
            }
            catch (Exception)
            {
                throw new Exception(NO_SUCH_ELEMENT_LIST);
            }
        }

        public IWebElement ElementByClassName(string className)
        {
            return SearchWebElement(By.ClassName(className));
        }

        public IWebElement ElementByCssSelector(string cssSelector)
        {
            return SearchWebElement(By.CssSelector(cssSelector));
        }

        public IWebElement ElementById(string id)
        {
            return SearchWebElement(By.Id(id));
        }

        public IWebElement ElementByLinkText(string linkText)
        {
            return SearchWebElement(By.LinkText(linkText));
        }

        public IWebElement ElementByName(string name)
        {
            return SearchWebElement(By.Name(name));
        }

        public IWebElement ElementByPartialLinkText(string partialLinkText)
        {
            return SearchWebElement(By.PartialLinkText(partialLinkText));
        }

        public IWebElement ElementByTagName(string tagName)
        {
            return SearchWebElement(By.TagName(tagName));
        }

        public IWebElement ElementByXPath(string xpath)
        {
            return SearchWebElement(By.XPath(xpath));
        }

        public IList<IWebElement> ElementsByClassName(string className)
        {
            return SearchWebElements(By.ClassName(className));
        }

        public IList<IWebElement> ElementsByCssSelector(string cssSelector)
        {
            return SearchWebElements(By.CssSelector(cssSelector));
        }

        public IList<IWebElement> ElementsByLinkText(string linkText)
        {
            return SearchWebElements(By.LinkText(linkText));
        }

        public IList<IWebElement> ElementsByName(string name)
        {
            return SearchWebElements(By.Name(name));
        }

        public IList<IWebElement> ElementsByPartialLinkText(string partialLinkText)
        {
            return SearchWebElements(By.PartialLinkText(partialLinkText));
        }

        public IList<IWebElement> ElementsByTagName(string tagName)
        {
            return SearchWebElements(By.TagName(tagName));
        }

        public IList<IWebElement> ElementsByXPath(string xpath)
        {
            return SearchWebElements(By.XPath(xpath));
        }        
    }
}
