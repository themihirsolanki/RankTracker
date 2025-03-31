using RankTracker.Core.Entities;
using System.Security.Principal;

namespace RankTracker.Core.Repositories;
public interface IKeywordRepository : IRepository<Keyword>
{
    Task<IEnumerable<Keyword>> GetAllAsync(int websiteId);
}
