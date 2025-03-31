using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RankTracker.Bing.Services;
using RankTracker.Core.Services;

namespace RankTracker.Bing.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBingServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IKeywordRankService, BingKeywordRankService>();
            services.AddScoped<BingSerpScrapingService, BingSerpScrapingService>();
        }
    }
}
