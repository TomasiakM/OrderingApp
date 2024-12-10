using OrderingApp.Exceptions;
using OrderingApp.Services.DiscountService;

namespace OrderingApp.Models;
public class Order
{
    public int Id { get; init; }
    public decimal Discount { get; private set; }

    public List<OrderItem> Items { get; private set; } = new();

    public Order(List<OrderItem> items, IDiscountService discountService)
    {
        Items = items;

        ValidateOrder();
        discountService.Calculate(this);
    }

    public int GetQuantityOfAllProducts()
    {
        return Items.Sum(item => item.Quantity);
    }

    public decimal GetOrderValue()
    {
        return Items.Sum(e => (e.Price * e.Quantity) - e.Discount);
    }

    public void SetDiscount(decimal discount)
    {
        Discount = discount;

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
