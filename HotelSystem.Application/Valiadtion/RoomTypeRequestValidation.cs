using FluentValidation;
using HotelSystem.Application.Request.RoomType;

namespace HotelSystem.Application.Valiadtion
{
    public class RoomTypeRequestValidation:AbstractValidator<RoomTypeRequest>
    {
        public RoomTypeRequestValidation()
        {
            RuleFor(x=>x.Type).NotEmpty().WithMessage("Type is Required");
        }
    }
}
