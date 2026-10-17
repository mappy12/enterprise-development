namespace Hotel.Application.Contracts.Rooms;

public record RoomBookingCountDto(
    RoomDto Room,
    int BookingCount
);