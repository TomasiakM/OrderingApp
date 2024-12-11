using OrderingApp.Models;
using OrderingApp.Services.Cart;

namespace OrderingApp.Views;
internal sealed class ShowOrderView : IView
{
    private readonly ICartService _cartService;

    public ShowOrderView(ICartService cartService)
    {
        _cartService = cartService;
    }

    public void Show()
    {
        try
        {
            Console.Clear();

            var order = _cartService.CreateOrder();

            Console.WriteLine("Twoje zamówienie: ");
            PrintOrderItems(order);

            Console.WriteLine("Ilość przedmiotów w zamówieniu: {0}, Wartość całego zamówienia (z uwzględnieniem obniżki {1}): {2}",
                order.GetQuantityOfAllProducts(),
                order.Discount,
                order.GetTotalOrderValue());

            Console.Read();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nastąpił błąd podczas tworzenia produktu: " + ex.Message);
            Console.Read();
        }
    }

    private static void PrintOrderItems(Order order)
    {
        foreach (var item in order.Items)
        {
            Console.WriteLine("Id produktu: {0}, Cena: {1}, Ilość: {2}, Wartość towaru (z uwzględnieniem obniżki {3}): {4}",
                item.ProductId, item.Price, item.Quantity, item.Discount, item.GetTotalOrderItemValue());
        }
    }
}
