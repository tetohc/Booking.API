namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookingQuery
{
    public class GetAllBookingModel
    {
        public Guid BookingId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerDocumentNumber { get; set; }
    }
}