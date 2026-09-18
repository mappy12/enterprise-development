using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests;

public class FoodDeliveryTests
{
    [Fact]
    public void GetTopFiveRestaurantsByOrderCount()
    {
        var orders = FoodDeliveryData.Orders;

        var result = orders
            .GroupBy(order => order.Restaurant)
            .Select(group => new
            {
                Restaurant = group.Key,
                OrderCount = group.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .ThenBy(x => x.Restaurant.Id)
            .Take(5)
            .ToList();

        Assert.Equal(5, result.Count);

        Assert.Equal("Burger House", result[0].Restaurant.Name);
        Assert.Equal(6, result[0].OrderCount);

        Assert.Equal("Pizza Time", result[1].Restaurant.Name);
        Assert.Equal(4, result[1].OrderCount);

        Assert.Equal("Sushi World", result[2].Restaurant.Name);
        Assert.Equal(3, result[2].OrderCount);

        Assert.Equal(1, result[3].OrderCount);
        Assert.Equal(1, result[4].OrderCount);

    }

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

    [Fact]
    public void GetClientsByRestaurant()
    {
        var expected = new List<string>
        {
            "Alexey Ivanov",
            "Anna Petrova",
            "Dmitry Smirnov",
            "Ivan Popov",
            "Nikolay Fedorov",
            "Pavel Volkov"
        };

        var restaurant = FoodDeliveryData.Restaurants
            .First(r => r.Name == "Burger House");

        var result = FoodDeliveryData.Orders
            .Where(order => order.Restaurant == restaurant)
            .Select(order => order.Client)
            .Distinct()
            .OrderBy(client => client.FullName)
            .Select(client => client.FullName)
            .ToList();

        Assert.Equal(expected, result);
    }

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