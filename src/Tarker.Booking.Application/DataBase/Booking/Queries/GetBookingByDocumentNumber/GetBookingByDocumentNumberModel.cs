namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByDocumentNumber
{
    public class GetBookingByDocumentNumberModel
    {
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; }
    }
}