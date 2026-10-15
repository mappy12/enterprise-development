namespace Hotel.Application.Contracts.Rooms;

/// <summary>
/// DTO для создания номера
/// </summary>
public record CreateRoomDto(
    int RoomNumber,
    int Floor,
    bool HasBalcony,
    int RoomTypeId
);