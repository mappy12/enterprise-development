using Hotel.Application.Contracts.Bookings;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления бронированиями
/// </summary>
public class BookingsController : CrudControllerBase<BookingDto, CreateBookingDto, int>
{
    /// <summary>
    /// Сервис для выполнения операций с бронированиями
    /// </summary>
    private readonly IBookingService _bookingService;

    /// <summary>
    /// Логгер для записи информации о запросах и ошибках
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Инициализирует контроллер бронирований
    /// </summary>
    public BookingsController(
        IBookingService appService,
        ILogger<BookingsController> logger) : base(appService, logger)
    {
        _bookingService = appService;
        _logger = logger;
    }

    /// <summary>
    /// Вернуть список текущих бронирований
    /// </summary>
    [HttpGet("current")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IReadOnlyList<BookingDto>> GetCurrentBookings()
    {
        _logger.LogInformation(
            "Вызван метод {Method} контроллера {Controller}",
            nameof(GetCurrentBookings),
            GetType().Name);

        try
        {
            var result = _bookingService.GetBookedRooms();

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен",
                nameof(GetCurrentBookings),
                GetType().Name);

            return Ok(result);
        }

        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "При получении текущих бронирований произошла ошибка");

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }
}