using OrderingApp.Services.Cart;
using OrderingApp.Services.Products;

namespace OrderingApp.Views;
public sealed class MainView : IView
{
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public MainView()
    {
        _productService = new ProductsService();
        _cartService = new CartService(_productService);
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz opcję: ");

            Console.WriteLine("1 - Dodaj produkt");
            Console.WriteLine("2 - Usuń produkt");
            Console.WriteLine("3 - Zobacz zamówienie");
            Console.WriteLine("0 - Wyjście");

            var read = Console.ReadLine();

            IView selectedView = new MainView();
            switch (read)
            {
                case "1":
                    selectedView = new AddProductView(_cartService, _productService);
                    break;
                case "2":
                    selectedView = new DeleteProductView(_cartService);
                    break;
                case "3":
                    selectedView = new ShowOrderView(_cartService);
                    break;
                case "0":
                    return;
                default:
                    continue;
            }

            selectedView.Show();
        }
    }
}
