using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TheBestProject.Data.Application;
using TheBestProject.Pages.Main;
using TheBestProject.Tools.SearchWebElements;

namespace TheBestProject.Tools
{
    public class Application
    {
        private static volatile Application _instance;

        private static object LookingObject => new object();

        public IApplicationSource ApplicationSource { get; private set; }

        private static Dictionary<int, AllBrowser> _browser = new Dictionary<int, AllBrowser>();

        public AllBrowser Browser
        {
            get
            {
                int currentThread = Thread.CurrentThread.ManagedThreadId;
                if (!_browser.ContainsKey(currentThread))
                {
                    InitBrowser();
                }
                return _browser[currentThread];
            }
        }

        private ISearchStrategy _search;

        public ISearchStrategy Search
        {
            get
            {
                if (_search == null)
                    InitSearch();
                return _search;
            }
            private set => _search = value;
        }

        private Application(IApplicationSource applicationSource)
        {
            ApplicationSource = applicationSource;
        }

        public static Application Get(IApplicationSource applicationSource = null)
        {
            if (_instance == null)
            {
                lock (LookingObject)
                {
                    if (_instance == null)
                    {
                        if (applicationSource == null)
                            applicationSource = ApplicationSourceRepository.Get().Default();
                        _instance = new Application(applicationSource);
                    }
                }
            }
            return _instance;
        }

        public static void Remove()
        {
            if (_instance is null)
                return;

            //For parallel work
            int currentThread = Thread.CurrentThread.ManagedThreadId;
            if (_browser.ContainsKey(currentThread))
            {
                _browser[currentThread].Quit();
                _browser.Remove(currentThread);
            }

            if (!_browser.Any())
                _instance = null;
        }

        private void InitBrowser(IApplicationSource applicationSource = null)
        {
            if (applicationSource is null)
                applicationSource = ApplicationSource;
            _browser.Add(Thread.CurrentThread.ManagedThreadId, new AllBrowser(applicationSource));
        }

        private void InitSearch()
        {
            Search = new SearchElement();
        }

        public void SaveCurrentState()
        {
            string prefix = Browser.SaveScreenShot();
            Browser.SaveSourceCode(prefix);
        }

        public MainPage BaseUrlAction()
        {
            Browser.OpenUrl(ApplicationSource.GetBaseUrl());
            return new MainPage();
        }
    }
}
