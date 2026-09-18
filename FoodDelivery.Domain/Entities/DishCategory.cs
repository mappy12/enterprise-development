namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Категория блюда в службе доставки еды
/// </summary>
public class DishCategory
{
    /// <summary>
    /// Идентификатор категории
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
