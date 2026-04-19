using AutoMapper;
using HotelSystem.Application.Exceptions;
using HotelSystem.Application.IRepository.IUnitOfWork;
using HotelSystem.Application.Request.Hotel;
using HotelSystem.Application.Response;
using HotelSystem.Application.Response.Hotel;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Services.Implementaion
{
    public class HotelService(IUnitOfWork _uow , IMapper _mapper) : IHotelService
    {
        public async Task<Guid> CreateHotelAsync(CreateHotelRequest hotel)
        {
             var existingHotel = await _uow.HotelRepo.HotelIsExistAsync(hotel.Name, hotel.Address);
            if (existingHotel)
                 throw new BadRequestException("Hotel with the same name and address already exists.");

            var mappHotel = _mapper.Map<Hotel>(hotel);
            await _uow.HotelRepo.CreateHotelAsync(mappHotel); 
            await _uow.SaveChangesAsync();

            return mappHotel.Id; 

        }

        public async Task<Guid> DeleteHotelAsync(Guid id)
        {
            var existHotel = await _uow.HotelRepo.GetHotelByIdAsync(id); 
            if (existHotel == null)
                throw new NotFoundException("Hotel not found.");

            await _uow.HotelRepo.DeleteHotelAsync(id);
            await _uow.SaveChangesAsync();
            return existHotel.Id;

        }

        public async Task<PageResult<HotelResponse>> GetAllHotelsAsync(int page = 1, int pageSize = 10)
        {
            var hotels = await _uow.HotelRepo.GetAllHotelsAsync(page, pageSize);
            return new PageResult<HotelResponse>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = hotels.Count,
                Items = _mapper.Map<List<HotelResponse>>(hotels)
            }; 
        }

        public async Task<HotelResponse> GetHotelByIdAsync(Guid id)
        {
            var hotel = await  _uow.HotelRepo.GetHotelByIdAsync(id);
            if (hotel == null)
                throw new NotFoundException("Hotel not found.");
            return _mapper.Map<HotelResponse>(hotel);

        }

        public async Task<Guid> UpdateHotelAsync(Guid id , UpdateHotelRequest hotel)
        {
             var existHotel = await _uow.HotelRepo.GetHotelByIdAsync(id);
            if (existHotel == null)
                throw new NotFoundException("Hotel not found.");
            var mapHotel = _mapper.Map<Hotel>(hotel);
            mapHotel.Id = existHotel.Id; 
            await _uow.HotelRepo.UpdateHotelAsync(mapHotel); 
            await _uow.SaveChangesAsync();
            return existHotel.Id;
        }
    }
}
