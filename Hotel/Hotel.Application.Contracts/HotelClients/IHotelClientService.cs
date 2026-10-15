namespace Hotel.Application.Contracts.HotelClients;

/// <summary>
/// Интерфейс для работы с клиентами гостиницы
/// </summary>
public interface IHotelClientService
    : ICrudService<HotelClientDto, CreateHotelClientDto, int>
{    
}