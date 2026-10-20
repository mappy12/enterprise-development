using Hotel.Application.Contracts.HotelClients;
using Hotel.Domain.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления клиентами и получения статистики по их бронированиям
/// </summary>
public class HotelClientsController : CrudControllerBase<HotelClientDto, CreateHotelClientDto, int>
{
    /// <summary>
    /// Сервис для выполнения операций с клиентами
    /// </summary>
    private readonly IHotelClientService _hotelClientService;

    /// <summary>
    /// Логгер для записи информации о запросах и ошибках
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Инициализирует контроллер клиентов
    /// </summary>
    public HotelClientsController(
        IHotelClientService appService,
        ILogger<HotelClientsController> logger) : base(appService, logger)
    {
        _hotelClientService = appService;
        _logger = logger;
    }

    /// <summary>
    /// Вернуть пять клиентов с наибольшей общей стоимостью проживания
    /// </summary>
    [HttpGet("top-five-by-total-stay-cost")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IReadOnlyList<HotelClientStayCostDto>> GetTopFiveClientsByTotalStayCost()
    {
        _logger.LogInformation(
            "Вызван метод {Method} контроллера {Controller}",
            nameof(GetTopFiveClientsByTotalStayCost),
            GetType().Name);

        try
        {
            var result = _hotelClientService.GetTopFiveClientsByTotalStayCost();

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен",
                nameof(GetTopFiveClientsByTotalStayCost),
                GetType().Name);

            return Ok(result);
        }

        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "При получении пяти клиентов с наибольшей стоимостью проживания произошла ошибка");

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }

    }

    /// <summary>
    /// Вернуть клиентов, бронировавших комнаты указанной категории
    /// </summary>
    [HttpGet("by-room-category/{category}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult<IReadOnlyList<HotelClientDto>> GetClientsByRoomCategory(
        RoomCategory category)
    {
        _logger.LogInformation(
            "Вызван метод {Method} контроллера {Controller}. Категория комнаты: {Category}",
            nameof(GetClientsByRoomCategory),
            GetType().Name,
            category);

        try
        {
            var result = _hotelClientService.GetClientsByRoomCategory(category);

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен",
                nameof(GetClientsByRoomCategory),
                GetType().Name);

            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "При получении клиентов по категории комнат произошла ошибка");

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }
}