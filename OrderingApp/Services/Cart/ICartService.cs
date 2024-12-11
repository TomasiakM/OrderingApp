using OrderingApp.Models;

namespace OrderingApp.Services.Cart;
public interface ICartService
{
    void AddProduct(string name, decimal price, int stock, int quantity);
    void DeleteProduct(int id);
    public IEnumerable<CartItem> GetItems();
    public Order CreateOrder();
}
