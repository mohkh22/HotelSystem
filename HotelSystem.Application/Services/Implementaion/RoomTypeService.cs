using AutoMapper;
using HotelSystem.Application.Exceptions;
using HotelSystem.Application.IRepository.IUnitOfWork;
using HotelSystem.Application.Request.RoomType;
using HotelSystem.Application.Response;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Services.Implementaion
{
    public class RoomTypeService(IUnitOfWork _uow , IMapper _mapper) : IRoomTypeService
    {
        public async Task<Guid> AddAsync(RoomTypeRequest roomType)
        {
            var existRoomType = await _uow.RoomTypeRepo.GetByNameAsync(roomType.Type);
            if (existRoomType != null)
                throw new BadRequestException("RoomType already exists");

            var mapRoomType = _mapper.Map<RoomType>(roomType);
            await _uow.RoomTypeRepo.AddAsync(mapRoomType);
            await _uow.SaveChangesAsync();
            return mapRoomType.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
           var existRoomType = await  _uow.RoomTypeRepo.GetByIdAsync(id);
            if (existRoomType == null)
                throw new NotFoundException("RoomType not found");
            await _uow.RoomTypeRepo.DeleteAsync(id);
            await _uow.SaveChangesAsync();
        }

        public async Task<PageResult<RoomTypeRequest>> GetAllAsync(int page = 1, int pageSize = 10)
        {
           var RoomTypes = await  _uow.RoomTypeRepo.GetAllAsync(page, pageSize);
            return new PageResult<RoomTypeRequest>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = RoomTypes.Count,
                Items = _mapper.Map<List<RoomTypeRequest>>(RoomTypes)
            };
        }

        public async Task<RoomTypeRequest> GetByIdAsync(Guid id)
        {
            var existRoomType =  await  _uow.RoomTypeRepo.GetByIdAsync(id);
            if (existRoomType == null)
                throw new NotFoundException("RoomType not found");
            return _mapper.Map<RoomTypeRequest>(existRoomType);
        }

        public async Task<RoomTypeRequest> UpdateAsync(Guid id , UpdateRoomTypeRequest roomType)
        {
            var existRoomType = await _uow.RoomTypeRepo.GetByIdAsync(id);
            if (existRoomType == null)
                throw new NotFoundException("RoomType not found");

           var MapType= _mapper.Map<RoomType>(roomType);
            MapType.Id = id;
            await _uow.RoomTypeRepo.UpdateAsync(MapType);
            await _uow.SaveChangesAsync();
            return _mapper.Map<RoomTypeRequest>(MapType); 
        }
    }
}
