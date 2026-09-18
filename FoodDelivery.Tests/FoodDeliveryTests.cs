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
            .ToList();

        Assert.Equal(expected, result);
    }
}