using OrderingApp.Models;

namespace OrderingApp.Services.Cart;
public interface ICartService
{
    void AddProduct(int id, int quantity);
    void DeleteProduct(int id);
    public IEnumerable<CartItem> GetItems();
    public Order CreateOrder();
}
