using AutoMapper;
using HotelSystem.Application.Exceptions;
using HotelSystem.Application.IRepository.IUnitOfWork;
using HotelSystem.Application.Request.Room;
using HotelSystem.Application.Response;
using HotelSystem.Application.Response.Room;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.Domain.Enums;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Services.Implementaion
{
    public class RoomService(IUnitOfWork _uow , IMapper _mapper) : IRoomService
    {
        public async Task<Guid> AddRoomAsync(RoomRequest room)
        {
            var existHotel = await _uow.HotelRepo.GetHotelByIdAsync(room.HotelId);
            var existRoomType = await _uow.RoomTypeRepo.GetByIdAsync(room.RoomTypeId);
            if (existHotel == null)
                throw new NotFoundException("Hotel not found");

            if (existRoomType == null)
                throw new NotFoundException("RoomType not found");

            var countOFRooms = await _uow.RoomRepo.GetCountOfRoomsByHotelIdAsync(room.HotelId);

            if(countOFRooms >= existHotel.Capacity)
                  throw new BadRequestException("Hotel capacity exceeded");

            var mapRoom = _mapper.Map<Room>(room); 
            await _uow.RoomRepo.AddRoomAsync(mapRoom);
            await _uow.SaveChangesAsync();

            return mapRoom.Id; 
        }

        public async Task DeleteRoomAsync(Guid id)
        {
            var existRoom = await _uow.RoomRepo.GetRoomByIdAsync(id);
            if (existRoom == null)
                throw new NotFoundException("Room not found Or Deleted");

            await _uow.RoomRepo.DeleteRoomAsync(id);
            await _uow.SaveChangesAsync();
        }

        public async Task<PageResult<RoomResponse>> GetAllRoomsAsync(int page = 1, int pageSize = 10)
        {
            var rooms = await _uow.RoomRepo.GetAllRoomsAsync(page, pageSize);
            return new PageResult<RoomResponse>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = rooms.Count,
                Items = _mapper.Map<List<RoomResponse>>(rooms)
            };
        }

        public async Task<PageResult<RoomResponse>> GetAllRoomsAsync(Guid HotelId, int page = 1, int pageSize = 10)
        {
            var rooms = await _uow.RoomRepo.GetAllRoomsAsync(HotelId,page, pageSize);
            return new PageResult<RoomResponse>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = rooms.Count,
                Items = _mapper.Map<List<RoomResponse>>(rooms)
            };
        }

        public async Task<RoomResponse> GetRoomByIdAsync(Guid id)
        {
             var existRoom = await _uow.RoomRepo.GetRoomByIdAsync(id);
            if (existRoom == null)
                throw new NotFoundException("Room not found Or Deleted");
            return _mapper.Map<RoomResponse>(existRoom);
        }

        public async Task<RoomResponse> UpdateRoomAsync(Guid id , UpdateRoomRequest room)
        {
             var existRoom = await _uow.RoomRepo.GetRoomByIdAsync(id);
            if (existRoom == null)
                throw new NotFoundException("Room not found Or Deleted");
            var mapRoom = _mapper.Map<Room>(room);
            mapRoom.Id = id;
            await _uow.RoomRepo.UpdateRoomAsync(mapRoom);
            await _uow.SaveChangesAsync();

            return _mapper.Map<RoomResponse>(existRoom); 

        }

        public async Task UpdateStatus(Guid id, CleaningStatus Cleanstatus , Availability availability )
        {
            var existRoom = await _uow.RoomRepo.GetRoomByIdAsync(id);
            if (existRoom == null)
                throw new NotFoundException("Room Not Found");
            existRoom.IsCleaned = Cleanstatus;
            existRoom.IsAvailable = availability; 
        }
    }
}
