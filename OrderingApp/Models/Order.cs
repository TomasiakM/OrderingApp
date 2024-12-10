using OrderingApp.Exceptions;

namespace OrderingApp.Models;
public class Order
{
    public int Id { get; init; }
    public decimal Discount { get; private set; }

    public List<OrderItem> Items { get; private set; } = new();

    public Order(List<OrderItem> items)
    {
        Items = items;

        ValidateOrder();
    }

    private void ValidateOrder()
    {
        if (Discount < 0)
        {
            throw new DomainException("Order discount cannot be negative");
        }

        if (Items.Count == 0)
        {
            throw new DomainException("Cannot create order with empty order items");
        }
    }
}
