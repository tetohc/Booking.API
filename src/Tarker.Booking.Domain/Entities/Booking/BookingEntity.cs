using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Domain.Entities.Booking
{
    public class BookingEntity
    {
        public Guid BookingId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
        public CustomerEntity Customer { get; set; }
    }
}