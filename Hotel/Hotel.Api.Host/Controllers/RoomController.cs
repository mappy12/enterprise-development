using Hotel.Application.Contracts.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления комнатами и получения статистики по бронированиям
/// </summary>
public class RoomsController(IRoomService roomService, ILogger<RoomsController> logger)
    : CrudControllerBase<RoomDto, CreateRoomDto, int>(roomService, logger)
{
    /// <summary>
    /// Вернуть пять комнат с наибольшим количеством бронирований
    /// </summary>
    [HttpGet("top-five-most-booked")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IReadOnlyList<RoomBookingCountDto>> GetTopFiveMostBookedRooms()
    {
        logger.LogInformation(
            "Вызван метод {Method} контроллера {Controller}",
            nameof(GetTopFiveMostBookedRooms),
            GetType().Name);

        try
        {
            var result = roomService.GetTopFiveMostBookedRooms();

            logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен",
                nameof(GetTopFiveMostBookedRooms),
                GetType().Name);

            return Ok(result);
        }
        catch (Exception exception)
        {
            logger.LogError(
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
        logger.LogInformation(
            "Вызван метод {Method} контроллера {Controller}",
            nameof(GetBookingCountForEachRoom),
            GetType().Name);

        try
        {
            var result = roomService.GetBookingCountForEachRoom();

            logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен",
                nameof(GetBookingCountForEachRoom),
                GetType().Name);

            return Ok(result);
        }
        catch (Exception exception)
        {
            logger.LogError(
                exception,
                "При получении количества бронирований комнат произошла ошибка");

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }
}