namespace OrderingApp.Features.AddProduct;
public sealed record AddProductCommand(
    string Name,
    decimal Price,
    int Stock);
