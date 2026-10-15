namespace Hotel.Application.Contracts.Rooms;

/// <summary>
/// Интерфейс для работы с номерами гостиницы
/// </summary>
public interface IRoomTypeService
    : ICrudService<RoomDto, CreateRoomDto, int>
{
}