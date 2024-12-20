using System.ComponentModel.DataAnnotations;

namespace Tarker.Booking.Domain.Enums
{
    public enum BookingType
    {
        [Display(Name = "Documentación")]
        Documentation,

        [Display(Name = "Transferencia")]
        Transfer,

        [Display(Name = "Renovación")]
        Renewal
    }
}