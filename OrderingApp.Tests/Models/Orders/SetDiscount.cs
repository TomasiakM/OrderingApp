using OrderingApp.Exceptions;
using OrderingApp.Models;
using OrderingApp.Tests.TestUtils;

namespace OrderingApp.Tests.Models.Orders;
public class SetDiscount
{
    [Fact]
    public void ShouldSetDiscount()
    {
        var product = new Product("Name", 2m, 5) { Id = 1 };
        var orderItem = new OrderItem(product, 1);
        var order = new Order(new() { orderItem }, new TestDiscountService());
        var discount = 2m;

        order.SetDiscount(discount);

        Assert.Equal(discount, order.Discount);
    }

    [Fact]
    public void ShouldThrowException_WhenDiscountIsNegative()
    {
        var product = new Product("Name", 2m, 5) { Id = 1 };
        var orderItem = new OrderItem(product, 1);
        var order = new Order(new() { orderItem }, new TestDiscountService());
        var discount = -1m;

        Assert.Throws<DomainException>(() => order.SetDiscount(discount));
    }
}
