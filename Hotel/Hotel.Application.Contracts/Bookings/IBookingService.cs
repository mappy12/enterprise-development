namespace Hotel.Application.Contracts.Bookings;

/// <summary>
/// Интерфейс для работы с бронированиями
/// </summary>
public interface IBookingService
    : ICrudService<BookingDto, CreateBookingDto, int>
{
}
