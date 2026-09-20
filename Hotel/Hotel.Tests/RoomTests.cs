using Hotel.Domain.Data;

namespace Hotel.Tests;

public class RoomTests
{
    [Fact]
    public void GetBookedRooms()
    {
        var currentDate = new DateTime(2026, 9, 10);

        var expected = new List<int>
        {
            101,
            302,
            402,
            501
        };

        var result = HotelData.Bookings
            .Where(booking =>
                booking.CheckInDate <= currentDate &&
                currentDate < booking.CheckInDate.AddDays(booking.DaysCount))
            .Select(booking => booking.Room.RoomNumber)
            .Distinct()
            .OrderBy(roomNumber => roomNumber)
            .ToList();

        Assert.Equal (expected, result);
    }
}