﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;
using RankTracker.EFCore.Repositories;

namespace RankTracker.EFCore;

public static class ServiceRegistration
{
    public static void AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("RankTracker"));

        services.AddScoped<IWebsiteRepository, WebsiteRepository>();
    }
}
