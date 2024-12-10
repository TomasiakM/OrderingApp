using OrderingApp.Exceptions;
using OrderingApp.Models;

namespace OrderingApp.Tests.Models.OrderItems;
public class Constructor
{
    [Fact]
    public void ShouldCreateValidObject()
    {
        var product = new Product("2", 2m, 2) { Id = 5 };
        var orderItem = new OrderItem(product, 2);

        Assert.Equal(2, orderItem.Quantity);
        Assert.Equal(product.Price, orderItem.Price);
        Assert.Equal(product.Id, orderItem.ProductId);
        Assert.Equal(0m, orderItem.Discount);
    }

    [Fact]
    public void ShouldDecreseStockInProduct()
    {
        var product = new Product("2", 2m, 2);
        var orderItem = new OrderItem(product, 2);

        Assert.Equal(0, product.Stock);
    }

    [Fact]
    public void ShouldThrowError_WhenProductStockIsLessThanOrderAmount()
    {
        var product = new Product("2", 2m, 2);

        Assert.Throws<DomainException>(() => new OrderItem(product, 3));
    }

    [Fact]
    public void ShouldThrowError_WhenQuantityIsNegative()
    {
        var product = new Product("2", 2m, 2);

        Assert.Throws<DomainException>(() => new OrderItem(product, 0));
    }
}
