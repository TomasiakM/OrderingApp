using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace OrderingApp.Persistence.Repositories;
internal abstract class GenericRepository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : class
{
    public AppDbContext DbContext { get; init; }

    protected GenericRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return DbContext
            .Set<TEntity>()
            .ToListAsync();
    }

    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
    {
        return DbContext
            .Set<TEntity>()
            .Where(filter)
            .ToListAsync();
    }

    public Task<int> SaveChangesAsync()
    {
        return DbContext.SaveChangesAsync();
    }
}
