using Moq;
using OrderingApp.Models;
using OrderingApp.Services.Discount;
using OrderingApp.Tests.TestUtils;

namespace OrderingApp.Tests.Models.Orders;
public class Constructor
{
    [Fact]
    public void ShouldCreateValidOrder()
    {
        var product = new Product("Name", 2m, 4);
        var orderItem = new OrderItem(product, 1);
        var order = new Order(new() { orderItem }, new TestDiscountService());

        Assert.Single(order.Items);
    }

    [Fact]
    public void ShouldInvokeDiscountServiceCalculateMethod()
    {
        var product = new Product("Name", 2m, 4);
        var orderItem = new OrderItem(product, 1);
        var discountServiceMock = new Mock<IDiscountService>();

        var order = new Order(new() { orderItem }, discountServiceMock.Object);

        discountServiceMock.Verify(e => e.Calculate(order), Times.Once);
    }
}
