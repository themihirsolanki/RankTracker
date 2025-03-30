using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;

namespace RankTracker.EFCore.Repositories;

public class KeywordRepository : RepositoryBase<Keyword>, IKeywordRepository
{
    public KeywordRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
