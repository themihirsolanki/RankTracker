using Microsoft.EntityFrameworkCore;
using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;

namespace RankTracker.EFCore.Repositories;

public class WebsiteRepository : IWebsiteRepository
{
    private readonly DataContext dataContext;

    public WebsiteRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task AddWebsiteAsync(Website website)
    {
        await this.dataContext.Websites.AddAsync(website);
        await this.dataContext.SaveChangesAsync();
    }

    public async Task DeleteWebsiteAsync(int id) => throw new NotImplementedException();

    public async Task<IEnumerable<Website>> GetAllWebsitesAsync()
    {
        return await dataContext.Websites.ToListAsync();
    }

    public async Task<Website> GetWebsiteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Website?> GetWebsiteByDomainAsync(string domain) => 
        await dataContext.Websites.SingleOrDefaultAsync(w => w.Domain == domain.ToLower());

    public async Task UpdateWebsiteAsync(Website website)
    {
        throw new NotImplementedException();
    }
}
