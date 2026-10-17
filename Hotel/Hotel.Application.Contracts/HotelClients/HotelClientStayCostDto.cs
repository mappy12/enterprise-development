namespace Hotel.Application.Contracts.HotelClients;

public record HotelClientStayCostDto(
    HotelClientDto Client,
    decimal TotalStayCost
);