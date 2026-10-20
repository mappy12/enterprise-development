using Hotel.Application.Contracts.RoomTypes;
using Microsoft.Extensions.Logging;

namespace Hotel.Api.Host.Controllers;

public class RoomTypesController : CrudControllerBase<RoomTypeDto, CreateRoomTypeDto, int>
{
    public RoomTypesController(
        IRoomTypeService appService,
        ILogger<RoomTypesController> logger)
        : base(appService, logger)
    {
    }
}