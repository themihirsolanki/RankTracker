using RankTracker.Core.Entities;

namespace RankTracker.Core.Repositories;

public interface IWebsiteRepository : IRepository<Website>
{
    Task<Website?> GetWebsiteByDomainAsync(string domain);
}
