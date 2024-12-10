using OrderingApp.Models;
using OrderingApp.Persistence.Repositories;

namespace OrderingApp.Features.GetAllProducts;
internal sealed class GetAllProductsQueryHandler
{
    private readonly IRepository<Product, int> _productRepository;

    public GetAllProductsQueryHandler(IRepository<Product, int> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery message)
    {
        var products = await _productRepository.GetAllAsync();

        return products;
    }
}
