namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Заказ в службе доставки еды
/// </summary>
public class Order
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Клиент, оформивший заказ
    /// </summary>
    public Client Client { get; set; } = null!;

    /// <summary>
    /// Ресторан, в котором был оформлен заказ
    /// </summary>
    public Restaurant Restaurant { get; set; } = null!;

    /// <summary>
    /// Список блюд в заказе
    /// </summary>
    public List<Dish> Dishes { get; set; } = new();

    /// <summary>
    /// Дата и время оформления заказа
    /// </summary>
    public DateTime OrderTime { get; set; }

    /// <summary>
    /// Дата и время доставки заказа
    /// </summary>
    public DateTime DeliveryTime { get; set; }

    /// <summary>
    /// Общая стоимость заказа
    /// </summary>
    public decimal TotalAmount { get; set; }
}

