namespace FoodDelivery.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public Client Client { get; set; } = null!;

    public Restaurant Restaurant { get; set; } = null!;

    public List<Dish> Dishes { get; set; } = new();

    public DateTime OrderTime { get; set; }

    public DateTime DeliveryTime { get; set; }

    public decimal TotalAmount { get; set; }
}

