using Microsoft.EntityFrameworkCore;
using OrderingApp.Models;

namespace OrderingApp.Persistence;
internal sealed class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("InMemoDb");
    }
}
