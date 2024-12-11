using OrderingApp.Models;

namespace OrderingApp.Services.Discount.Strategies;
public interface IDiscountStrategy
{
    void ApplyDiscount(Order order);
}
