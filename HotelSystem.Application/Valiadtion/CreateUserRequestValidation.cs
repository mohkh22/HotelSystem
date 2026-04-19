using FluentValidation;
using HotelSystem.Application.Request.User;

namespace HotelSystem.Application.Valiadtion
{
    public class CreateUserRequestValidation:AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidation()
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

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password is required")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$");

            RuleFor(x => x.Roles).NotEmpty()
                .WithMessage("must add Role For User"); 
        }
    }
}
