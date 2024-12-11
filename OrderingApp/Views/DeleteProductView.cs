using OrderingApp.Services.Cart;

namespace OrderingApp.Views;
internal sealed class DeleteProductView : IView
{
    private readonly ICartService _cartService;
    public DeleteProductView(ICartService cartService)
    {
        _cartService = cartService;
    }

    public void Show()
    {
        try
        {
            Console.Clear();

            Console.WriteLine("Wpisz id produktu do usunięcia:");
            var id = int.Parse(Console.ReadLine() ?? "");

            _cartService.DeleteProduct(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nastąpił błąd podczas tworzenia produktu: " + ex.Message);
            Console.Read();
        }
    }
}
