using FluentValidation;
using HotelSystem.Application.Request.User;

namespace HotelSystem.Application.Valiadtion
{
    public class UpdateUserRequestValidation:AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidation()
        {
            RuleFor(x => x.Username)
                    .NotNull()
                    .WithMessage("Username is required")
                    .MaximumLength(50)
                    .WithMessage("Username must not exceed 50 characters");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format")
                .MaximumLength(100)
                .WithMessage("Email must not exceed 100 characters");
        }
    }
}
