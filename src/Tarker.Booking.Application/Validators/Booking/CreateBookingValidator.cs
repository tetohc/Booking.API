using FluentValidation;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;

namespace Tarker.Booking.Application.Validators.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().NotNull();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Code).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Type).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}