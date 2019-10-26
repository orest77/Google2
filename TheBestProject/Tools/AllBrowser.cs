using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TheBestProject.Data.Application;

namespace TheBestProject.Tools
{
    public interface IBrowser
    {
        IWebDriver GetBrowser(IApplicationSource applicationSource);
    }

    public class RemoteBrowser : IBrowser
    {
        public IWebDriver GetBrowser(IApplicationSource applicationSource)
        {
            switch (applicationSource.GetCapabilities()["browser"])
            {
                case CONST.CHROME_BROWSER:
                    return RemoteChromeBrowser(applicationSource);
                case CONST.FIREFOX_BROWSER:
                    return RemoteFirefoxBrowser(applicationSource);
                default:
                    Console.WriteLine("Browser name Error!");
                    return null;
            }

            RemoteWebDriver RemoteChromeBrowser(IApplicationSource applicationSource)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments(applicationSource.GetBrowserOptions());

                foreach (var capabilities in applicationSource.GetCapabilities())
                {
                    options.AddAdditionalCapability(capabilities.Key, capabilities.Value, true);
                }
                return new RemoteWebDriver(applicationSource.GetUri(), options.ToCapabilities(), TimeSpan.FromSeconds(180));
            }

            RemoteWebDriver RemoteFirefoxBrowser(IApplicationSource applicationSource)
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments(applicationSource.GetBrowserOptions());

                foreach (var capabilities in applicationSource.GetCapabilities())
                {
                    options.AddAdditionalCapability(capabilities.Key, capabilities.Value, true);
                }
                return new RemoteWebDriver(applicationSource.GetUri(), options.ToCapabilities(), TimeSpan.FromSeconds(180));
            }
        }
    }

    public class ChromeBrowser : IBrowser
    {
        public IWebDriver GetBrowser(IApplicationSource applicationSource)
        {
            if (applicationSource.GetBrowserOptions() != null)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments(applicationSource.GetBrowserOptions());
                return new ChromeDriver(Environment.CurrentDirectory, options);
            }
            else
            {
                return new ChromeDriver(Environment.CurrentDirectory);
            }
        }
    }

    public class FirefoxBrowser : IBrowser
    {
        public IWebDriver GetBrowser(IApplicationSource applicationSource)
        {           
            if (applicationSource.GetBrowserOptions() != null)
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments(applicationSource.GetBrowserOptions());
                return new FirefoxDriver(Environment.CurrentDirectory, options);
            }
            else
            {
                return new FirefoxDriver(Environment.CurrentDirectory);
            }
        }
    }
    public class AllBrowser
    {
        private Dictionary<string, IBrowser> _browsers;

        public IWebDriver Driver { get; private set; }

        public AllBrowser(IApplicationSource applicationSource)
        {
            InitBrowsers();
            InitWebDriver(applicationSource);
        }

        private void InitBrowsers()
        {
            _browsers = new Dictionary<string, IBrowser>();
            _browsers.Add(CONST.CHROME_BROWSER, new ChromeBrowser());
            _browsers.Add(CONST.FIREFOX_BROWSER, new FirefoxBrowser());
            _browsers.Add(CONST.REMOTE_BROWSER, new RemoteBrowser());
        }

        private bool IsContinuesIntegration()
        {
            return Environment.GetEnvironmentVariable(CONST.IS_CONTINUES_INTEGRATION) == CONST.STRING_TRUE;
        }

        private void InitWebDriver(IApplicationSource applicationSource)
        {
            IBrowser currentBrowser = _browsers[CONST.CHROME_BROWSER];
            if(IsContinuesIntegration())
            {
                currentBrowser = _browsers[CONST.CONTINUES_INTEGRATION_BROWSER];
            }
            else
            {
                foreach (KeyValuePair<string ,IBrowser> current in _browsers)
                {
                    if (current.Key.ToLower()
                        .Equals(applicationSource.GetBrowserName().ToLower()))
                    {
                        currentBrowser = current.Value;
                    }
                }
            }
            Driver = currentBrowser.GetBrowser(applicationSource);
        }
        private string GetTime()
        {
            DateTime localDate = DateTime.Now;
            return localDate.ToString(CONST.TIME_TEMPLATE);
        }

        private string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetAssembly(typeof(AllBrowser)).CodeBase)
                    .Substring(AExternalReader.PATH_PREFIX);
        }

        public void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string SaveScreenShot()
        {
            return SaveScreenShot(null);
        }

        public string SaveScreenShot(string namePrefix)
        {
            if ((namePrefix == null) || (namePrefix.Length == 0))
            {
                namePrefix = GetTime();
            }
            ITakesScreenshot takeScreenShot = Driver as ITakesScreenshot;
            Screenshot screenShot = takeScreenShot.GetScreenshot();
            screenShot.SaveAsFile(GetCurrentDirectory() + AExternalReader.PATH_SEPARATOR
                        + namePrefix + CONST.SCREEN_SHOT_PNG, ScreenshotImageFormat.Png);
            return namePrefix;
        }

        public string SaveSourceCode()
        {
            return SaveSourceCode(null);
        }

        public string SaveSourceCode(string namePrefix)

        {
            if ((namePrefix == null) || (namePrefix.Length == 0))
            {
                namePrefix = GetTime();
            }
            File.WriteAllText(GetCurrentDirectory() + AExternalReader.PATH_SEPARATOR
                        + namePrefix + CONST.SOURCECODE_TXT, Driver.PageSource);
            return namePrefix;
        }

        public void NavigateForward()
        {
            Driver.Navigate().Forward();
        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}
