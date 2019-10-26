using System;
using System.Collections.Generic;

namespace TheBestProject.Data.Application
{
    public interface ISetBrowserName
    {
        ISetImplicitWaitTimeOut SetBrowserName(string browsersName);
    }

    public interface ISetImplicitWaitTimeOut
    {
        ISetExplicitTimeOut SetImplicitWaitTimeOut(long implicitWaitTimeOut);
    }

    public interface ISetExplicitTimeOut
    {
        ISetBaseUrl SetExplicitTimeOut(long explicitTime);
    }

    public interface ISetBaseUrl
    {
        ISetLoginUrl SetBaseUrl(string baseUrl);
    }
    public interface ISetLoginUrl
    {
        ISetLogoutUrl SetLoginUrl(string loginUrl);
    }
    public interface ISetLogoutUrl
    {
        IApplicationSourceBuild SetLogoutUrl(string logoutUrl);
    }

    public interface IApplicationSourceBuild
    {
        IApplicationSourceBuild SetBrowserOptions(List<string> browserOptions);
        IApplicationSourceBuild SetCapabilities(Dictionary<string, object> capabilities);
        IApplicationSourceBuild SetUri(Uri uri);
        IApplicationSource Build();
    }

    public interface IApplicationSource
    {       
        string GetBrowserName();
        long GetImplicitWaitTimeOut();
        long GetExplicitTimeOut();
        Uri GetUri();
        Dictionary<string, object> GetCapabilities();
        List<string> GetBrowserOptions();
        string GetBaseUrl();
        string GetLogitUrl();
        string GetLogoutUrl();
    }

    public interface ICommonInterface : ISetBrowserName, ISetImplicitWaitTimeOut, ISetExplicitTimeOut,
        ISetBaseUrl, ISetLoginUrl, ISetLogoutUrl, IApplicationSourceBuild, IApplicationSource
    { }

    public class ApplicationSource : ICommonInterface
    {
        //Browser data
        private string _browserName;
        //Implicit and Explicit waits
        private long _implicitWaitTimeOut;
        private long _explicitTimeOut;
        // Remote 
        private Uri _uri;
        private Dictionary<string, object> _capabilities;
        private List<string> _browserOptions;
        //URLs
        private string _baseUrl;
        private string _logitUrl;
        private string _logoutUrl;

        public IApplicationSource Build()
        {
            return this;
        }

        public static ISetBrowserName Get()
        {
            return new ApplicationSource();
        }

        public string GetBaseUrl()
        {
            return _baseUrl;
        }

        public string GetBrowserName()
        {
            return _browserName;
        }

        public List<string> GetBrowserOptions()
        {
            return _browserOptions;
        }

        public Dictionary<string, object> GetCapabilities()
        {
            return _capabilities;
        }

        public long GetExplicitTimeOut()
        {
            return _explicitTimeOut;
        }

        public long GetImplicitWaitTimeOut()
        {
            return _implicitWaitTimeOut;
        }

        public string GetLogitUrl()
        {
            return _logitUrl;
        }

        public string GetLogoutUrl()
        {
            return _logoutUrl;
        }

        public Uri GetUri()
        {
            return _uri;
        }

        public ISetLoginUrl SetBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
            return this;
        }

        public ISetImplicitWaitTimeOut SetBrowserName(string browsersName)
        {
            _browserName = browsersName;
            return this;
        }

        public IApplicationSourceBuild SetBrowserOptions(List<string> browserOptions)
        {
            _browserOptions = browserOptions;
            return this;
        }

        public IApplicationSourceBuild SetCapabilities(Dictionary<string, object> capabilities)
        {
            _capabilities = capabilities;
            return this;
        }

        public ISetBaseUrl SetExplicitTimeOut(long explicitTime)
        {
            _explicitTimeOut = explicitTime;
            return this;
        }
        
        public ISetExplicitTimeOut SetImplicitWaitTimeOut(long implicitWaitTimeOut)
        {
            _implicitWaitTimeOut = implicitWaitTimeOut;
            return this;
        }

        public ISetLogoutUrl SetLoginUrl(string loginUrl)
        {
            _logitUrl = loginUrl;
            return this;
        }

        public IApplicationSourceBuild SetLogoutUrl(string logoutUrl)
        {
            _logoutUrl = logoutUrl;
            return this;
        }

        public IApplicationSourceBuild SetUri(Uri uri)
        {
            _uri = uri;
            return this;
        }       
    }
}
