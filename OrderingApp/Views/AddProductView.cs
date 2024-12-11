using OrderingApp.Services.Cart;
using OrderingApp.Services.Products;

namespace OrderingApp.Views;
internal sealed class AddProductView : IView
{
    private readonly ICartService _cartService;
    private readonly IProductService _productService;

    public AddProductView(ICartService cartService, IProductService productService)
    {
        _cartService = cartService;
        _productService = productService;
    }

    public void Show()
    {
        try
        {
            Console.Clear();
            ShowAllProducts();

            Console.WriteLine("Wybirz id produktu do dodania:");
            var id = int.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Wybirz ilość produktu:");
            var quantity = int.Parse(Console.ReadLine() ?? "");

            _cartService.AddProduct(id, quantity);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nastąpił błąd podczas tworzenia produktu: " + ex.Message);
            Console.Read();
        }
    }

    private void ShowAllProducts()
    {
        foreach (var product in _productService.GetAll())
        {
            Console.WriteLine("Id produkutu: {0} Nazwa: {1} Cena: {2} Ilość w magazynie {3}",
                product.Id, product.Name, product.Price, product.Stock);
        }
    }
}
