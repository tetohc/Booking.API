namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByDocumentNumber
{
    public interface IGetBookingByDocumentNumberQuery
    {
        Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber);
    }
}