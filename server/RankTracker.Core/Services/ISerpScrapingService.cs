namespace RankTracker.Core.Services;

public interface ISerpScrapingService
{
    Task<IEnumerable<string>> ExtractLinks(string keyword);
}
