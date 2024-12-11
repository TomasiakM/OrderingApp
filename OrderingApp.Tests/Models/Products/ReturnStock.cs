using OrderingApp.Exceptions;
using OrderingApp.Models;

namespace OrderingApp.Tests.Models.Products;
public class ReturnStock
{
    [Fact]
    public void ReturnStock_ShouldReturnProductStock()
    {
        var stock = 7;
        var amount = 5;
        var product = new Product("1", 20m, stock);

        product.ReturnStock(amount);

        Assert.Equal(stock + amount, product.Stock);
    }

    [Fact]
    public void ReturnStock_ShouldThrowError_WhenAmountIsLessThanOrEqualTo0()
    {
        var product = new Product("1", 20m, 7);

        Assert.Throws<DomainException>(() => product.ReturnStock(0));
        Assert.Throws<DomainException>(() => product.ReturnStock(-1));
    }
}
