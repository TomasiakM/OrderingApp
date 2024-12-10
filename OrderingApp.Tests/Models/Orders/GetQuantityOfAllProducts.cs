using OrderingApp.Models;
using OrderingApp.Tests.TestUtils;

namespace OrderingApp.Tests.Models.Orders;
public class GetQuantityOfAllProducts
{
    [Fact]
    public void ShouldReturnValidQuantity()
    {
        var product = new Product("Name", 2m, 5) { Id = 1 };
        var orderItem = new OrderItem(product, 1);

        var order = new Order(new() { orderItem }, new TestDiscountService());

        Assert.Equal(1, order.GetQuantityOfAllProducts());
    }

    [Fact]
    public void ShouldReturnValidQuantity2()
    {
        var product = new Product("Name", 2m, 5) { Id = 1 };
        var product2 = new Product("Name2", 2m, 5) { Id = 2 };
        var orderItem = new OrderItem(product, 3);
        var orderItem2 = new OrderItem(product2, 2);

        var order = new Order(new() { orderItem, orderItem2 }, new TestDiscountService());

        Assert.Equal(5, order.GetQuantityOfAllProducts());
    }
}
