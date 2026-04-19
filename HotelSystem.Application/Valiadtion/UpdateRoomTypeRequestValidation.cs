using FluentValidation;
using HotelSystem.Application.Request.RoomType;

namespace HotelSystem.Application.Valiadtion
{
    public class UpdateRoomTypeRequestValidation:AbstractValidator<UpdateRoomTypeRequest>
    {
        public UpdateRoomTypeRequestValidation()
        {
        }
    }
}
