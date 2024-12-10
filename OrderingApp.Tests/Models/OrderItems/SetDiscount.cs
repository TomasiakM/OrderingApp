using OrderingApp.Exceptions;
using OrderingApp.Models;

namespace OrderingApp.Tests.Models.OrderItems;
public class SetDiscount
{
    [Fact]
    public void ShouldSetDiscount()
    {
        var product = new Product("2", 2m, 2);
        var orderItem = new OrderItem(product, 2);

        var discount = 1.1m;
        orderItem.SetDiscount(discount);

        Assert.Equal(discount, orderItem.Discount);
    }

    [Fact]
    public void ShouldThrowException_WhenDiscountIsNegative()
    {
        var product = new Product("2", 2m, 2);
        var orderItem = new OrderItem(product, 2);

        Assert.Throws<DomainException>(() => orderItem.SetDiscount(-1));
    }
}
