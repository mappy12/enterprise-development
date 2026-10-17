using Hotel.Domain.Entities;

namespace Hotel.Application.Repositories;

/// <summary>
/// Интерфейс репозитория типов номеров
/// </summary>
public interface IRoomTypeRepository
{
    /// <summary>
    /// Получить все типы номеров
    /// </summary>
    public IReadOnlyList<RoomType> GetAll();

    /// <summary>
    /// Получить тип номера по идентификатору
    /// </summary>
    public RoomType? GetById(int id);

    /// <summary>
    /// Добавить новый тип номера
    /// </summary>
    public RoomType Add(RoomType roomType);

    /// <summary>
    /// Обновить существующий тип номера
    /// </summary>
    public RoomType? Update(RoomType roomType);

    /// <summary>
    /// Удалить тип номера по идентификатору
    /// </summary>
    public bool Delete(int id);
}