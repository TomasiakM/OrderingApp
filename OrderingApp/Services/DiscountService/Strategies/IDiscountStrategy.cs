using OrderingApp.Models;

namespace OrderingApp.Services.DiscountService.Strategies;
public interface IDiscountStrategy
{
    void ApplyDiscount(Order order);
}
