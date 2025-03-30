using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using System.Reflection;

namespace RankTracker.Core.Services;

public class WebsiteService : IWebsiteService
{
    private readonly IWebsiteRepository websiteRepository;
    public WebsiteService(IWebsiteRepository websiteRepository)
    {
        this.websiteRepository = websiteRepository;
    }

    public async Task Add(string domain)
    {
        domain = domain.Trim().ToLowerInvariant();

        var existingWebsite = await websiteRepository.GetWebsiteByDomainAsync(domain);

        if (existingWebsite != null)
        {
            throw new InvalidOperationException("Website already exists");
        }

        var website = new Website { Domain = domain };
        await websiteRepository.AddAsync(website);
    }
}