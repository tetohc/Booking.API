namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookingQuery
{
    public interface IGetAllBookingQuery
    {
        Task<List<GetAllBookingModel>> Execute();
    }
}