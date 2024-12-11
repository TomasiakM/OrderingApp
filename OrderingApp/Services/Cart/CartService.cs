using OrderingApp.Models;
using OrderingApp.Services.Discount;
using OrderingApp.Services.Products;

namespace OrderingApp.Services.Cart;
internal class CartService : ICartService
{
    private static Dictionary<int, CartItem> _idCartTimeDictionary = new();

    private readonly IProductService _productService;

    public CartService(IProductService productService)
    {
        _productService = productService;
    }

    public void AddProduct(int id, int quantity)
    {
        var product = _productService.Get(id);

        if (product is null)
        {
            Console.WriteLine("Nie odnaleziono produktu o id {0}", id);

            return;
        }

        _idCartTimeDictionary.Add(product.Id, new(product, quantity));
    }

    public void DeleteProduct(int id)
    {
        _idCartTimeDictionary.TryGetValue(id, out var cartItem);

        if (cartItem is not null)
        {
            cartItem.Product.ReturnStock(cartItem.Quantity);
            _idCartTimeDictionary.Remove(id);
        }
    }

    public IEnumerable<CartItem> GetItems()
    {

        return _idCartTimeDictionary
            .Select(e => new CartItem(e.Value.Product, e.Value.Quantity));
    }

    public Order CreateOrder()
    {
        var orderItems = _idCartTimeDictionary.Values
            .Select(cartItem => new OrderItem(cartItem.Product, cartItem.Quantity))
            .ToList();
        var order = new Order(orderItems, new DiscountService());

        return order;
    }
}
