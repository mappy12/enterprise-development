using Hotel.Application.Repositories;
using Hotel.Domain.Data;
using Hotel.Domain.Entities;

namespace Hotel.Infrastructure.InMemory.Repositories;

/// <summary>
/// Репозиторий клиентов гостиницы в памяти
/// </summary>
public class HotelClientRepository : IRepository<HotelClient>
{
    /// <summary>
    /// Данные клиентов гостиницы
    /// </summary>
    private readonly List<HotelClient> _clients;

    /// <summary>
    /// Инициализация репозитория данными
    /// </summary>
    public HotelClientRepository()
    {
        _clients = HotelData.Clients.ToList();
    }

    /// <summary>
    /// Получить всех клиентов
    /// </summary>
    public IReadOnlyList<HotelClient> GetAll()
    {
        return _clients.AsReadOnly();
    }

    /// <summary>
    /// Получить клиента по идентификатору
    /// </summary>
    public HotelClient? GetById(int id)
    {
        return _clients.FirstOrDefault(client => client.Id == id);
    }

    /// <summary>
    /// Добавить нового клиента
    /// </summary>
    public HotelClient Add(HotelClient client)
    {
        _clients.Add(client);

        return client;
    }

    /// <summary>
    /// Обновить существующего клиента
    /// </summary>
    public HotelClient? Update(HotelClient client)
    {
        var index = _clients.FindIndex(item => item.Id == client.Id);

        if (index == -1) return null;
        _clients[index] = client;

        return client;
    }

    /// <summary>
    /// Удалить клиента по идентификатору
    /// </summary>
    public bool Delete(int id)
    {
        var client = GetById(id);

        if (client is null) return false;

        return _clients.Remove(client);
    }
}