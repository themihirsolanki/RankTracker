using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;

namespace RankTracker.EFCore.Repositories;

public class SearchEngineRepository : RepositoryBase<SearchEngine>, ISearchEngineRepository
{
    public SearchEngineRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
