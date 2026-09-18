using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests;

/// <summary>
/// Тесты для операций с заказами службы доставки еды
/// </summary>
public class OrderTests
{
    /// <summary>
    /// Вывести список заказов с минимальным временем доставки.
    /// </summary>
    [Fact]
    public void GetOrdersByMinDeliveryTime()
    {
        var orders = FoodDeliveryData.Orders;

        var minDeliveryTime = orders
            .Min(order => order.DeliveryTime - order.OrderTime);

        var result = orders
            .Where(order => order.DeliveryTime - order.OrderTime == minDeliveryTime)
            .Select(order => order.Id)
            .OrderBy(id => id)
            .ToList();

        Assert.Equal(20, minDeliveryTime.TotalMinutes);
        Assert.Equal([7, 12, 19], result);
    }


    /// <summary>
    /// Вывести сводную информацию о заказах (число заказов, средняя сумма заказа,
    /// общая сумма заказа) по каждой категории блюд за указанный период. 
    /// </summary>
    [Fact]
    public void GetCategorySalesStats()
    {
        var expected = new[]
        {
            new { CategoryId = 1, OrderCount = 3, AverageOrderAmount = 683.33m, TotalOrderAmount = 2050m },
            new { CategoryId = 2, OrderCount = 3, AverageOrderAmount = 950.00m, TotalOrderAmount = 2850m },
            new { CategoryId = 8, OrderCount = 2, AverageOrderAmount = 700.00m, TotalOrderAmount = 1400m }
        };

        var startDate = new DateTime(2026, 9, 1);
        var endDate = new DateTime(2026, 9, 7);

        var result = FoodDeliveryData.Categories
            .Select(category => new
            {
                Category = category,
                Orders = FoodDeliveryData.Orders
                    .Where(order =>
                        order.OrderTime >= startDate &&
                        order.OrderTime < endDate &&
                        order.Dishes.Any(dish => dish.Category == category))
                    .ToList()
            })
            .Where(x => x.Orders.Count > 0)
            .Select(x => new
            {
                Category = x.Category,
                OrderCount = x.Orders.Count,
                AverageOrderAmount = x.Orders.Average(order => order.TotalAmount),
                TotalOrderAmount = x.Orders.Sum(order => order.TotalAmount)
            })
            .OrderBy(x => x.Category.Id)
            .ToList();

        var actual = result
            .Select(x => new
            {
                CategoryId = x.Category.Id,
                x.OrderCount,
                AverageOrderAmount = Math.Round(x.AverageOrderAmount, 2),
                x.TotalOrderAmount
            })
            .ToArray();

        Assert.Equal(expected, actual);
    }
}