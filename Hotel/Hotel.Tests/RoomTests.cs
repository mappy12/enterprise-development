using Hotel.Domain.Data;
using Hotel.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

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
}