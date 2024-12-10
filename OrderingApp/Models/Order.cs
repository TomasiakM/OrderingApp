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
        CalculateDiscount();
    }


    private void CalculateDiscount()
    {
        var itemsCount = Items.Count;

        if (itemsCount == 2)
        {
            var cheapest = Items.OrderBy(e => e.Price).First();
            cheapest.SetDiscount(cheapest.Price * 0.1m);
        }
        else if (itemsCount >= 3)
        {
            var cheapest = Items.OrderBy(e => e.Price).First();
            cheapest.SetDiscount(cheapest.Price * 0.2m);
        }

        var totalValue = Items.Sum(e => e.Price * e.Quantity);
        if (totalValue > 5000)
        {
            Discount = totalValue * 0.05m;
        }

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
