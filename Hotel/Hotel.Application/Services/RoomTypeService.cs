using Hotel.Application.Contracts.RoomTypes;
using Hotel.Domain;
using Hotel.Domain.Entities;

namespace Hotel.Application.Services;

/// <summary>
/// Служба работы с типами номеров
/// </summary>
public class RoomTypeService : IRoomTypeService
{
    /// <summary>
    /// Репозиторий для работы с типами номеров
    /// </summary>
    private readonly IRepository<RoomType, int> _repository;

    /// <summary>
    /// Инициализация службы
    /// </summary>
    public RoomTypeService(IRepository<RoomType, int> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Получить все типы номеров
    /// </summary>
    public IReadOnlyList<RoomTypeDto> GetAll()
    {
        return _repository.GetAll()
            .Select(ToDto)
            .ToList();
    }

    /// <summary>
    /// Получить тип номера по идентификатору
    /// </summary>
    public RoomTypeDto? GetById(int id)
    {
        var roomType = _repository.GetById(id);

        return roomType is null ? null : ToDto(roomType);
    }

    /// <summary>
    /// Создать тип номера
    /// </summary>
    public RoomTypeDto Create(CreateRoomTypeDto dto)
    {
        var roomTypes = _repository.GetAll();

        var newId = roomTypes.Count == 0
            ? 1
            : roomTypes.Max(roomType => roomType.Id) + 1;

        var roomType = new RoomType
        {
            Id = newId,
            Category = dto.Category,
            Area = dto.Area,
            BedCount = dto.BedCount,
            HasBathroom = dto.HasBathroom,
            PricePerDay = dto.PricePerDay
        };

        return ToDto(_repository.Add(roomType));
    }

    /// <summary>
    /// Обновить тип номера
    /// </summary>
    public RoomTypeDto? Update(int id, CreateRoomTypeDto dto)
    {
        var roomType = new RoomType
        {
            Id = id,
            Category = dto.Category,
            Area = dto.Area,
            BedCount = dto.BedCount,
            HasBathroom = dto.HasBathroom,
            PricePerDay = dto.PricePerDay
        };

        var updatedRoomType = _repository.Update(roomType);

        return updatedRoomType is null ? null : ToDto(updatedRoomType);
    }

    /// <summary>
    /// Удалить тип номера
    /// </summary>
    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }

    /// <summary>
    /// Преобразовать доменную сущность в DTO
    /// </summary>
    private static RoomTypeDto ToDto(RoomType roomType)
    {
        return new RoomTypeDto(
            roomType.Id,
            roomType.Category,
            roomType.Area,
            roomType.BedCount,
            roomType.HasBathroom,
            roomType.PricePerDay
        );
    }
}