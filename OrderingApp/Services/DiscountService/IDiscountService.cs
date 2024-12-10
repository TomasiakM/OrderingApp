using OrderingApp.Models;

namespace OrderingApp.Services.DiscountService;
public interface IDiscountService
{
    void Calculate(Order order);
}
