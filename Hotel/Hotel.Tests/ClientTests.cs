using Hotel.Domain.Data;
using Hotel.Domain.Shared;

namespace Hotel.Tests;

/// <summary>
/// Тесты для операций с клиентами гостиницы
/// </summary>
public class ClientTests
{
    /// <summary>
    /// Проверяет получение клиентов, проживавших в номерах указанного типа,
    /// с сортировкой по полному имени
    /// </summary>
    [Theory]
    [InlineData(RoomCategory.Economy)]
    [InlineData(RoomCategory.Standard)]
    [InlineData(RoomCategory.Comfort)]
    [InlineData(RoomCategory.Luxury)]
    public void GetClientsByRoomType(RoomCategory roomCategory)
    {
        var expected = roomCategory switch
        {
            RoomCategory.Economy => new List<int> { 7, 4, 3 },
            RoomCategory.Standard => new List<int> { 7, 1, 8, 5, 6, 9 },
            RoomCategory.Comfort => new List<int> { 1, 4, 10, 2, 5, 3, 9},
            RoomCategory.Luxury => new List<int> { 1, 10, 2},
            _ => throw new ArgumentOutOfRangeException(nameof(roomCategory),
                $"Такая категория номера не поддерживается: {roomCategory}")
        };

        var result = HotelData.Bookings
            .Where(booking => booking.Room.RoomType.Category == roomCategory)
            .Select(booking => booking.Client)
            .Distinct()
            .OrderBy(client => client.LastName)
            .ThenBy(client => client.FirstName)
            .Select(client => client.Id)
            .ToList();

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Проверяет получение пяти клиентов с наибольшей общей стоимостью проживания
    /// </summary>
    [Fact]
    public void GetTopFiveClientsByTotalStayCost()
    {
        var expected = new List<int>
        {
            2,
            5,
            1,
            10,
            9,
        };

        var result = HotelData.Bookings
            .GroupBy(booking => booking.Client)
            .Select(group => new
            {
                Client = group.Key,
                TotalCost = group.Sum(booking =>
                    booking.DaysCount * booking.Room.RoomType.PricePerDay)
            })
            .OrderByDescending(item => item.TotalCost)
            .ThenBy(item => item.Client.LastName)
            .Take(5)
            .Select(item => item.Client.Id)
            .ToList();

        Assert.Equal(expected, result);
    }
}
