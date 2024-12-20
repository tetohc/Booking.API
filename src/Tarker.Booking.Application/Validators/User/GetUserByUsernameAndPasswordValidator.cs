using FluentValidation;

namespace Tarker.Booking.Application.Validators.User
{
    public class GetUserByUsernameAndPasswordValidator : AbstractValidator<(string, string)>
    {
        public GetUserByUsernameAndPasswordValidator()
        {
            RuleFor(x => x.Item1).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Item2).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}