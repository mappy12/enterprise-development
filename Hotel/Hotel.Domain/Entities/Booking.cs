namespace Hotel.Domain.Entities;

/// <summary>
/// Бронирование номера гостиницы клиентом
/// </summary>
public class Booking
{
    /// <summary>
    /// Индентификатор бронирования
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Клиент, который забронировал номер
    /// </summary>
    public Client Client { get; set; } = null!;

    /// <summary> 
    /// Забронированный номер гостиницы
    /// </summary>
    public Room Room { get; set; } = null!;

    /// <summary>
    /// Дата заселения клиента
    /// </summary>
    public DateTime CheckInDate { get; set; }

    /// <summary>
    /// Количество дней проживания
    /// </summary>
    public int DaysCount { get; set; }
}
