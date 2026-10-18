using Hotel.Domain.Entities;

namespace Hotel.Application.Repositories;

/// <summary>
/// Интерфейс репозитория номеров гостницы
/// </summary>
public interface IRoomRepository
{
    /// <summary>
    /// Возвращает все доступные комнаты.
    /// </summary>
    public IReadOnlyList<Room> GetAll();

    /// <summary>
    /// Получить номер по идентификатору
    /// </summary>
    public Room? GetById(int id);

    /// <summary>
    /// Добавить новый номер
    /// </summary>
    public Room Add(Room room);

    /// <summary>
    /// Обновить существующий номер
    /// </summary>
    public Room? Update(Room room);

    /// <summary>
    /// Удалить номер по идентификатору
    /// </summary>
    public bool Delete(int id);
}