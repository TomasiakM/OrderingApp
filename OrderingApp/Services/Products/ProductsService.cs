using OrderingApp.Models;

namespace OrderingApp.Services.Products;
internal class ProductsService : IProductService
{
    private static List<Product> _products = new() {
        new("Laptop", 2500, 4) {  Id = 1 },
        new("Klawiatura", 120, 25) {  Id = 2 },
        new("Mysz", 90, 40) {  Id = 3 },
        new("Monitor", 1000, 7) {  Id = 4 },
        new("Kaczka debuggująca", 66, 666) { Id = 5 },
    };

    public Product? Get(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public IReadOnlyList<Product> GetAll()
    {
        return _products.ToList();
    }
}
