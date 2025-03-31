using Microsoft.EntityFrameworkCore;
using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;

namespace RankTracker.EFCore.Repositories;

public class KeywordRepository : RepositoryBase<Keyword>, IKeywordRepository
{
    public KeywordRepository(DataContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Keyword>> GetAllAsync(int websiteId)
    {
        return await dbSet.Where(a => a.WebsiteId == websiteId).ToListAsync();
    }
}
