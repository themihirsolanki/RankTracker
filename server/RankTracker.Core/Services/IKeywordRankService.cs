namespace RankTracker.Core.Services;
public interface IKeywordRankService
{
    public Task CheckKeywordRank(string domain, int keywordId);
}
