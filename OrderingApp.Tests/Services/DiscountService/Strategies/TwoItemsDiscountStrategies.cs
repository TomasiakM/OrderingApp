using OrderingApp.Models;
using OrderingApp.Services.DiscountService.Strategies;
using OrderingApp.Tests.TestUtils;

namespace OrderingApp.Tests.Services.DiscountService.Strategies;
public class TwoItemsDiscountStrategies
{
    [Fact]
    public void ShouldApplyDiscount()
    {
        var product = new Product("Name", 10m, 4);
        var orderItem = new OrderItem(product, 2);
        var order = new Order(new() { orderItem }, new TestDiscountService());

        var strategy = new TwoItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.NotEqual(0, orderItem.Discount);
    }

    [Fact]
    public void ShouldApplyDiscount_ToCheapestOrderItem()
    {
        var product = new Product("Name", 10m, 4);
        var product2 = new Product("Name", 12m, 4);
        var orderItem = new OrderItem(product, 1);
        var orderItem2 = new OrderItem(product2, 1);
        var order = new Order(new() { orderItem, orderItem2 }, new TestDiscountService());

        var strategy = new TwoItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.NotEqual(0, orderItem.Discount);
        Assert.Equal(0, orderItem2.Discount);
    }

    [Fact]
    public void ShouldNotApplyDiscount_ToOrderWithOneItemQuantity()
    {
        var product = new Product("Name", 10m, 4);
        var orderItem = new OrderItem(product, 1);
        var order = new Order(new() { orderItem }, new TestDiscountService());

        var strategy = new TwoItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.Equal(0, orderItem.Discount);
    }

    [Fact]
    public void ShouldNotApplyDiscount_ToOrderWithMoreThanTwoItemsQuantity()
    {
        var product = new Product("Name", 10m, 4);
        var orderItem = new OrderItem(product, 3);
        var order = new Order(new() { orderItem }, new TestDiscountService());

        var strategy = new TwoItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.Equal(0, orderItem.Discount);
    }

    [Fact]
    public void ShouldNotApplyDiscount_ToOrderWithMoreThanTwoItemsQuantity2()
    {
        var product = new Product("Name", 10m, 4);
        var product2 = new Product("Name2", 100m, 4);
        var orderItem = new OrderItem(product, 2);
        var orderItem2 = new OrderItem(product2, 1);
        var order = new Order(new() { orderItem, orderItem2 }, new TestDiscountService());

        var strategy = new TwoItemsDiscountStrategy();
        strategy.ApplyDiscount(order);

        Assert.Equal(0, orderItem.Discount);
        Assert.Equal(0, orderItem2.Discount);
    }
}
