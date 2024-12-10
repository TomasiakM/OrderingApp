using OrderingApp.Exceptions;

namespace OrderingApp.Models;
public class Product
{
    public int Id { get; init; }
    public string Name { get; private set; }
    public int Stock { get; private set; }
    public decimal Price { get; private set; }

    public virtual List<OrderItem> OrderItems { get; private set; } = new();

    public Product(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;

        ValidateProduct();
    }

    public void DecreaseStock(int amount)
    {
        if (amount <= 0)
        {
            throw new DomainException("Amount to decress cannot be less than or equal to 0");
        }

        Stock -= amount;

        ValidateProduct();
    }

    private void ValidateProduct()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new DomainException("Product name cannot be empty");
        }

        if (Price <= 0)
        {
            throw new DomainException("Product price cannot be less or equal to 0");
        }

        if (Stock < 0)
        {
            throw new DomainException("Product stock cannot be negative");
        }
    }
}
