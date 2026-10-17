using Hotel.Domain.Shared.Enums;

namespace Hotel.Application.Contracts.RoomTypes;

/// <summary>
/// DTO для создания типа номера
/// </summary>
public record CreateRoomTypeDto(
    RoomCategory Category,
    double Area,
    int BedCount,
    bool HasBathroom,
    decimal PricePerDay
);
