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

}
