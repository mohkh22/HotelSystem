using AutoMapper;
using HotelSystem.Application.Request.Book;
using HotelSystem.Application.Request.Hotel;
using HotelSystem.Application.Request.Room;
using HotelSystem.Application.Request.RoomType;
using HotelSystem.Application.Request.User;
using HotelSystem.Application.Response.Book;
using HotelSystem.Application.Response.Hotel;
using HotelSystem.Application.Response.Room;
using HotelSystem.Application.Response.User;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Mapper
{
    public class MappingProfile:Profile
    {
            public MappingProfile()
            {
                // Map for User
                 CreateMap<RegisterRequest,User>().ReverseMap(); 
                 CreateMap<LoginRequest,User>().ReverseMap(); 
                 CreateMap<UpdateUserRequest,User>().ReverseMap();

                 CreateMap<User,UserResponse>()
                .ForMember(dest=> dest.Roles,
                     opt=> opt.MapFrom(src=>src.UserRoles));

                CreateMap<UserRole, RoleResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role.Name));

                 CreateMap<User,CreateUserRequest>().ReverseMap();

                //// Mapp for Book
                 CreateMap<CreateBookRequest,Book>().ReverseMap();
                 CreateMap<CreateBookRequest,Book>().ReverseMap();
                 CreateMap<Book,BookResponse>().ReverseMap();

            //Map Hotel
            CreateMap<CreateHotelRequest, Hotel>().ReverseMap(); 
            CreateMap<Hotel,UpdateHotelRequest>().ReverseMap();
            CreateMap<Hotel, HotelResponse>().ReverseMap();

            // Map Room
            CreateMap<RoomResponse, Room>().ReverseMap();
            CreateMap<UpdateRoomRequest, Room>().ReverseMap();
            //Map RoomType
            CreateMap<RoomTypeRequest, RoomType>().ReverseMap();
            CreateMap<UpdateRoomTypeRequest, RoomType>().ReverseMap();


        }
    }
}
