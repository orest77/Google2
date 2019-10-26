using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TheBestProject.Tools.SearchWebElements
{
    public class SearchImplicit : ASearch
    {
        public SearchImplicit()
        {
            ResetWaits();
        }

        public override void ResetWaits()
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait 
                = TimeSpan.FromSeconds(Application.Get().ApplicationSource.GetImplicitWaitTimeOut());
        }

        public override IWebElement GetWebElement(By by)
        {
            return Application.Get().Browser.Driver.FindElement(by);
        }

        public override IList<IWebElement> GetWebElements(By by)
        {
            return Application.Get().Browser.Driver.FindElements(by);
        }

        public override bool InvisibilityOfWebElementLocated(By by)
        {
            bool result = false;
            long startTime = GetSecondStamp();
            while ((GetSecondStamp() - startTime <= Application.Get().ApplicationSource.GetImplicitWaitTimeOut())
                && !result)
            {
                try
                {
                    result = GetWebElement(by) == null || !GetWebElement(by).Enabled || !GetWebElement(by).Displayed;
                }
                catch (Exception)
                {
                    result = true;
                    break;
                }
                Thread.Sleep(TIME_SLEEP_MILLISECONDS);
            }
            return result;
        }       

        public override bool StalenessOfWebElement(IWebElement webElement)
        {
            bool result = false;
            long startTime = GetSecondStamp();
            while ((GetSecondStamp() - startTime <= Application.Get().ApplicationSource.GetImplicitWaitTimeOut())
                   && !result)
            {
                try
                {
                    result = webElement == null || !webElement.Enabled || !webElement.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    result = true;
                    break;
                }
                Thread.Sleep(TIME_SLEEP_MILLISECONDS);
            }
            return result;
        }
    }
}
