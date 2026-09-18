using FoodDelivery.Domain.Entities;
namespace FoodDelivery.Domain.Data;

/// <summary>
/// Тестовые данные службы доставки еды.
/// </summary>
public class FoodDeliveryData
{
    /// <summary>
    /// Список категорий блюд
    /// </summary>
    public static List<DishCategory> Categories { get; } =
    [
        new DishCategory { Id = 1, Name = "Burgers" },
        new DishCategory { Id = 2, Name = "Pizza" },
        new DishCategory { Id = 3, Name = "Sushi" },
        new DishCategory { Id = 4, Name = "Salads" },
        new DishCategory { Id = 5, Name = "Soups" },
        new DishCategory { Id = 6, Name = "Pasta" },
        new DishCategory { Id = 7, Name = "Desserts" },
        new DishCategory { Id = 8, Name = "Drinks" },
        new DishCategory { Id = 9, Name = "Breakfast" },
        new DishCategory { Id = 10, Name = "Grill" }
    ];

    /// <summary>
    /// Список ресторанов службы доставки
    /// </summary>
    public static List<Restaurant> Restaurants { get; } =
    [
        new Restaurant
        {
            Id = 1,
            Name = "Burger House",
            Address = "Leningradskaya Street, 25",
            Rating = 4.8,
            OpeningHours = "10:00 - 23:00"
        },

        new Restaurant
        {
            Id = 2,
            Name = "Pizza Time",
            Address = "Agibalova Street, 15",
            Rating = 4.6,
            OpeningHours = "10:00 - 00:00"
        },

        new Restaurant
        {
            Id = 3,
            Name = "Sushi World",
            Address = "Kuibysheva Street, 7",
            Rating = 4.9,
            OpeningHours = "11:00 - 23:00"
        },

        new Restaurant
        {
            Id = 4,
            Name = "Green Food",
            Address = "Lva Tolstogo Street, 21",
            Rating = 4.5,
            OpeningHours = "09:00 - 22:00"
        },

        new Restaurant
        {
            Id = 5,
            Name = "Pasta Place",
            Address = "Gagarina Street, 5",
            Rating = 4.4,
            OpeningHours = "10:00 - 23:00"
        },

        new Restaurant
        {
            Id = 6,
            Name = "Grill House",
            Address = "Sovetskaya Street, 18",
            Rating = 4.7,
            OpeningHours = "11:00 - 00:00"
        },

        new Restaurant
        {
            Id = 7,
            Name = "Morning Cafe",
            Address = "Revolyutsionnaya Street, 3",
            Rating = 4.3,
            OpeningHours = "07:00 - 18:00"
        },

        new Restaurant
        {
            Id = 8,
            Name = "Sweet Corner",
            Address = "Lesnaya Street, 12",
            Rating = 4.6,
            OpeningHours = "09:00 - 21:00"
        },

        new Restaurant
        {
            Id = 9,
            Name = "Soup Kitchen",
            Address = "Naberezhnaya Street, 8",
            Rating = 4.2,
            OpeningHours = "10:00 - 22:00"
        },

        new Restaurant
        {
            Id = 10,
            Name = "Family Restaurant",
            Address = "Molodezhnaya Street, 25",
            Rating = 4.1,
            OpeningHours = "10:00 - 23:00"
        }
    ];


    /// <summary>
    /// Список клиентов службы доставки
    /// </summary>
    public static List<Client> Clients { get; } =
    [
        new Client
        {
            Id = 1,
            FullName = "Alexey Ivanov",
            PhoneNumber = "+7 927 111-11-01",
            DeliveryAddress = "Leningradskaya Street, 1"
        },

        new Client
        {
            Id = 2,
            FullName = "Anna Petrova",
            PhoneNumber = "+7 927 111-11-02",
            DeliveryAddress = "Central Street, 2"
        },

        new Client
        {
            Id = 3,
            FullName = "Dmitry Smirnov",
            PhoneNumber = "+7 927 111-11-03",
            DeliveryAddress = "Samarskaya Street, 3"
        },

        new Client
        {
            Id = 4,
            FullName = "Elena Kuznetsova",
            PhoneNumber = "+7 927 111-11-04",
            DeliveryAddress = "Lva Tolstogo Street, 4"
        },

        new Client
        {
            Id = 5,
            FullName = "Ivan Popov",
            PhoneNumber = "+7 927 111-11-05",
            DeliveryAddress = "Gagarina Street, 5"
        },

        new Client
        {
            Id = 6,
            FullName = "Maria Sokolova",
            PhoneNumber = "+7 927 111-11-06",
            DeliveryAddress = "Sovetskaya Street, 6"
        },

        new Client
        {
            Id = 7,
            FullName = "Nikolay Fedorov",
            PhoneNumber = "+7 927 111-11-07",
            DeliveryAddress = "Revolyutsionnaya Street, 7"
        },

        new Client
        {
            Id = 8,
            FullName = "Olga Morozova",
            PhoneNumber = "+7 927 111-11-08",
            DeliveryAddress = "Lesnaya Street, 8"
        },

        new Client
        {
            Id = 9,
            FullName = "Pavel Volkov",
            PhoneNumber = "+7 927 111-11-09",
            DeliveryAddress = "Naberezhnaya Street, 9"
        },

        new Client
        {
            Id = 10,
            FullName = "Sofia Orlova",
            PhoneNumber = "+7 927 111-11-10",
            DeliveryAddress = "Molodezhnaya Street, 10"
        }
    ];

    /// <summary>
    /// Список блюд, доступных в службе доставки
    /// </summary>
    public static List<Dish> Dishes { get; } =
    [
        new Dish
        {
            Id = 1,
            Name = "Classic Burger",
            Weight = 300,
            Price = 450,
            Category = Categories[0]
        },

        new Dish
        {
            Id = 2,
            Name = "Cheeseburger",
            Weight = 320,
            Price = 500,
            Category = Categories[0]
        },

        new Dish
        {
            Id = 3,
            Name = "Pepperoni Pizza",
            Weight = 600,
            Price = 700,
            Category = Categories[1]
        },

        new Dish
        {
            Id = 4,
            Name = "Margherita Pizza",
            Weight = 550,
            Price = 650,
            Category = Categories[1]
        },

        new Dish
        {
            Id = 5,
            Name = "Philadelphia Roll",
            Weight = 250,
            Price = 800,
            Category = Categories[2]
        },

        new Dish
        {
            Id = 6,
            Name = "Caesar Salad",
            Weight = 250,
            Price = 400,
            Category = Categories[3]
        },

        new Dish
        {
            Id = 7,
            Name = "Tomato Soup",
            Weight = 350,
            Price = 350,
            Category = Categories[4]
        },

        new Dish
        {
            Id = 8,
            Name = "Carbonara",
            Weight = 400,
            Price = 600,
            Category = Categories[5]
        },

        new Dish
        {
            Id = 9,
            Name = "Cheesecake",
            Weight = 180,
            Price = 300,
            Category = Categories[6]
        },

        new Dish
        {
            Id = 10,
            Name = "Cola",
            Weight = 500,
            Price = 150,
            Category = Categories[7]
        }
    ];

    /// <summary>
    /// Список заказов с информацией о клиентах, ресторанах, блюдах,
    /// времени заказа, времени доставки и итоговой стоимости
    /// </summary>
    public static List<Order> Orders { get; } =
    [
        new Order
        {
            Id = 1,
            Client = Clients[0],
            Restaurant = Restaurants[0],
            Dishes = [Dishes[0], Dishes[9]],
            OrderTime = new DateTime(2026, 9, 1, 12, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 1, 12, 30, 00),
            TotalAmount = 600
        },
        new Order
        {
            Id = 2,
            Client = Clients[1],
            Restaurant = Restaurants[0],
            Dishes = [Dishes[1]],
            OrderTime = new DateTime(2026, 9, 2, 13, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 2, 13, 25, 00),
            TotalAmount = 500
        },
        new Order
        {
            Id = 3,
            Client = Clients[2],
            Restaurant = Restaurants[0],
            Dishes = [Dishes[0], Dishes[1]],
            OrderTime = new DateTime(2026, 9, 3, 18, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 3, 18, 45, 00),
            TotalAmount = 950
        },
        new Order
        {
            Id = 4,
            Client = Clients[0],
            Restaurant = Restaurants[1],
            Dishes = [Dishes[2]],
            OrderTime = new DateTime(2026, 9, 4, 14, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 4, 14, 40, 00),
            TotalAmount = 700
        },
        new Order
        {
            Id = 5,
            Client = Clients[3],
            Restaurant = Restaurants[1],
            Dishes = [Dishes[3], Dishes[9]],
            OrderTime = new DateTime(2026, 9, 5, 15, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 5, 15, 35, 00),
            TotalAmount = 800
        },
        new Order
        {
            Id = 6,
            Client = Clients[4],
            Restaurant = Restaurants[1],
            Dishes = [Dishes[2], Dishes[3]],
            OrderTime = new DateTime(2026, 9, 6, 19, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 6, 19, 50, 00),
            TotalAmount = 1350
        },
        new Order
        {
            Id = 7,
            Client = Clients[5],
            Restaurant = Restaurants[2],
            Dishes = [Dishes[4]],
            OrderTime = new DateTime(2026, 9, 7, 18, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 7, 18, 20, 00),
            TotalAmount = 800
        },
        new Order
        {
            Id = 8,
            Client = Clients[6],
            Restaurant = Restaurants[2],
            Dishes = [Dishes[4], Dishes[9]],
            OrderTime = new DateTime(2026, 9, 8, 19, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 8, 19, 30, 00),
            TotalAmount = 950
        },
        new Order
        {
            Id = 9,
            Client = Clients[7],
            Restaurant = Restaurants[3],
            Dishes = [Dishes[5]],
            OrderTime = new DateTime(2026, 9, 9, 12, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 9, 12, 50, 00),
            TotalAmount = 400
        },
        new Order
        {
            Id = 10,
            Client = Clients[8],
            Restaurant = Restaurants[4],
            Dishes = [Dishes[7]],
            OrderTime = new DateTime(2026, 9, 10, 13, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 10, 13, 35, 00),
            TotalAmount = 600
        },
        new Order
        {
            Id = 11,
            Client = Clients[9],
            Restaurant = Restaurants[5],
            Dishes = [Dishes[9]],
            OrderTime = new DateTime(2026, 9, 11, 16, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 11, 16, 25, 00),
            TotalAmount = 150
        },
        new Order
        {
            Id = 12,
            Client = Clients[0],
            Restaurant = Restaurants[6],
            Dishes = [Dishes[8]],
            OrderTime = new DateTime(2026, 9, 12, 09, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 12, 09, 20, 00),
            TotalAmount = 300
        },
        new Order
        {
            Id = 13,
            Client = Clients[1],
            Restaurant = Restaurants[7],
            Dishes = [Dishes[8], Dishes[9]],
            OrderTime = new DateTime(2026, 9, 13, 17, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 13, 17, 45, 00),
            TotalAmount = 450
        },
        new Order
        {
            Id = 14,
            Client = Clients[2],
            Restaurant = Restaurants[8],
            Dishes = [Dishes[6]],
            OrderTime = new DateTime(2026, 9, 14, 12, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 14, 12, 55, 00),
            TotalAmount = 350
        },
        new Order
        {
            Id = 15,
            Client = Clients[3],
            Restaurant = Restaurants[9],
            Dishes = [Dishes[5], Dishes[8]],
            OrderTime = new DateTime(2026, 9, 15, 18, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 15, 18, 40, 00),
            TotalAmount = 700
        },
        new Order
        {
            Id = 16,
            Client = Clients[4],
            Restaurant = Restaurants[0],
            Dishes = [Dishes[0], Dishes[9]],
            OrderTime = new DateTime(2026, 9, 16, 12, 00, 00),
            DeliveryTime = new DateTime(2026, 9, 16, 12, 30, 00),
            TotalAmount = 600
        },
        new Order
        {
            Id = 17,
            Client = Clients[5],
            Restaurant = Restaurants[1],
            Dishes = [Dishes[2]],
            OrderTime = new DateTime(2026, 8, 20, 13, 00, 00),
            DeliveryTime = new DateTime(2026, 8, 20, 13, 40, 00),
            TotalAmount = 700
        },
        new Order
        {
            Id = 18,
            Client = Clients[6],
            Restaurant = Restaurants[0],
            Dishes = [Dishes[1], Dishes[9]],
            OrderTime = new DateTime(2026, 8, 25, 17, 00, 00),
            DeliveryTime = new DateTime(2026, 8, 25, 17, 35, 00),
            TotalAmount = 650
        },
        new Order
        {
            Id = 19,
            Client = Clients[7],
            Restaurant = Restaurants[2],
            Dishes = [Dishes[4]],
            OrderTime = new DateTime(2026, 8, 28, 18, 00, 00),
            DeliveryTime = new DateTime(2026, 8, 28, 18, 20, 00),
            TotalAmount = 800
        },
        new Order
        {
            Id = 20,
            Client = Clients[8],
            Restaurant = Restaurants[0],
            Dishes = [Dishes[0], Dishes[1]],
            OrderTime = new DateTime(2026, 8, 30, 19, 00, 00),
            DeliveryTime = new DateTime(2026, 8, 30, 19, 45, 00),
            TotalAmount = 950
        }
    ];
}