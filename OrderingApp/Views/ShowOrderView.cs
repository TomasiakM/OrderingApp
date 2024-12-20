﻿using OrderingApp.Models;
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

            var itemsInCart = _cartService.GetItems();
            if (!itemsInCart.Any())
            {
                Console.WriteLine("Koszyka jest pusty, nie można wyświetlić zamówienia");
                Console.Read();

                return;
            }

            var order = _cartService.CreateOrder();

            Console.WriteLine("Twoje zamówienie: ");
            PrintOrderItems(order);

            Console.WriteLine("Ilość przedmiotów w zamówieniu: {0}, Wartość całego zamówienia (obniżka całości zamówienia: {1}): {2}",
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
            Console.WriteLine("Id produktu: {0} Nazwa: {1}, Cena: {2}, Ilość: {3}, Wartość towaru (obniżka produktu: {4}): {5}",
                item.ProductId, item.Price, item.Quantity, item.Discount, item.GetTotalOrderItemValue());
        }
    }
}
