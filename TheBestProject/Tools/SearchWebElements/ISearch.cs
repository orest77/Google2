using OpenQA.Selenium;
using System.Collections.Generic;

namespace TheBestProject.Tools.SearchWebElements
{
    public interface ISearch
    {
        bool StalenessOfWebElement(IWebElement webElement);
        bool InvisibilityOfWebElementLocated(By by);

        //Search Element
        IWebElement ElementById(string id);

        IWebElement ElementByName(string name);

        IWebElement ElementByXPath(string xpath);

        IWebElement ElementByCssSelector(string cssSelector);

        IWebElement ElementByClassName(string className);

        IWebElement ElementByPartialLinkText(string partialLinkText);

        IWebElement ElementByLinkText(string linkText);

        IWebElement ElementByTagName(string tagName);

        // Get List

        IList<IWebElement> ElementsByName(string name);

        IList<IWebElement> ElementsByXPath(string xpath);

        IList<IWebElement> ElementsByCssSelector(string cssSelector);

        IList<IWebElement> ElementsByClassName(string className);

        IList<IWebElement> ElementsByPartialLinkText(string partialLinkText);

        IList<IWebElement> ElementsByLinkText(string linkText);

        IList<IWebElement> ElementsByTagName(string tagName);
    }
}
