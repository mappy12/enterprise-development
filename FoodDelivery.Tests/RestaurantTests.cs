using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests;

/// <summary>
/// Тесты для операций с ресторанами службы доставки еды
/// </summary>
public class RestaurantTests
{
    /// <summary>
    /// Вывести топ 5 ресторанов по количеству заказов
    /// </summary>
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
}