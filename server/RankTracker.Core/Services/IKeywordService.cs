namespace RankTracker.Core.Services;
public interface IKeywordService
{
    Task AddKeywordAsync(string keyword);
    Task RefreshRankings();
}
