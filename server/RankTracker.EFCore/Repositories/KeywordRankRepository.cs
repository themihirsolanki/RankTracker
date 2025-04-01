using Microsoft.EntityFrameworkCore;
using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;

namespace RankTracker.EFCore.Repositories;

public class KeywordRankRepository : RepositoryBase<KeywordRank>, IKeywordRankRepository
{
    public KeywordRankRepository(DataContext dbContext) : base(dbContext)
    {
    }

    public async Task RemoveAllByKeywordId(int keywordId)
    {
        var ranks = await this.dbSet.Where(kr => kr.KeywordId == keywordId).ToArrayAsync();

        this.dbSet.RemoveRange(ranks);
        await dataContext.SaveChangesAsync();
    }
}
