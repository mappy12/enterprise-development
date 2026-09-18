namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Ресторан в службе доставки еды
/// </summary>
public class Restaurant
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название ресторана
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Адрес ресторана
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Рейтинг ресторана
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Часы работы ресторана
    /// </summary>
    public string OpeningHours { get; set; } = string.Empty;
}
