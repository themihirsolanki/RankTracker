using RankTracker.Core.Entities;

namespace RankTracker.Core.Repositories;
public interface ISearchEngineRepository : IRepository<SearchEngine>
{
    public Task<SearchEngine> GetSearchEngineByName(string name);
}
