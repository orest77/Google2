using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TheBestProject.Tools.SearchWebElements
{
    class SearchExplicit : ASearch
    {
        public SearchExplicit()
        {
            ResetWaits();
        }

        public override void ResetWaits()
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(Application.Get().ApplicationSource.GetExplicitTimeOut());
        }

        public static Func<IWebDriver, bool> StalenessOf(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    // Calling any method forces a staleness check
                    return element == null || !element.Enabled || !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public override bool StalenessOfWebElement(IWebElement webElement)
        {
            return new WebDriverWait(Application.Get().Browser.Driver,
                    TimeSpan.FromSeconds(Application.Get().ApplicationSource.GetExplicitTimeOut()))
                    .Until(StalenessOf(webElement));
        }

        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return true;
                }
            };
        }

        public override bool InvisibilityOfWebElementLocated(By by)
        {
            return new WebDriverWait(Application.Get().Browser.Driver,
                    TimeSpan.FromSeconds(Application.Get().ApplicationSource.GetExplicitTimeOut()))
                    .Until(InvisibilityOfElementLocated(by));
        }

        public override IWebElement GetWebElement(By by)
        {
            return new WebDriverWait(Application.Get().Browser.Driver,
                    TimeSpan.FromSeconds(Application.Get().ApplicationSource.GetExplicitTimeOut()))
                    .Until(driver => driver.FindElement(by));
        }

        public static Func<IWebDriver, IList<IWebElement>> VisibilityOfAllElementsLocatedBy(By by)
        {
            return (driver) =>
            {
                try
                {
                    var elements = driver.FindElements(by);
                    if (elements.Any(element => !element.Displayed))
                    {
                        return null;
                    }

                    return elements.Any() ? elements : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public override IList<IWebElement> GetWebElements(By by)
        {
            return new WebDriverWait(Application.Get().Browser.Driver,
                    TimeSpan.FromSeconds(Application.Get().ApplicationSource.GetExplicitTimeOut()))
                    .Until(VisibilityOfAllElementsLocatedBy(by));
        }
    }
}
