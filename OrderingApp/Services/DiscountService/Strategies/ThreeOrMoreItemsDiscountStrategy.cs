using OrderingApp.Models;

namespace OrderingApp.Services.DiscountService.Strategies;
internal sealed class ThreeOrMoreItemsDiscountStrategy : IDiscountStrategy
{
    private const decimal Discount = 0.2m;

    public void ApplyDiscount(Order order)
    {
        var itemsCount = order.Items.Sum(e => e.Quantity);
        if (order.Items.Sum(e => e.Quantity) >= 3)
        {
            var cheapest = order.Items.OrderBy(e => e.Price).First();
            cheapest.SetDiscount(cheapest.Price * Discount);
        }
    }
}
