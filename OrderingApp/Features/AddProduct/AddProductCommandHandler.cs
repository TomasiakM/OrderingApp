using OrderingApp.Models;
using OrderingApp.Persistence.Repositories;

namespace OrderingApp.Features.AddProduct;
internal sealed class AddProductCommandHandler
{
    private readonly IRepository<Product, int> _productRepository;

    public AddProductCommandHandler(IRepository<Product, int> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(AddProductCommand message)
    {
        var product = new Product(message.Name, message.Price, message.Stock);

        _productRepository.Add(product);
        await _productRepository.SaveChangesAsync();
    }
}
