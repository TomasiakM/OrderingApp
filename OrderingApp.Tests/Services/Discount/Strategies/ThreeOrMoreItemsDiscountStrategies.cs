using OrderingApp.Models;
using OrderingApp.Services.Discount.Strategies;
using OrderingApp.Tests.TestUtils;

namespace OrderingApp.Tests.Services.Discount.Strategies;
public class ThreeOrMoreItemsDiscountStrategies
{
    [Fact]
    public void ShouldApplyDiscount()
    {
        var product = new Product("Name", 10m, 4);
        var orderItem = new OrderItem(product, 3);
        var order = new Order(new() { orderItem }, new TestDiscountService());

        var strategy = new ThreeOrMoreItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.NotEqual(0, orderItem.Discount);
    }

    [Fact]
    public void ShouldApplyDiscount2()
    {
        var product = new Product("Name", 15m, 4);
        var product2 = new Product("Name2", 10m, 4);
        var orderItem = new OrderItem(product, 1);
        var orderItem2 = new OrderItem(product2, 2);
        var order = new Order(new() { orderItem, orderItem2 }, new TestDiscountService());

        var strategy = new ThreeOrMoreItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.Equal(0, orderItem.Discount);
        Assert.NotEqual(0, orderItem2.Discount);
    }

    [Fact]
    public void ShouldApplyDiscount3()
    {
        var product = new Product("Name", 10m, 4);
        var product2 = new Product("Name2", 15m, 4);
        var product3 = new Product("Name3", 15m, 4);
        var orderItem = new OrderItem(product, 3);
        var orderItem2 = new OrderItem(product2, 3);
        var orderItem3 = new OrderItem(product3, 3);

        var order = new Order(new() { orderItem, orderItem2, orderItem3 }, new TestDiscountService());

        var strategy = new ThreeOrMoreItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.NotEqual(0, orderItem.Discount);
        Assert.Equal(0, orderItem2.Discount);
        Assert.Equal(0, orderItem3.Discount);
    }

    [Fact]
    public void ShouldNotApplyDiscount_WhenSumOfOrderItemsQuantity_IsLessThanThree()
    {
        var product = new Product("Name", 10m, 4);
        var orderItem = new OrderItem(product, 2);

        var order = new Order(new() { orderItem }, new TestDiscountService());

        var strategy = new ThreeOrMoreItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.Equal(0, orderItem.Discount);
    }

    [Fact]
    public void ShouldNotApplyDiscount_WhenSumOfOrderItemsQuantity_IsLessThanThree2()
    {
        var product = new Product("Name", 10m, 4);
        var product2 = new Product("Name", 10m, 4);
        var orderItem = new OrderItem(product, 1);
        var orderItem2 = new OrderItem(product2, 1);

        var order = new Order(new() { orderItem, orderItem2 }, new TestDiscountService());

        var strategy = new ThreeOrMoreItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.Equal(0, orderItem.Discount);
        Assert.Equal(0, orderItem2.Discount);
    }
}
