using FluentValidation;
using HotelSystem.Application.Request.Hotel;

namespace HotelSystem.Application.Valiadtion
{
    public class CreateHotelRequestValidation:AbstractValidator<CreateHotelRequest>
    {
        public CreateHotelRequestValidation()
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Hotel name is required.");
            RuleFor(x=> x.Address).NotEmpty().WithMessage("Hotel address is required.");
            RuleFor(x=> x.LocationUrl).NotEmpty().WithMessage("Hotel location URL is required.");
            RuleFor(x => x.Rating).Must(x => x > 0 && x < 6).WithMessage("Hotel rating must be between 0 and 5."); ; 
            RuleFor(x=> x.Capacity).Must(x=>x>0).WithMessage("Hotel capacity must be less than 1.");

        }
    }
}
