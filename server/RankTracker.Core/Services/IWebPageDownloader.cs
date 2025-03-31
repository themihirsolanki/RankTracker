namespace RankTracker.Core.Services;
public interface IWebPageDownloader
{
    Task<string> Download(string url);
}
