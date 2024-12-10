using OrderingApp.Exceptions;
using OrderingApp.Models;

namespace OrderingApp.Tests.Models.Products;
public class Constructor
{
    [Fact]
    public void ShouldCreateValidObject()
    {
        var name = "Test";
        var price = 22.22m;
        var stock = 5;

        var product = new Product(name, price, stock);

        Assert.Equal(name, product.Name);
        Assert.Equal(price, product.Price);
        Assert.Equal(stock, product.Stock);
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void ShouldThrowError_WhenAnyPropertyIsInvalid(string name, decimal price, int stock)
    {
        Assert.Throws<DomainException>(() => new Product(name, price, stock));
    }

    public static IEnumerable<object[]> TestCases()
    {
        yield return new object[] { "", 2m, 1 };
        yield return new object[] { "Test", -2m, 1 };
        yield return new object[] { "Test", 2m, -1 };
    }
}
