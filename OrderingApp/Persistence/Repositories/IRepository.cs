using System.Linq.Expressions;

namespace OrderingApp.Persistence.Repositories;
public interface IRepository<TEntity, TId>
    where TEntity : class
{
    public void Add(TEntity entity);

    public void Update(TEntity entity);

    public void Delete(TEntity entity);

    public Task<List<TEntity>> GetAllAsync();

    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);

    public Task<int> SaveChangesAsync();
}
