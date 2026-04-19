using FluentValidation;
using HotelSystem.Application.Request.User;

namespace HotelSystem.Application.Valiadtion
{
    public class LoginRequestValidation:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(x=>x.Email)
                .NotNull()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format")
                .MaximumLength(100)
                .WithMessage("Email must not exceed 100 characters");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long");
        }
    }
}
