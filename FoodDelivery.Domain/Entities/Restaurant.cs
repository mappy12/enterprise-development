namespace FoodDelivery.Domain.Entities;

public class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public double Rating { get; set; }

    public string OpeningHours { get; set; } = string.Empty;
}
