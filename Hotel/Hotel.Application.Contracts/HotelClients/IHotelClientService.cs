namespace Hotel.Application.Contracts.HotelClients;

/// <summary>
/// Интерфейс для работы с клиентами гостиницы
/// </summary>
public interface IHotelClientService
    : ICrudService<HotelClientDto, CreateHotelClientDto, int>
{
    /// <summary>
    /// Получить топ пять клиентов по общей стоимости проживания
    /// </summary>
    public IReadOnlyList<HotelClientStayCostDto> GetTopFiveClientsByTotalStayCost();
}
