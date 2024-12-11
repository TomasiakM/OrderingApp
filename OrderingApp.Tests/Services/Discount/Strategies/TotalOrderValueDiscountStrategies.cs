using OrderingApp.Models;
using OrderingApp.Services.Discount.Strategies;
using OrderingApp.Tests.TestUtils;

namespace OrderingApp.Tests.Services.Discount.Strategies;
public class TotalOrderValueDiscountStrategies
{
    [Fact]
    public void ShouldApplyDiscoundToOrder()
    {
        var product = new Product("Name", 5000.1m, 4);
        var orderItem = new OrderItem(product, 1);
        var order = new Order(new() { orderItem }, new TestDiscountService());

        var strategy = new TotalOrderValueDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.NotEqual(0, order.Discount);
    }

    [Fact]
    public void ShouldApplyDiscoundToOrder2()
    {
        var product = new Product("Name", 2500.1m, 4);
        var product2 = new Product("Name2", 2500.1m, 4);
        var orderItem = new OrderItem(product, 1);
        var orderItem2 = new OrderItem(product2, 1);
        var order = new Order(new() { orderItem, orderItem2 }, new TestDiscountService());

        var strategy = new TotalOrderValueDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.NotEqual(0, order.Discount);
    }

    [Fact]
    public void ShouldNotApplyDiscoundToOrder_WhenTotalOrderValueIsLessThanOrEqual5000()
    {
        var product = new Product("Name", 5000, 4);
        var orderItem = new OrderItem(product, 1);
        var order = new Order(new() { orderItem }, new TestDiscountService());

        var strategy = new TotalOrderValueDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.Equal(0, order.Discount);
    }

    [Fact]
    public void ShouldNotApplyDiscoundToOrder_WhenTotalOrderValueIsLessThanOrEqual5000_2()
    {
        var product = new Product("Name", 2500m, 4);
        var product2 = new Product("Name2", 2500m, 4);
        var orderItem = new OrderItem(product, 1);
        var orderItem2 = new OrderItem(product2, 1);
        var order = new Order(new() { orderItem, orderItem2 }, new TestDiscountService());

        var strategy = new TotalOrderValueDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.Equal(0, order.Discount);
    }
}
