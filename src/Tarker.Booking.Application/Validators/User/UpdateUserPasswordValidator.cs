using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

namespace Tarker.Booking.Application.Validators.User
{
    public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}