namespace FoodDelivery.Domain.Entities;

public class Dish
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Weight { get; set; }

    public decimal Price { get; set; }

    public DishCategory Category { get; set; } = null!;
}
