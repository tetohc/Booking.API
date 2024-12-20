namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdModel
    {
        public Guid CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
    }
}