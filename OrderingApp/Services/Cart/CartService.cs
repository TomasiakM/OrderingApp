using OrderingApp.Models;
using OrderingApp.Services.Discount;

namespace OrderingApp.Services.Cart;
internal class CartService : ICartService
{
    private static Dictionary<int, CartItem> _products = new();
    private static int _lastId = 1;

    public void AddProduct(string name, decimal price, int stock, int quantity)
    {
        var product = new Product(name, price, stock) { Id = _lastId };
        _lastId++;

        _products.Add(product.Id, new(product, quantity));
    }

    public void DeleteProduct(int id)
    {
        _products.TryGetValue(id, out var product);

        if (product is not null)
        {
            _products.Remove(id);
        }
    }

    public IEnumerable<CartItem> GetItems()
    {

        return _products.Select(e => new CartItem(e.Value.Product, e.Value.Quantity));
    }

    public Order CreateOrder()
    {
        var orderItems = _products.Values
            .Select(cartItem => new OrderItem(cartItem.Product, cartItem.Quantity))
            .ToList();
        var order = new Order(orderItems, new DiscountService());

        return order;
    }
}
