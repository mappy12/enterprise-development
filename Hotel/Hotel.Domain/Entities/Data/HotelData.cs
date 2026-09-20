using Hotel.Domain.Entities;
using Hotel.Domain.Shared;

namespace Hotel.Domain.Entities.Data;

public static class HotelData
{
    public static List<RoomType> RoomTypes { get; } =
    [
        new RoomType { Id = 1, Category = RoomCategory.Economy, Area = 18, BedCount = 1, HasBathroom = true, PricePerDay = 2500 },
        new RoomType { Id = 2, Category = RoomCategory.Economy, Area = 22, BedCount = 2, HasBathroom = true, PricePerDay = 3000 },
        new RoomType { Id = 3, Category = RoomCategory.Standard, Area = 25, BedCount = 2, HasBathroom = true, PricePerDay = 4000 },
        new RoomType { Id = 4, Category = RoomCategory.Standard, Area = 28, BedCount = 2, HasBathroom = true, PricePerDay = 4500 },
        new RoomType { Id = 5, Category = RoomCategory.Comfort, Area = 32, BedCount = 2, HasBathroom = true, PricePerDay = 5500 },
        new RoomType { Id = 6, Category = RoomCategory.Comfort, Area = 38, BedCount = 3, HasBathroom = true, PricePerDay = 6500 },
        new RoomType { Id = 7, Category = RoomCategory.Luxury, Area = 45, BedCount = 2, HasBathroom = true, PricePerDay = 8000 },
        new RoomType { Id = 8, Category = RoomCategory.Luxury, Area = 55, BedCount = 2, HasBathroom = true, PricePerDay = 10000 },
        new RoomType { Id = 9, Category = RoomCategory.Standard, Area = 30, BedCount = 3, HasBathroom = true, PricePerDay = 5000 },
        new RoomType { Id = 10, Category = RoomCategory.Comfort, Area = 40, BedCount = 4, HasBathroom = true, PricePerDay = 7000 }
    ];

    public static List<Room> Rooms { get; } =
    [
        new Room { Id = 1, RoomNumber = 101, Floor = 1, HasBalcony = false, RoomType = RoomTypes[0] },
        new Room { Id = 2, RoomNumber = 102, Floor = 1, HasBalcony = true, RoomType = RoomTypes[1] },
        new Room { Id = 3, RoomNumber = 201, Floor = 2, HasBalcony = false, RoomType = RoomTypes[2] },
        new Room { Id = 4, RoomNumber = 202, Floor = 2, HasBalcony = true, RoomType = RoomTypes[3] },
        new Room { Id = 5, RoomNumber = 301, Floor = 3, HasBalcony = true, RoomType = RoomTypes[4] },
        new Room { Id = 6, RoomNumber = 302, Floor = 3, HasBalcony = false, RoomType = RoomTypes[5] },
        new Room { Id = 7, RoomNumber = 401, Floor = 4, HasBalcony = true, RoomType = RoomTypes[6] },
        new Room { Id = 8, RoomNumber = 402, Floor = 4, HasBalcony = true, RoomType = RoomTypes[7] },
        new Room { Id = 9, RoomNumber = 501, Floor = 5, HasBalcony = false, RoomType = RoomTypes[8] },
        new Room { Id = 10, RoomNumber = 502, Floor = 5, HasBalcony = true, RoomType = RoomTypes[9] }
    ];

    public static List<Client> Clients { get; } =
    [
        new Client { Id = 1, PassportNumber = "AA123456", FullName = "Alexey Ivanov", BirthDate = new DateTime(1990, 5, 12), Citizenship = "Russia" },
        new Client { Id = 2, PassportNumber = "BB234567", FullName = "Anna Petrova", BirthDate = new DateTime(1988, 3, 20), Citizenship = "Russia" },
        new Client { Id = 3, PassportNumber = "CC345678", FullName = "Dmitry Smirnov", BirthDate = new DateTime(1995, 7, 8), Citizenship = "Russia" },
        new Client { Id = 13, PassportNumber = "XO1234567", FullName = "Yuki Tanaka", BirthDate = new DateTime(1997, 11, 5), Citizenship = "Japan" },
        new Client { Id = 14, PassportNumber = "FR987654321", FullName = "Pierre Dubois", BirthDate = new DateTime(1982, 6, 19), Citizenship = "France" },  
        new Client { Id = 4, PassportNumber = "DD456789", FullName = "Elena Kuznetsova", BirthDate = new DateTime(1992, 11, 15), Citizenship = "Russia" },
        new Client { Id = 5, PassportNumber = "EE567890", FullName = "Ivan Popov", BirthDate = new DateTime(1985, 1, 25), Citizenship = "Russia" },
        new Client { Id = 11, PassportNumber = "AB987654", FullName = "John Smith", BirthDate = new DateTime(1989, 2, 14), Citizenship = "USA" },
        new Client { Id = 6, PassportNumber = "FF678901", FullName = "Maria Sokolova", BirthDate = new DateTime(1998, 6, 10), Citizenship = "Russia" },
        new Client { Id = 7, PassportNumber = "GG789012", FullName = "Nikolay Fedorov", BirthDate = new DateTime(1987, 9, 3), Citizenship = "Russia" },
        new Client { Id = 8, PassportNumber = "HH890123", FullName = "Olga Morozova", BirthDate = new DateTime(1993, 12, 18), Citizenship = "Russia" },
        new Client { Id = 12, PassportNumber = "CD876543", FullName = "Hans Mueller", BirthDate = new DateTime(1994, 10, 30), Citizenship = "Germany" },
        new Client { Id = 9, PassportNumber = "II901234", FullName = "Pavel Volkov", BirthDate = new DateTime(1991, 4, 7), Citizenship = "Russia" },
        new Client { Id = 10, PassportNumber = "JJ012345", FullName = "Sofia Orlova", BirthDate = new DateTime(1996, 8, 22), Citizenship = "Russia" },
    ];

    public static List<Booking> Bookings { get; } =
    [
        new Booking { Id = 1, Client = Clients[0], Room = Rooms[0], CheckInDate = new DateTime(2026, 9, 1), DaysCount = 3 },
        new Booking { Id = 2, Client = Clients[1], Room = Rooms[1], CheckInDate = new DateTime(2026, 9, 2), DaysCount = 5 },
        new Booking { Id = 3, Client = Clients[2], Room = Rooms[2], CheckInDate = new DateTime(2026, 9, 3), DaysCount = 2 },
        new Booking { Id = 4, Client = Clients[3], Room = Rooms[3], CheckInDate = new DateTime(2026, 9, 4), DaysCount = 4 },
        new Booking { Id = 5, Client = Clients[4], Room = Rooms[0], CheckInDate = new DateTime(2026, 9, 5), DaysCount = 7 },
        new Booking { Id = 6, Client = Clients[5], Room = Rooms[4], CheckInDate = new DateTime(2026, 9, 6), DaysCount = 3 },
        new Booking { Id = 7, Client = Clients[6], Room = Rooms[5], CheckInDate = new DateTime(2026, 9, 7), DaysCount = 6 },
        new Booking { Id = 8, Client = Clients[7], Room = Rooms[6], CheckInDate = new DateTime(2026, 9, 8), DaysCount = 2 },
        new Booking { Id = 9, Client = Clients[8], Room = Rooms[7], CheckInDate = new DateTime(2026, 9, 9), DaysCount = 5 },
        new Booking { Id = 10, Client = Clients[9], Room = Rooms[8], CheckInDate = new DateTime(2026, 9, 10), DaysCount = 4 },
        new Booking { Id = 11, Client = Clients[0], Room = Rooms[0], CheckInDate = new DateTime(2026, 8, 1), DaysCount = 2 },
        new Booking { Id = 12, Client = Clients[1], Room = Rooms[1], CheckInDate = new DateTime(2026, 8, 5), DaysCount = 3 },
        new Booking { Id = 13, Client = Clients[2], Room = Rooms[2], CheckInDate = new DateTime(2026, 8, 10), DaysCount = 5 },
        new Booking { Id = 14, Client = Clients[3], Room = Rooms[3], CheckInDate = new DateTime(2026, 8, 15), DaysCount = 2 },
        new Booking { Id = 15, Client = Clients[4], Room = Rooms[4], CheckInDate = new DateTime(2026, 8, 20), DaysCount = 6 },
        new Booking { Id = 16, Client = Clients[5], Room = Rooms[5], CheckInDate = new DateTime(2026, 8, 25), DaysCount = 3 },
        new Booking { Id = 17, Client = Clients[6], Room = Rooms[6], CheckInDate = new DateTime(2026, 7, 1), DaysCount = 4 },
        new Booking { Id = 18, Client = Clients[7], Room = Rooms[7], CheckInDate = new DateTime(2026, 7, 10), DaysCount = 2 },
        new Booking { Id = 19, Client = Clients[8], Room = Rooms[8], CheckInDate = new DateTime(2026, 7, 15), DaysCount = 7 },
        new Booking { Id = 20, Client = Clients[9], Room = Rooms[9], CheckInDate = new DateTime(2026, 7, 20), DaysCount = 3 }
    ];

}
