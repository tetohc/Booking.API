namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordModel
    {
        public Guid UserId { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}