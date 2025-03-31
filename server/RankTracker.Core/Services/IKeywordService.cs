namespace RankTracker.Core.Services;
public interface IKeywordService
{
    Task AddKeywordAsync(string keyword);
    Task DeleteKeywordAsync(int id);
    Task RefreshRankings();
    Task RefreshRanking(int id);
}
