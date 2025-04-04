﻿using RankTracker.Core.Entities;

namespace RankTracker.Core.Repositories;

public interface IKeywordRankRepository : IRepository<KeywordRank>
{
    public Task RemoveAllByKeywordId(int keywordId);
}
