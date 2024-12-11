using OrderingApp.Models;

namespace OrderingApp.Services.Discount;
public interface IDiscountService
{
    void Calculate(Order order);
}
