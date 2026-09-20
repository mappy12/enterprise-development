using Hotel.Domain.Data;
using Hotel.Domain.Shared;

namespace Hotel.Tests;

public class ClientTests
{
    [Fact]
    public void GetClientsByRoomType()
    {
        var roomCategory = RoomCategory.Standard;

        var expected = new List<string>
        {
            "Dmitry Smirnov",
            "Elena Kuznetsova",
            "Ivan Popov",
            "Maria Sokolova"
        };

        var result = HotelData.Bookings
            .Where(booking => booking.Room.RoomType.Category == roomCategory)
            .Select(booking => booking.Client.FullName)
            .Distinct()
            .OrderBy(name => name)
            .ToList();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetTopFiveClientsByTotalStayCost()
    {
        var expected = new List<string>
        {
            "Pavel Volkov",
            "Sofia Orlova",
            "Nikolay Fedorov",
            "Ivan Popov",
            "Maria Sokolova"
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
            .ThenBy(item => item.Client.FullName)
            .Take(5)
            .Select(item => item.Client.FullName)
            .ToList();

        Assert.Equal(expected, result);
    }
    
    
}
