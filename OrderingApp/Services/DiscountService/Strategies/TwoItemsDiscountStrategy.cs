﻿using OrderingApp.Models;

namespace OrderingApp.Services.DiscountService.Strategies;
internal sealed class TwoItemsDiscountStrategy : IDiscountStrategy
{
    private const decimal Discount = 0.1m;

    public void ApplyDiscount(Order order)
    {
        if (order.Items.Count == 2)
        {
            var cheapest = order.Items.OrderBy(e => e.Price).First();
            cheapest.SetDiscount(cheapest.Price * Discount);
        }
    }
}
