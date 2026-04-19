using HotelSystem.Application.IRepository;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.Data;
using HotelSystem.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Infrastructure.Repository
{
    public class RoomRepo(AppDbContext _context) : IRoomRepo
    {
        public async Task AddRoomAsync(Room room)
                    => await _context.Rooms.AddAsync(room);
        public async Task DeleteRoomAsync(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                   throw new NotFoundException("Room not found Or Deleted");

            room.IsDeleted = true;
        }

        public async Task<List<Room>> GetAllRoomsAsync(int page = 1, int pageSize = 10)
        {
            return await _context.Rooms
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Room>> GetAllRoomsAsync(Guid HotelId, int page = 1, int pageSize = 10)
        {
            return await _context.Rooms
                .AsNoTracking()
                 .Where(x => x.HotelId == HotelId)
                .OrderByDescending(x => x.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCountOfRoomsByHotelIdAsync(Guid hotelId)
        {
            var existHotel = await _context.Hotels.CountAsync(x => x.Id == hotelId);
            return existHotel;
        }

        public async Task<Room> GetRoomByIdAsync(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                throw new NotFoundException("Room not found Or Deleted");

            return room;
        }

        public async Task UpdateRoomAsync(Room room)
        {
            var existRoom = await _context.Rooms.FindAsync(room.Id);
            if (existRoom == null)
                throw new NotFoundException("Room not found Or Deleted");

            existRoom.Number = room.Number;
            existRoom.Price = room.Price;
            existRoom.IsAvailable = room.IsAvailable;
            existRoom.IsCleaned = room.IsCleaned;

        }
    }
}
