using OrderingApp.Exceptions;
using OrderingApp.Models;

namespace OrderingApp.Tests.Models.Products;
public class DecreaseStock
{
    [Fact]
    public void DecreaseStock_ShouldDecreaseProductStore()
    {
        var product = new Product("1", 20m, 1);

        product.DecreaseStock(1);

        Assert.Equal(0, product.Stock);
    }

    [Fact]
    public void DecreaseStock_ShouldThrowException_WhenStockIsNegative()
    {
        var product = new Product("1", 20m, 1);

        Assert.Throws<DomainException>(() => product.DecreaseStock(2));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void DecreaseStock_ShouldThrowException_WhenAmountIsNegative(int amount)
    {
        var product = new Product("1", 20m, 1);

        Assert.Throws<DomainException>(() => product.DecreaseStock(amount));
    }
}
