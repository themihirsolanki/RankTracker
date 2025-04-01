using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;
using RankTracker.EFCore.Repositories;

namespace RankTracker.EFCore;

public static class ServiceCollectionExtensions
{
    public static void AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (connectionString == null)
        {
            services.AddDbContext<DataContext>(options =>
                    options.UseInMemoryDatabase("RankTracker"));
        }
        else
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));
        }

        services.AddScoped<IWebsiteRepository, WebsiteRepository>();
        services.AddScoped<IKeywordRepository, KeywordRepository>();
        services.AddScoped<IKeywordRankRepository, KeywordRankRepository>();
        services.AddScoped<ISearchEngineRepository, SearchEngineRepository>();
    }
}
