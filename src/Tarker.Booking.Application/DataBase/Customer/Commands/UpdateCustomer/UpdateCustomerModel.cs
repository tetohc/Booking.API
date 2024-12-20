namespace Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerModel
    {
        public Guid CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
    }
}