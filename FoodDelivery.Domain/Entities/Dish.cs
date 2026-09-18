namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Блюдо в службе доставки еды
/// </summary>
public class Dish
{
    /// <summary>
    /// Идентификатор блюда
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название блюда
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Вес блюда в граммах
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// Цена блюда
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Категория, к которой относится блюдо
    /// </summary>
    public DishCategory Category { get; set; } = null!;
}
