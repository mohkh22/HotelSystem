using FluentValidation;
using HotelSystem.Application.Request.Room;

namespace HotelSystem.Application.Valiadtion
{
    public class UpdateRoomRequestValidation:AbstractValidator<UpdateRoomRequest>
    {
        public UpdateRoomRequestValidation()
        {
            RuleFor(x => x.HotelId).NotEmpty().WithMessage("HotelId Is required");
            RuleFor(x => x.RoomTypeId).NotEmpty().WithMessage("RoomTypeId Is required");
            RuleFor(x => x.Price).Must(x=>x>0).WithMessage("Price must not be less than 0");
        }
    }
}
