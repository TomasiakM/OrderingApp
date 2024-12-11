using OrderingApp.Models;

namespace OrderingApp.Services.Products;
public interface IProductService
{
    Product? Get(int id);
    IReadOnlyList<Product> GetAll();
}
