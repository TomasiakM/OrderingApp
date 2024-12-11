using OrderingApp.Models;

namespace OrderingApp.Services.Discount.Strategies;
internal sealed class TotalOrderValueDiscountStrategy : IDiscountStrategy
{
    private const decimal Discount = 0.05m;
    private const decimal ValueThreshold = 5000;

    public void ApplyDiscount(Order order)
    {
        var orderValue = order.GetTotalOrderValue();
        if (orderValue > ValueThreshold)
        {
            order.SetDiscount(orderValue * Discount);
        }
    }
}
