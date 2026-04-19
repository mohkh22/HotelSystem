using FluentValidation;
using HotelSystem.Application.Request.Hotel;

namespace HotelSystem.Application.Valiadtion
{
    public class UpdateHotelRequestValidation:AbstractValidator<UpdateHotelRequest>
    {
        public UpdateHotelRequestValidation()
        {
            RuleFor(x => x.Rating).InclusiveBetween(0, 5).WithMessage("Hotel rating must be between 0 and 5.");
            RuleFor(x => x.Capacity).Must(x=>x>0).WithMessage("Hotel capacity must be less than 1.");
        }
    }
}
