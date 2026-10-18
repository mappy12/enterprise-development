using Hotel.Application.Repositories;
using Hotel.Domain.Data;
using Hotel.Domain.Entities;

namespace Hotel.Infrastructure.InMemory.Repositories;


/// <summary>
/// Репозиторий номеров гостницы в памяти
/// </summary>
public class RoomRepository : IRepository<Room>
{
    /// <summary>
    /// Данные номеров гостиницы
    /// </summary>
    private readonly List<Room> _rooms;

    /// <summary>
    /// Инициализация репозитория данными
    /// </summary>
    public RoomRepository()
    {
        _rooms = HotelData.Rooms.ToList();
    }

    /// <summary>
    /// Получить все номера
    /// </summary>
    public IReadOnlyList<Room> GetAll()
    {
        return _rooms.AsReadOnly();
    }

    /// <summary>
    /// Получить номер по идентификатору
    /// </summary>
    public Room? GetById(int id)
    {
        return _rooms.FirstOrDefault(room => room.Id == id);
    }

    /// <summary>
    /// Добавить новый номер
    /// </summary>
    public Room Add(Room room)
    {
        _rooms.Add(room);

        return room;
    }

    /// <summary>
    /// Обновить существующий номер
    /// </summary>
    public Room? Update(Room room)
    {
        var index = _rooms.FindIndex(item => item.Id == room.Id);

        if (index == -1) return null;
        _rooms[index] = room;

        return room;
    }

    /// <summary>
    /// Удалить номер по идентификатору
    /// </summary>
    public bool Delete(int id)
    {
        var room = GetById(id);

        if (room is null) return false;

        return _rooms.Remove(room);
    }
}