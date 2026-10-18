using Hotel.Application.Repositories;
using Hotel.Domain.Data;
using Hotel.Domain.Entities;

namespace Hotel.Infrastructure.InMemory.Repositories;

/// <summary>
/// Репозиторий типов номеров в памяти
/// </summary>
public class RoomTypeRepository : IRepository<RoomType>
{
    /// <summary>
    /// Данные типов номеров гостницы
    /// </summary>
    private readonly List<RoomType> _roomTypes;

    /// <summary>
    /// Инициализация репозитория исходными данными
    /// </summary>
    public RoomTypeRepository()
    {
        _roomTypes = HotelData.RoomTypes.ToList();
    }

    /// <summary>
    /// Получить все типы номеров
    /// </summary>
    public IReadOnlyList<RoomType> GetAll()
    {
        return _roomTypes.AsReadOnly();
    }

    /// <summary>
    /// Получить тип номера по идентификатору
    /// </summary>
    public RoomType? GetById(int id)
    {
        return _roomTypes.FirstOrDefault(roomType => roomType.Id == id);
    }

    /// <summary>
    /// Добавить новый тип номера
    /// </summary>
    public RoomType Add (RoomType roomType)
    {
        _roomTypes.Add(roomType);

        return roomType;
    }

    /// <summary>
    /// Обновить существующий тип номера
    /// </summary>
    public RoomType? Update(RoomType roomType)
    {
        var index = _roomTypes.FindIndex(item => item.Id == roomType.Id);

        if (index == -1) return null;
        _roomTypes[index] = roomType;

        return roomType;
    }

    /// <summary>
    /// Удалить тип номера по идентификатору
    /// </summary>
    public bool Delete(int id)
    {
        var roomType = GetById(id);

        if (roomType is null) return false;

        return _roomTypes.Remove(roomType);
    }
}