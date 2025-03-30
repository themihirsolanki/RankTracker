using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;

namespace RankTracker.EFCore.Repositories;

public class KeywordRankRepository : RepositoryBase<KeywordRank>, IKeywordRankRepository
{
    public KeywordRankRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
