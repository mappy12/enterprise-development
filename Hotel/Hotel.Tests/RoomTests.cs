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

    [Fact]
    public void GetTopFiveMostBookedRooms()
    {
        var expected = new List<int>
        {
            101,
            102,
            201,
            202,
            301
        };

        var result = HotelData.Bookings
            .GroupBy(booking => booking.Room)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key.RoomNumber)
            .Take(5)
            .Select(group => group.Key.RoomNumber)
            .ToList();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetBookingCountForEachRoom()
    {
        var expected = new Dictionary<int, int>
        {
            [101] = 3,
            [102] = 2,
            [201] = 2,
            [202] = 2,
            [301] = 2,
            [302] = 2,
            [401] = 2,
            [402] = 2,
            [501] = 2,
            [502] = 1,
        };

        var result = HotelData.Bookings
            .GroupBy(booking => booking.Room)
            .ToDictionary(
                group => group.Key.RoomNumber,
                group => group.Count());

        Assert.Equal(expected, result);
    }
}