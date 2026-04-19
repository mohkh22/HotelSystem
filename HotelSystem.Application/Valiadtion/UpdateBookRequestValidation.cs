using FluentValidation;
using HotelSystem.Application.Request.Book;

namespace HotelSystem.Application.Valiadtion
{
    public class UpdateBookRequestValidation:AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookRequestValidation()
        {
            RuleFor(x=>x.CheckOut).GreaterThan(x=>x.CheckIn).WithMessage("CheckOut must be greater than CheckIn");
             RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");

        }
    }
}
