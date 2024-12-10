using OrderingApp.Models;
using OrderingApp.Services.DiscountService.Strategies;

namespace OrderingApp.Services.DiscountService;
internal sealed class DiscountService : IDiscountService
{
    private readonly List<IDiscountStrategy> _discountStrategies = new()
    {
        new TwoItemsDiscountStrategy(),
        new ThreeOrMoreItemsDiscountStrategy(),
        new TotalOrderValueDiscountStrategy()
    };

    public void Calculate(Order order)
    {
        foreach (var strategy in _discountStrategies)
        {
            strategy.ApplyDiscount(order);
        }
    }
}
