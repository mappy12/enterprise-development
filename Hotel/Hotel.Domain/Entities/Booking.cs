namespace Hotel.Domain.Entities;

public class Booking
{
    public int Id { get; set; }

    public Client Client { get; set; } = null!;

    public Room Room { get; set; } = null!;

    public DateTime CheckInDate { get; set; }

    public int DaysCount { get; set; }
}
