using Microsoft.EntityFrameworkCore;
using RankTracker.Core.Repositories;
using RankTracker.EFCore.Context;

namespace RankTracker.EFCore.Repositories;

public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DataContext dataContext;
    protected readonly DbSet<TEntity> dbSet;

    public RepositoryBase(DataContext dbContext)
    {
        dataContext = dbContext;
        dbSet = dataContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await dataContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(TEntity entity)
    {
        dbSet.Remove(entity);
        await dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        dataContext.Entry(entity).State = EntityState.Modified;
        await dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }
}
