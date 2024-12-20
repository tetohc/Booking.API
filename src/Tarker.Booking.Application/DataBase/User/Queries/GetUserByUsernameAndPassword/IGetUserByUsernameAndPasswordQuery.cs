namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUsernameAndPassword
{
    public interface IGetUserByUsernameAndPasswordQuery
    {
        Task<GetUserByUsernameAndPasswordModel> Execute(string username, string password);
    }
}