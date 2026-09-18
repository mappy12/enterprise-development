using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests;

/// <summary> 
/// Тесты для операций с клиентами службы доставки еды
/// </summary>
public class ClientTests
{
    /// <summary>
    /// Вывести сведения обо всех клиентах,
    /// заказывавших в выбранном ресторане, упорядочить по ФИО.
    /// </summary>
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


    /// <summary>
    /// Вывести информацию о клиенте,
    /// который потратил на доставку наибольшую сумму за все время работы приложения.
    /// </summary>
    [Fact]
    public void GetClientWithMaxMoneySpending()
    {
        var orders = FoodDeliveryData.Orders;

        var result = orders
            .GroupBy(order => order.Client)
            .Select(group => new
            {
                Client = group.Key,
                TotalSpent = group.Sum(order => order.TotalAmount)
            })
            .OrderByDescending(x => x.TotalSpent)
            .First();

        Assert.Equal("Ivan Popov", result.Client.FullName);
        Assert.Equal(1950m, result.TotalSpent);
    }
}