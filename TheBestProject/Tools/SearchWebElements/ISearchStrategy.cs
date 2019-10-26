namespace TheBestProject.Tools.SearchWebElements
{
    public interface ISearchStrategy : ISearch  
    {
        void SetImplicitStrategy();

        void SetExplicitStrategy();
    }
}
