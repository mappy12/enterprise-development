namespace Hotel.Application.Contracts.Bookings;

/// <summary>
/// DTO для создания бронирования
/// </summary>
public record CreateBookingDto(
    int ClientId,
    int RoomId,
    DateOnly CheckInDate,
    int DaysCount
);