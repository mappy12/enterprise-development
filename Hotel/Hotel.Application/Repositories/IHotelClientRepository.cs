using Hotel.Domain.Entities;

namespace Hotel.Application.Repositories;

/// <summary>
/// Интерфейс репозитория клиентов гостиницы
/// </summary>
public interface IHotelClientRepository
{
    /// <summary>
    /// Получить всех клиентов
    /// </summary>
    public IReadOnlyList<HotelClient> GetAll();

    /// <summary>
    /// Получить клиента по идентификатору
    /// </summary>
    public HotelClient? GetById(int id);

    /// <summary>
    /// Добавить нового клиента
    /// </summary>
    public HotelClient Add(HotelClient client);

    /// <summary>
    /// Обновить существующего клиента
    /// </summary>
    public HotelClient? Update(HotelClient client);

    /// <summary>
    /// Удалить клиента по идентификатору
    /// </summary>
    public bool Delete(int id);
}