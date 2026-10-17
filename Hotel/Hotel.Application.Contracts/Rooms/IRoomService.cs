namespace Hotel.Application.Contracts.Rooms;

/// <summary>
/// Интерфейс для работы с номерами гостиницы
/// </summary>
public interface IRoomService
    : ICrudService<RoomDto, CreateRoomDto, int>
{
    /// <summary>
    /// Получить пять номеров с наибольшим количеством бронирований
    /// </summary>
    public IReadOnlyList<RoomBookingCountDto> GetTopFiveMostBookedRooms();

    /// <summary>
    /// Получить количество бронирований для каждого номера
    /// </summary>
    public IReadOnlyList<RoomBookingCountDto> GetBookingCountForEachRoom();
}
