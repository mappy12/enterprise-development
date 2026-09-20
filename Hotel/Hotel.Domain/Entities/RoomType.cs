using Hotel.Domain.Shared;

namespace Hotel.Domain.Entities;

public class RoomType
{
    public int Id { get; set; }

    public RoomCategory Category { get; set; }

    public double Area { get; set; }

    public int BedCount { get; set; }

    public bool HasBathroom { get; set; }

    public decimal PricePerDay { get; set; }
}