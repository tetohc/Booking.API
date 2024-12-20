using FluentValidation;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().NotNull();
            RuleFor(x => x.FullName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.DocumentNumber).NotEmpty().NotNull().Length(8);
        }
    }
}