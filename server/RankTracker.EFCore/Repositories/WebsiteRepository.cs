using Microsoft.EntityFrameworkCore;
using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;

namespace RankTracker.EFCore.Repositories;

public class WebsiteRepository : RepositoryBase<Website>, IWebsiteRepository
{
    public WebsiteRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<Website?> GetWebsiteByDomainAsync(string domain)
    {
        return await dataContext.Websites.SingleOrDefaultAsync(w => w.Domain == domain.Trim().ToLower());
    }
}
