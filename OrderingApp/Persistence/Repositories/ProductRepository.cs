using OrderingApp.Models;

namespace OrderingApp.Persistence.Repositories;


internal sealed class ProductRepository : GenericRepository<Product, int>
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
