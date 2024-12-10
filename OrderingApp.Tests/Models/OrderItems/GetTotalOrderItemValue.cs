using OrderingApp.Models;

namespace OrderingApp.Tests.Models.OrderItems;
public class GetTotalOrderItemValue
{
    [Fact]
    public void ShouldReturnValidOrderItemValue()
    {
        var product = new Product("name", 5m, 5);
        var orderItem = new OrderItem(product, 1);

        orderItem.SetDiscount(1m);

        Assert.Equal(4m, orderItem.GetTotalOrderItemValue());
    }

    [Fact]
    public void ShouldReturnValidOrderItemValue2()
    {
        var product = new Product("name", 5m, 5);
        var orderItem = new OrderItem(product, 5);

        orderItem.SetDiscount(5m);

        Assert.Equal(20m, orderItem.GetTotalOrderItemValue());
    }
}
