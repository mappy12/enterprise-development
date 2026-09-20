using Hotel.Domain.Shared;

namespace Hotel.Domain.Entities;

public class  Room
{
    public int Id { get; set; }

    public int RoomNumber { get; set; }

    public int Floor { get; set; }

    public bool HasBalcony { get; set; }

    public RoomType RoomType { get; set; } = null!;
}