using RankTracker.Core.Services;
using System.Text.RegularExpressions;

namespace RankTracker.Bing.Services;

public class BingSerpScrapingService : ISerpScrapingService
{
    private readonly IWebPageDownloader webPageDownloader;

    public BingSerpScrapingService(IWebPageDownloader webPageDownloader)
    {
        this.webPageDownloader = webPageDownloader;
    }

    public async Task<IEnumerable<string>> ExtractLinks(string keyword)
    {
        string encodedQuery = Uri.EscapeDataString(keyword);

        var html = await webPageDownloader.Download($"https://www.bing.com/search?q={keyword}");

        return ExtractUrls(html);
    }

    private List<string> ExtractUrls(string html)
    {
        if (string.IsNullOrEmpty(html))
        {
            return new List<string>(); // Return empty list if HTML is null or empty
        }

        List<string> links = new List<string>();
        string pattern = "<a href=\"(.*?)\""; // Simple regex for href attributes
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(html);

        foreach (Match match in matches)
        {
            string link = match.Groups[1].Value;
            if (!string.IsNullOrEmpty(link) && (link.StartsWith("http") || link.StartsWith("https"))) // Only add valid http/https links
            {
                links.Add(link);
            }
        }
        return links;
    }
}
