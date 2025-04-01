using Microsoft.EntityFrameworkCore;
using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;

namespace RankTracker.EFCore.Repositories;

public class SearchEngineRepository : RepositoryBase<SearchEngine>, ISearchEngineRepository
{
    public SearchEngineRepository(DataContext dbContext) : base(dbContext)
    {

    }

    public async Task<SearchEngine> GetSearchEngineByName(string name)
    {
        return await dbSet.SingleOrDefaultAsync(x => x.Name.ToLowerInvariant() == name);
    }
}
