namespace Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking
{
    public class CreateBookingModel
    {
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
    }
}