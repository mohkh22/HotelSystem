using HotelSystem.Application.Services.Interfaces;

namespace HotelSystem.Application.IRepository.IUnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepo UserRepo { get; }
        public IHotelRepo HotelRepo { get; }
        public IRoomRepo RoomRepo { get; }
        public IRoomTypeRepo RoomTypeRepo { get; }
        public IBookRepo BookRepo { get; }
        public IHotelImageRepo HotelImageRepo { get; }
        public IPaymentRepo PaymentRepo { get; }
        public IRefreshTokenRepo RefreshTokenRepo { get; }
        public IUserRoleRepo UserRoleRepo { get; }
        public IRoleRepo RoleRepo { get; }

        Task<int> SaveChangesAsync(); 
    }
}
