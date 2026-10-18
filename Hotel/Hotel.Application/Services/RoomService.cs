using Hotel.Application.Contracts.Rooms;
using Hotel.Application.Repositories;
using Hotel.Domain.Entities;

namespace Hotel.Application.Services;

/// <summary>
/// Служба работы с номерами гостиницы
/// </summary>
public class RoomService : IRoomService
{
    /// <summary>
    /// Репозиторий номеров гостиницы
    /// </summary>
    private readonly IRepository<Room> _roomRepository;

    /// <summary>
    /// Репозиторий типов номеров
    /// </summary>
    private readonly IRepository<RoomType> _roomTypeRepository;

    /// <summary>
    /// Репозиторий бронирований
    /// </summary>
    private readonly IRepository<Booking> _bookingRepository;

    /// <summary>
    /// Инициализация службы
    /// </summary>
    public RoomService(
        IRepository<Room> roomRepository,
        IRepository<RoomType> roomTypeRepository,
        IRepository<Booking> bookingRepository)
    {
        _roomRepository = roomRepository;
        _roomTypeRepository = roomTypeRepository;
        _bookingRepository = bookingRepository;
    }

    /// <summary>
    /// Получить все номера
    /// </summary>
    public IReadOnlyList<RoomDto> GetAll()
    {
        return _roomRepository.GetAll()
            .Select(ToDto)
            .ToList();
    }

    /// <summary>
    /// Получить номер по идентификатору
    /// </summary>
    public RoomDto? GetById(int id)
    {
        var room = _roomRepository.GetById(id);

        return room is null ? null : ToDto(room);
    }

    /// <summary>
    /// Создать номер
    /// </summary>
    public RoomDto Create(CreateRoomDto dto)
    {
        var roomType = _roomTypeRepository.GetById(dto.RoomTypeId);

        if (roomType is null) throw new ArgumentException(
            $"Не удалось найти тип номера с идентификатором {dto.RoomTypeId}");

        var rooms = _roomRepository.GetAll();

        var newId = rooms.Count == 0
            ? 1
            : rooms.Max(room => room.Id) + 1;

        var room = new Room
        {
            Id = newId,
            RoomNumber = dto.RoomNumber,
            Floor = dto.Floor,
            HasBalcony = dto.HasBalcony,
            RoomType = roomType
        };

        return ToDto(_roomRepository.Add(room));
    }

    /// <summary>
    /// Обновить номер
    /// </summary>
    public RoomDto? Update(int id, CreateRoomDto dto)
    {
        var existingRoom = _roomRepository.GetById(id);

        if (existingRoom is null) return null;

        var roomType = _roomTypeRepository.GetById(dto.RoomTypeId);

        if (roomType is null) throw new ArgumentException(
            $"Не удалось найти тип номера с идентификатором {dto.RoomTypeId}");

        var room = new Room
        {
            Id = id,
            RoomNumber = dto.RoomNumber,
            Floor = dto.Floor,
            HasBalcony = dto.HasBalcony,
            RoomType = roomType
        };

        var updatedRoom = _roomRepository.Update(room);

        return updatedRoom is null ? null : ToDto(updatedRoom);
    }

    /// <summary>
    /// Удалить номер
    /// </summary>
    public bool Delete(int id)
    {
        return _roomRepository.Delete(id);
    }

    /// <summary>
    /// Получить пять самых часто бронируемых номеров
    /// </summary>
    public IReadOnlyList<RoomBookingCountDto> GetTopFiveMostBookedRooms()
    {
        var bookings = _bookingRepository.GetAll();

        return _roomRepository.GetAll()
            .Select(room => new RoomBookingCountDto(
                ToDto(room),
                bookings.Count(booking => booking.Room.Id == room.Id)))
            .OrderByDescending(item => item.BookingCount)
            .ThenBy(item => item.Room.Id)
            .Take(5)
            .ToList();
    }

    /// <summary>
    /// Получить количество бронирований каждого номера
    /// </summary>
    public IReadOnlyList<RoomBookingCountDto> GetBookingCountForEachRoom()
    {
        var bookings = _bookingRepository.GetAll();

        return _roomRepository.GetAll()
            .Select(room => new RoomBookingCountDto(
                ToDto(room),
                bookings.Count(booking => booking.Room.Id == room.Id)))
            .OrderBy(item => item.Room.Id)
            .ToList();
    }

    /// <summary>
    /// Преобразовать доменную сущность в DTO
    /// </summary>
    private static RoomDto ToDto(Room room)
    {
        return new RoomDto(
            room.Id,
            room.RoomNumber,
            room.Floor,
            room.HasBalcony,
            room.RoomType.Id
        );
    }
}