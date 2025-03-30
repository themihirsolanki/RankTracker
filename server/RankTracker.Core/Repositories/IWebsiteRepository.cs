using RankTracker.Core.Entities;

namespace RankTracker.Core.Repositories;

public interface IWebsiteRepository
{
    Task<Website> GetWebsiteByIdAsync(int id);
    Task<IEnumerable<Website>> GetAllWebsitesAsync();
    Task AddWebsiteAsync(Website website);
    Task UpdateWebsiteAsync(Website website);
    Task DeleteWebsiteAsync(int id);
    Task<Website> GetWebsiteByDomainAsync(string domain);

}
