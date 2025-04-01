namespace RankTracker.Core.Repositories;
public interface IRepository<IEntity>
{
    Task AddAsync(IEntity entity);
    Task RemoveAsync(IEntity entity);
    Task<IEntity?> GetAsync(int id);
    Task<IEnumerable<IEntity>> GetAllAsync();
    Task UpdateAsync(IEntity entity);
}
