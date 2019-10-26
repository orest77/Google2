using OpenQA.Selenium;
using System.Collections.Generic;
using TheBestProject.Pages.Main;

namespace TheBestProject.Pages.SearchPages
{
    public class SearchPage : MainPage
    {
       
        protected IList<IWebElement> LowBarElements => Search.ElementsByXPath("//div[@id='hdtb-msb-vis']/div");

        protected IList<SearchResult> Links => InitializeListSearchResult(Search.ElementsByXPath("//div[@class='g']"));


        public IList<SearchResult> InitializeListSearchResult(IList<IWebElement> elements)
        {
            IList<SearchResult> list = new List<SearchResult>();

            foreach (var current in elements)
            {
                list.Add(new SearchResult(current));
            }
            return list;
        }

        public IList<SearchResult> GetListSearchResult()
        {
            return Links;
        }

        public SearchResult FindAppropriateLink(string product)
        {

            foreach (var item in Links)
            {
                if (item.IsAppropriate(product))
                {
                    return item;
                }
            }
            return null;
        }

        public string GetTitleTextLink(string name)
        {
            return FindAppropriateLink(name).GetTextLink();
        }
    }
}
