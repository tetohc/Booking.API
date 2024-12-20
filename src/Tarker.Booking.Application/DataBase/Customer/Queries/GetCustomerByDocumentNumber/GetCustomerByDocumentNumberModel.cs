namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberModel
    {
        public Guid CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
    }
}