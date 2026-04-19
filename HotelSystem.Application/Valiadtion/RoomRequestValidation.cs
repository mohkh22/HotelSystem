using FluentValidation;
using HotelSystem.Application.Request.Room;

namespace HotelSystem.Application.Valiadtion
{
    public class RoomRequestValidation:AbstractValidator<RoomRequest>
    {
        public RoomRequestValidation()
        {
            RuleFor(x => x.Number).NotEmpty().WithMessage("Number Is required");
            RuleFor(x => x.HotelId).NotEmpty().WithMessage("HotelId Is required");
            RuleFor(x => x.RoomTypeId).NotEmpty().WithMessage("RoomTypeId Is required");
            RuleFor(x => x.Price).Must(x=>x>0).WithMessage("Price must not be less than 0");
        }
    }
}
