using Hotel.Domain.Shared.Enums;

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

    /// <summary>
    /// Получает клинтов, бронировавших номера указанной категории
    /// </summary>
    public IReadOnlyList<HotelClientDto> GetClientsByRoomCategory(RoomCategory category);
}
