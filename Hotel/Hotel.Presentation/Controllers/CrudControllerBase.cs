using Hotel.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Host.Controllers;

/// <summary>
/// Базовый контроллер для CRUD операций над сущностями
/// </summary>
[Route("api/[controller]")]
[ApiController]
public abstract class CrudControllerBase<TDto, TInputDto, TKey> : ControllerBase
    where TDto : class
    where TInputDto : class
    where TKey : struct
{
    /// <summary>
    /// Сервис для выполнения CRUD операций над DTO
    /// </summary>
    private readonly ICrudService<TDto, TInputDto, TKey> _appService;

    /// <summary>
    /// Логгер для записи информации о выполнении запросов и ошибках
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Инициализирует базовый CRUD контроллер
    /// </summary>
    protected CrudControllerBase(
        ICrudService<TDto, TInputDto, TKey> appService,
        ILogger logger)
    {
        _appService = appService;
        _logger = logger;
    }

    /// <summary>
    /// Создать новую запись
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Create([FromBody] TInputDto dto)
    {
        _logger.LogInformation(
            "Вызван метод {Method} контроллера {Controller}. Данные: {@Dto}",
            nameof(Create),
            GetType().Name,
            dto);

        try
        {
            var result = _appService.Create(dto);

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен",
                nameof(Create),
                GetType().Name);

            return StatusCode(StatusCodes.Status201Created, result);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Во время выполнения метода {Method} контроллера {Controller} произошла ошибка.",
                nameof(Create),
                GetType().Name);

            return StatusCode(StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Обновить существующую запись
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Update(TKey id, [FromBody] TInputDto dto)
    {
        _logger.LogInformation(
            "Метод {Method} контроллера {Controller} вызван с идентификатором {Id} и данными {@Dto}.",
            nameof(Update),
            GetType().Name,
            id,
            dto);

        try
        {
            var result = _appService.Update(id, dto);

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен.",
                nameof(Update),
                GetType().Name);

            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Во время выполнения метода {Method} контроллера {Controller} произошла ошибка.",
                nameof(Update),
                GetType().Name);

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Удалить запись по идентификатору
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public IActionResult Delete(TKey id)
    {
        _logger.LogInformation(
            "Метод {Method} контроллера {Controller} вызван с идентификатором {Id}.",
            nameof(Delete),
            GetType().Name,
            id);

        try
        {
            _appService.Delete(id);

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен.",
                nameof(Delete),
                GetType().Name);

            return Ok();
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Во время выполнения метода {Method} контроллера {Controller} произошла ошибка.",
                nameof(Delete),
                GetType().Name);

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Вернуть список всех записей
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IReadOnlyList<TDto>> GetAll()
    {
        _logger.LogInformation(
            "Метод {Method} контроллера {Controller} вызван.",
            nameof(GetAll),
            GetType().Name);

        try
        {
            var result = _appService.GetAll();

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен.",
                nameof(GetAll),
                GetType().Name);

            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Во время выполнения метода {Method} контроллера {Controller} произошла ошибка.",
                nameof(GetAll),
                GetType().Name);

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Вернуть запись по идентификатору
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> GetById(TKey id)
    {
        _logger.LogInformation(
            "Метод {Method} контроллера {Controller} вызван с идентификатором {Id}.",
            nameof(GetById),
            GetType().Name,
            id);

        try
        {
            var result = _appService.GetById(id);

            _logger.LogInformation(
                "Метод {Method} контроллера {Controller} успешно выполнен.",
                nameof(GetById),
                GetType().Name);

            return result is not null ? Ok(result) : NoContent();
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Во время выполнения метода {Method} контроллера {Controller} произошла ошибка.",
                nameof(GetById),
                GetType().Name);

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"{exception.Message}\n{exception.InnerException?.Message}");
        }
    }
}