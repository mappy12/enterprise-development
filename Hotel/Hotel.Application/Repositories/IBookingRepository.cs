using Hotel.Domain.Entities;

namespace Hotel.Application.Repositories;

/// <summary>
/// Интерфейс репозитория бронирований гостиницы
/// </summary>
public interface IBookingRepository
{
    /// <summary>
    /// Получить все бронирования
    /// </summary>
    public IReadOnlyList<Booking> GetAll();

    /// <summary>
    /// Получить бронирование по идентификатору
    /// </summary>
    public Booking? GetById(int id);


    /// <summary>
    /// Добавить новое бронирование
    /// </summary>
    public Booking Add(Booking booking);

    /// <summary>
    /// Обновить существующее бронирование
    /// </summary>
    public Booking? Update(Booking booking);

    /// <summary>
    /// Удалить бронирование по идентификатору
    /// </summary>
    public bool Delete(int id);
}