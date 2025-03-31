using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RankTracker.Core.Services;

namespace RankTracker.Core;
public static class ServiceCollectionExtensions
{
    public static void AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IKeywordService, KeywordService>();
        services.AddScoped<IWebsiteService, WebsiteService>();
        services.AddScoped<IWebPageDownloader, WebPageDownloader>();
    }
}
