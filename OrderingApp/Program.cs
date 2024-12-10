// See https://aka.ms/new-console-template for more information
using OrderingApp.Models;
using OrderingApp.Services.DiscountService;

// { id: { product, quantity }}
var cart = new Dictionary<int, Tuple<Product, int>>();
while (true)
{
    Console.Clear();
    Console.WriteLine("Wybierz opcję: ");

    Console.WriteLine("1 - Dodaj produkt");
    Console.WriteLine("2 - Usuń produkt");
    Console.WriteLine("3 - Zobacz zamówienie");
    Console.WriteLine("0 - Wyjście");

    var read = Console.ReadLine();
    switch (read)
    {
        case "1":
            AddProductView();
            break;
        case "2":
            DeleteProductView();
            break;
        case "3":
            ShowOrderView();
            break;
        case "0":
            return;
    }
}

void AddProductView()
{
    try
    {
        Console.Clear();

        Console.WriteLine("Wpisz nazwę nowego produktu:");
        var name = Console.ReadLine() ?? "";

        Console.WriteLine("Podaj cene produktu:");
        var price = decimal.Parse(Console.ReadLine() ?? "");

        Console.WriteLine("Podaj ilość produktu w magazynie:");
        var stock = int.Parse(Console.ReadLine() ?? "");

        Console.WriteLine("Podaj ilość produktu do kupienia:");
        var quantity = int.Parse(Console.ReadLine() ?? "");

        var id = 1;
        if (cart.Count > 0)
        {
            id = cart.Last().Key + 1;
        }

        var product = new Product(name, price, stock) { Id = id };
        cart.Add(id, new(product, quantity));
    }
    catch (Exception ex)
    {
        Console.WriteLine("Nastąpił błąd podczas tworzenia produktu: " + ex.Message);
        Console.Read();
    }
}

void DeleteProductView()
{
    try
    {
        Console.Clear();

        Console.WriteLine("Wpisz id produktu do usunięcia:");
        var id = int.Parse(Console.ReadLine() ?? "");

        if (cart.TryGetValue(id, out var value))
        {
            var productDictionary = cart.FirstOrDefault(e => e.Key == id);
            cart.Remove(productDictionary.Key);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nie znaleziono tego produktu");
            Console.Read();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Nastąpił błąd podczas tworzenia produktu: " + ex.Message);
        Console.Read();
    }
}

void ShowOrderView()
{
    try
    {
        Console.Clear();
        var orderItems = cart
            .Select(e => new OrderItem(e.Value.Item1, e.Value.Item2))
            .ToList();

        var order = new Order(orderItems, new DiscountService());


        Console.WriteLine("Twoje zamówienie: ");

        foreach (var item in orderItems)
        {
            Console.WriteLine("Id produktu: {0}, Cena: {1}, Ilość: {2}, Wartość towaru (z uwzględnieniem obniżki {3}): {4}",
                item.ProductId,
                item.Price,
                item.Quantity,
                item.Discount,
                item.GetTotalOrderItemValue());
        }

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