using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using TheBestProject.Tools;

namespace TheBestProject.Data.Application
{
    public sealed class ApplicationSourceRepository
    {
        private static volatile ApplicationSourceRepository _instance;

        private static object LookingObject => new object();

        private ApplicationSourceRepository() { }
        public static ApplicationSourceRepository Get()
        {
            if (_instance == null)
            {
                lock (LookingObject)
                {
                    if(_instance == null)
                        _instance = new ApplicationSourceRepository();
                }
            }
            return _instance;
        }

        public IApplicationSource Default()
        {
            return ChromeWithUi();
        }

        public IApplicationSource ChromeWithUi()
        {
            return ApplicationSource.Get()
                .SetBrowserName(CONST.CHROME_BROWSER)
                .SetImplicitWaitTimeOut(10L)
                .SetExplicitTimeOut(0)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .Build();
        }

        public IApplicationSource FirefoxWithUi()
        {
            return ApplicationSource.Get()
                .SetBrowserName(CONST.FIREFOX_BROWSER)
                .SetImplicitWaitTimeOut(10L)
                .SetExplicitTimeOut(10L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .Build();
        }

        public IApplicationSource ChromeMaximizedWithUi()
        {
            List<string> options = new List<string>()
            {
                "--start-maximized", "--no-proxy-server", "--ignore-certificate-errors"
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.CHROME_BROWSER)
                .SetImplicitWaitTimeOut(15L)
                .SetExplicitTimeOut(15L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .Build();
        }

        public IApplicationSource ChromeWithoutUi()
        {
            List<string> options = new List<string>()
            {
                "--headless", "--no-proxy-server", "--ignore-certificate-errors"
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.CHROME_BROWSER)
                .SetImplicitWaitTimeOut(10L)
                .SetExplicitTimeOut(10L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .Build();
        }

        public IApplicationSource RemoteLinuxChromeNew()
        {
            List<string> options = new List<string>()
            {
                "--no-sandbox","--display=:99.0"
            };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", CONST.CHROME_BROWSER },
                { CapabilityType.Platform, "Linux" }
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.REMOTE_BROWSER)
                .SetImplicitWaitTimeOut(15L)
                .SetExplicitTimeOut(15L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .SetCapabilities(capabilities)
                .SetUri(new Uri(CONST.SELENIUM_HUB))
                .Build();
        }

        public IApplicationSource RemoteChrome()
        {
            List<string> options = new List<string>()
            {
               "--headless", "--no-gpu", "--disable-software-rasterizer",  "--mute-audio",
                "--hide-scrollbars"
            };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", CONST.CHROME_BROWSER  },
                { CapabilityType.Platform, "Linux" }
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.REMOTE_BROWSER)
                .SetImplicitWaitTimeOut(15L)
                .SetExplicitTimeOut(15L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .SetCapabilities(capabilities)
                .SetUri(new Uri(CONST.SELENIUM_HUB))
                .Build();
        }

        public IApplicationSource RemoteFirefox()
        {
            List<string> options = new List<string>()
            {
                 "--headless", "--ignore-certificate-errors", "--acceptInsecureCerts-false"
            };
            Dictionary<string, object> capabilities = new Dictionary<string, object>
            {
                { "browser", CONST.FIREFOX_BROWSER  },
                { CapabilityType.Platform, "Linux" }
            };
            return ApplicationSource.Get()
                .SetBrowserName(CONST.REMOTE_BROWSER)
                .SetImplicitWaitTimeOut(15L)
                .SetExplicitTimeOut(15L)
                .SetBaseUrl(CONST.BASE_URL)
                .SetLoginUrl(CONST.LOGIN_URL)
                .SetLogoutUrl(CONST.LOGOUT_URL)
                .SetBrowserOptions(options)
                .SetCapabilities(capabilities)
                .SetUri(new Uri(CONST.SELENIUM_HUB))
                .Build();
        }
    }
}
