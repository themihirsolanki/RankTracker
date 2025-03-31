using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RankTracker.Core.Services;
using RankTracker.Google.Services;

namespace RankTracker.Google.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddGoogleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IKeywordRankService, GoogleKeywordRankService>();
        services.AddScoped<GoogleSerpScrapingService, GoogleSerpScrapingService>();
    }
}
