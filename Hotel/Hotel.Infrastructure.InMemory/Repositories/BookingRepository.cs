using Hotel.Application.Repositories;
using Hotel.Domain.Data;
using Hotel.Domain.Entities;

namespace Hotel.Infrastructure.InMemory.Repositories;

public class BookingRepository : IRepository<Booking>
{
    private readonly List<Booking> _bookings;

    public BookingRepository()
    {
        _bookings = HotelData.Bookings.ToList();
    }

    public IReadOnlyList<Booking> GetAll()
    {
        return _bookings.AsReadOnly();
    }

    public Booking? GetById(int id)
    {
        return _bookings.FirstOrDefault(booking => booking.Id == id);
    }

    public Booking Add(Booking booking)
    {
        _bookings.Add(booking);
        return booking;
    }

    public Booking? Update(Booking booking)
    {
        var index = _bookings.FindIndex(item => item.Id == booking.Id);

        if (index == -1) return null;
        _bookings[index] = booking;

        return booking;
    }

    public bool Delete(int id)
    {
        var booking = GetById(id);

        if (booking is null) return false;

        return _bookings.Remove(booking);
    }
}