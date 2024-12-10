using OrderingApp.Models;

namespace OrderingApp.Persistence.Repositories;
internal sealed class OrderRepository : GenericRepository<Order, int>
{
    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
