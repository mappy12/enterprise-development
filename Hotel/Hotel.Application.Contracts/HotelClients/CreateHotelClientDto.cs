namespace Hotel.Application.Contracts.HotelClients;

/// <summary>
/// DTO для создания клиента
/// </summary>
public record CreateHotelClientDto(
    string PassportNumber,
    string FirstName,
    string LastName,
    string? MiddleName,
    DateOnly BirthDate,
    string Citizenship
);
