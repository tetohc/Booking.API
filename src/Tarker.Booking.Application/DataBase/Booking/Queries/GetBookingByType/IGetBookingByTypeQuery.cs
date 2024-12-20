namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByType
{
    public interface IGetBookingByTypeQuery
    {
        Task<List<GetBookingByTypeModel>> Execute(string type);
    }
}