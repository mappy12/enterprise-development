using Hotel.Application.Contracts.Bookings;
using Hotel.Domain;
using Hotel.Domain.Entities;

namespace Hotel.Application.Services;

/// <summary>
/// Служба работы с бронированиями гостиницы
/// </summary>
public class BookingService : IBookingService
{
    /// <summary>
    /// Репозиторий бронирований
    /// </summary>
    private readonly IRepository<Booking, int> _bookingRepository;

    /// <summary>
    /// Репозиторий клиентов
    /// </summary>
    private readonly IRepository<HotelClient, int> _clientRepository;

    /// <summary>
    /// Репозиторий номеров
    /// </summary>
    private readonly IRepository<Room, int> _roomRepository;

    /// <summary>
    /// Инициализация службы
    /// </summary>
    public BookingService (
        IRepository<Booking, int> bookingRepository,
        IRepository<HotelClient, int> clientRepository,
        IRepository<Room, int> roomRepository)

    {
        _bookingRepository = bookingRepository;
        _clientRepository = clientRepository;
        _roomRepository = roomRepository;
    }

    /// <summary>
    /// Получить все бронирования
    /// </summary>
    public IReadOnlyList<BookingDto> GetAll()
    {
        return _bookingRepository.GetAll()
            .Select(ToDto)
            .ToList();
    }

    /// <summary>
    /// Получить бронирование по идентификатору
    /// </summary>
    public BookingDto? GetById(int id)
    {
        var booking = _bookingRepository.GetById(id);
        return booking is null ? null : ToDto(booking);
    }

    /// <summary>
    /// Создать бронирование
    /// </summary>
    public BookingDto Create(CreateBookingDto dto)
    {
        var client = _clientRepository.GetById(dto.ClientId);

        if (client is null) throw new ArgumentException(
            $"Не удалось найти клиента с идентификатором {dto.ClientId}");

        var room = _roomRepository.GetById(dto.RoomId);

        if (room is null) throw new ArgumentException(
            $"Не удалось найти номер с идентификатором {dto.RoomId}");

        var bookings = _bookingRepository.GetAll();

        var newId = bookings.Count == 0
            ? 1
            : bookings.Max(booking => booking.Id) + 1;

        var booking = new Booking
        {
            Id = newId,
            Client = client,
            Room = room,
            CheckInDate = dto.CheckInDate,
            DaysCount = dto.DaysCount
        };

        return ToDto(_bookingRepository.Add(booking));
    }

    /// <summary>
    /// Обновить бронирование
    /// </summary>
    public BookingDto? Update(int id, CreateBookingDto dto)
    {
        var existingBooking = _bookingRepository.GetById(id);

        if (existingBooking is null) return null;

        var client = _clientRepository.GetById(dto.ClientId);

        if (client is null) throw new ArgumentException(
            $"Не удалось найти клиента с идентификатором {dto.ClientId}");

        var room = _roomRepository.GetById(dto.RoomId);

        if (room is null) throw new ArgumentException(
            $"Не удалось найти номер с идентификатором {dto.RoomId}");

        var booking = new Booking
        {
            Id = id,
            Client = client,
            Room = room,
            CheckInDate = dto.CheckInDate,
            DaysCount = dto.DaysCount
        };

        var updatedBooking = _bookingRepository.Update(booking);

        return updatedBooking is null ? null : ToDto(updatedBooking);
    }

    /// <summary>
    /// Удалить бронирование
    /// </summary>
    public bool Delete(int id)
    {
        return _bookingRepository.Delete(id);
    }

    /// <summary>
    /// Получить текущие бронирования
    /// </summary>
    public IReadOnlyList<BookingDto> GetBookedRooms()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        return _bookingRepository.GetAll()
            .Where(booking =>
                booking.CheckInDate <= today &&
                booking.CheckInDate.AddDays(booking.DaysCount) > today)
            .Select(ToDto)
            .ToList();
    }

    /// <summary>
    /// Преобразовать доменную сущность в DTO
    /// </summary>
    private static BookingDto ToDto(Booking booking)
    {
        return new BookingDto(
            booking.Id,
            booking.Client.Id,
            booking.Room.Id,
            booking.CheckInDate,
            booking.DaysCount
        );
    }
}