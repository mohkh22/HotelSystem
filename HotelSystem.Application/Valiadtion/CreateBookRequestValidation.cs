using FluentValidation;
using HotelSystem.Application.Request.Book;

namespace HotelSystem.Application.Valiadtion
{
    public class CreateBookRequestValidation : AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidation()
        {
            RuleFor(x=>x.UserId).NotEmpty().WithMessage("UserId is required");

            RuleFor(x=>x.RoomId).NotEmpty().WithMessage("RoomId is required");

            RuleFor(x=>x.CheckIn).NotEmpty().WithMessage("CheckIn is required");

            RuleFor(x=>x.CheckOut).NotEmpty().WithMessage("CheckOut is required")
            .GreaterThan(x => x.CheckIn).WithMessage("CheckOut must be greater than CheckIn");

            RuleFor(x=>x.Price).NotEmpty()
               .WithMessage("Price is required")
               .GreaterThan(0)
               .WithMessage("Price must be greater than 0");
        }
    }
}
