using Hotel.Application.Contracts.RoomTypes;

namespace Hotel.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления типами номеров
/// </summary>
public class RoomTypesController : CrudControllerBase<RoomTypeDto, CreateRoomTypeDto, int>
{
    /// <summary>
    /// Инициализирует контроллер типов номеров
    /// </summary>
    public RoomTypesController(
        IRoomTypeService appService,
        ILogger<RoomTypesController> logger)
        : base(appService, logger)
    {
    }
}