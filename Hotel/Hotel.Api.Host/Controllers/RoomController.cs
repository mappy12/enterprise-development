using Hotel.Application.Contracts.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления комнатами и получения статистики по бронированиям
/// </summary>
public class RoomsController : CrudControllerBase<RoomDto, CreateRoomDto, int>
{
    /// <summary>
    /// Сервис для выполнения операций с комнатами
    /// </summary>
    private readonly IRoomService _roomService;

    /// <summary>
    /// Логгер для записи информации о запросах и ошибках
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Инициализирует контроллер комнат
    /// </summary>
    public RoomsController(
        IRoomService appService,
        ILogger<RoomsController> logger)
        : base(appService, logger)
    {
        _roomService = appService;
        _logger = logger;
    }

    /// <summary>
    /// Вернуть пять комнат с наибольшим количеством бронирований
    /// </summary>
    [HttpGet("top-five-most-booked")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IReadOnlyList<RoomBookingCountDto>> GetTopFiveMostBookedRooms()
    {
        _logger.LogInformation(
            "Вызван метод {Method} контроллера {Controller}",
            nameof(GetTopFiveMostBookedRooms),
            GetType().Name);

        try
        {
            var result = _roomService.GetTopFiveMostBookedRooms();

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен",
                nameof(GetTopFiveMostBookedRooms),
                GetType().Name);

            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "При получении пяти наиболее бронируемых комнат произошла ошибка");

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Вернуть количество бронирований для каждой комнаты
    /// </summary>
    [HttpGet("booking-counts")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IReadOnlyList<RoomBookingCountDto>> GetBookingCountForEachRoom()
    {
        _logger.LogInformation(
            "Вызван метод {Method} контроллера {Controller}",
            nameof(GetBookingCountForEachRoom),
            GetType().Name);

        try
        {
            var result = _roomService.GetBookingCountForEachRoom();

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен",
                nameof(GetBookingCountForEachRoom),
                GetType().Name);

            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "При получении количества бронирований комнат произошла ошибка");

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }
}