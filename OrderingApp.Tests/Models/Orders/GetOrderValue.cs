using OrderingApp.Models;
using OrderingApp.Tests.TestUtils;

namespace OrderingApp.Tests.Models.Orders;
public class GetOrderValue
{
    [Fact]
    public void ShouldReturnValidOrderValue()
    {
        var product = new Product("Name", 2m, 5) { Id = 1 };
        var orderItem = new OrderItem(product, 1);

        var order = new Order(new() { orderItem }, new TestDiscountService());

        Assert.Equal(2m, order.GetOrderValue());
    }

    [Fact]
    public void ShouldReturnValidOrderValue2()
    {
        var product = new Product("Name", 2m, 5) { Id = 1 };
        var product2 = new Product("Name2", 5m, 5) { Id = 2 };
        var orderItem = new OrderItem(product, 1);
        var orderItem2 = new OrderItem(product2, 2);

        var order = new Order(new() { orderItem, orderItem2 }, new TestDiscountService());

        Assert.Equal(12m, order.GetOrderValue());
    }

    [Fact]
    public void ShouldReturnValidOrderValueWithDiscount()
    {
        var product = new Product("Name", 2m, 5) { Id = 1 };
        var orderItem = new OrderItem(product, 1);

        var order = new Order(new() { orderItem }, new TestDiscountService());
        order.SetDiscount(1m);

        Assert.Equal(1m, order.GetOrderValue());
    }

    [Fact]
    public void ShouldReturnValidOrderValueWithOrderItemDiscount()
    {
        var product = new Product("Name", 5m, 5) { Id = 1 };
        var orderItem = new OrderItem(product, 1);
        orderItem.SetDiscount(1);
        var order = new Order(new() { orderItem }, new TestDiscountService());

        Assert.Equal(4m, order.GetOrderValue());
    }
}
