using RankTracker.Core.Services;
using System.Text.RegularExpressions;

namespace RankTracker.Google.Services
{
    public class GoogleSerpScrapingService : ISerpScrapingService
    {
        private readonly IWebPageDownloader webPageDownloader;

        public GoogleSerpScrapingService(IWebPageDownloader webPageDownloader)
        {
            this.webPageDownloader = webPageDownloader;
        }

        public async Task<IEnumerable<string>> ExtractLinks(string keyword)
        {
            string encodedQuery = Uri.EscapeDataString(keyword);

            var html = await webPageDownloader.Download($"https://www.google.co.uk/search?num=100&q=land+registry+search");
            return ExtractUrls(html);
        }

        private static string[] ExtractUrls(string html)
        {
            var urls = new List<string>();
            string pattern = @"<a\s+(?:[^>]*?\s+)?href=""([^""]*)"""; // Matches href attributes within <a> tags.
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            foreach (Match match in regex.Matches(html))
            {
                if (match.Groups.Count > 1)
                {
                    string href = match.Groups[1].Value;

                    if (href.StartsWith("/url?q="))
                    {
                        // Extract the actual URL from the Google redirect.
                        string extractedUrl = System.Web.HttpUtility.UrlDecode(href.Substring(7).Split('&')[0]); //remove google redirect
                        if (extractedUrl.StartsWith("http"))
                        {
                            urls.Add(extractedUrl);
                        }
                    }
                    else if (href.StartsWith("http"))
                    {
                        urls.Add(href);
                    }
                }
            }

            return urls.ToArray();
        }
    }
}
