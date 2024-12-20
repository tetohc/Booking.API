namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByType
{
    public class GetBookingByTypeModel
    {
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; }
        public string CustomerFullname { get; set; } = string.Empty;
        public string CustomerDocumentNumber { get; set; } = string.Empty;
    }
}