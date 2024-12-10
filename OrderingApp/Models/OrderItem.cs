using OrderingApp.Exceptions;

namespace OrderingApp.Models;
public class OrderItem
{
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal Discount { get; private set; }

    public int ProductId { get; private set; }
    public virtual Product? Product { get; private set; }

    public OrderItem(Product product, int quantity)
    {
        ProductId = product.Id;
        Price = product.Price;
        Quantity = quantity;

        if (quantity > product.Stock)
        {
            throw new DomainException("Product stocks are less than requested quantity");
        }

        ValidateOrderItem();

        product.DecreaseStock(quantity);
    }

    public void SetDiscount(decimal discount)
    {
        Discount = discount;

        ValidateOrderItem();
    }

    public decimal GetTotalOrderItemValue()
    {
        return Price * Quantity - Discount;
    }

    private void ValidateOrderItem()
    {
        if (Price <= 0)
        {
            throw new DomainException("Order item price cannot be less than or equal to 0");
        }

        if (Quantity <= 0)
        {
            throw new DomainException("Order item quantity cannot be less than or equal to 0");
        }

        if (Discount < 0)
        {
            throw new DomainException("Order discount cannot be negative");
        }
    }
}
