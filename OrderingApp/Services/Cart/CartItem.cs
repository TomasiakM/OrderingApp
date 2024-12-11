using OrderingApp.Models;

namespace OrderingApp.Services.Cart;
public sealed class CartItem
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }

    public CartItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
}
