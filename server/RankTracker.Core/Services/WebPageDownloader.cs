using Microsoft.Extensions.Logging;

namespace RankTracker.Core.Services;

public class WebPageDownloader : IWebPageDownloader
{
    private readonly ILogger<WebPageDownloader> logger;

    public WebPageDownloader(ILogger<WebPageDownloader> logger)
    {
        this.logger = logger;
    }

    public async Task<string> Download(string url)
    {
        try
        {
            var client = new HttpClient();
            HttpRequestMessage request = new(HttpMethod.Get, url);
            // Important to avoid getting blocked
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.Headers.Add("Accept-Language", "en-GB,en;q=0.5");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            throw new Exception($"Request to {url} failed.");
        }
        catch (HttpRequestException ex)
        {
            this.logger.LogError($"Error during HTTP request: {ex.Message}");
            return string.Empty;
        }
        catch (Exception ex)
        {
            this.logger.LogError($"An unexpected error occurred: {ex.Message}");
            return string.Empty;
        }
    }

}
