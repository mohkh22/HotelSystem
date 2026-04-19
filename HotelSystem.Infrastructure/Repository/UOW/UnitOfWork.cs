using HotelSystem.Application.IRepository;
using HotelSystem.Application.IRepository.IUnitOfWork;
using HotelSystem.Infrastructure.Data;

namespace HotelSystem.Infrastructure.Repository.UOW
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {
        private IUserRepo? _userRole;
        public IUserRepo UserRepo => _userRole??= new UserRepo(_context);
        private IRefreshTokenRepo? _refreshTokenRepo;
        public IRefreshTokenRepo RefreshTokenRepo => _refreshTokenRepo??= new RefreshTokenRepo(_context);

        private IHotelRepo? _hotelRepo ;
        public IHotelRepo HotelRepo => _hotelRepo ??= new HotelRepo(_context);

        private IRoomRepo? _roomRepo; 
        public IRoomRepo RoomRepo => _roomRepo??= new RoomRepo(_context);

        private IRoomTypeRepo? _roomTypeRepo;
        public IRoomTypeRepo RoomTypeRepo => _roomTypeRepo??= new RoomTypeRepo(_context);

        private IBookRepo? _bookRepo;
        public IBookRepo BookRepo => _bookRepo ??= new BookRepo(_context);

        private IHotelImageRepo? _hotelImageRepo;
        public IHotelImageRepo HotelImageRepo => _hotelImageRepo ??= new HotelImageRepo(_context);

        private IPaymentRepo? _paymentRepo;
        public IPaymentRepo PaymentRepo => _paymentRepo ??= new PaymentRepo(_context);

        private IUserRoleRepo? _userRoleRepo;
        public IUserRoleRepo UserRoleRepo => _userRoleRepo ??= new UserRoleRepo(_context);

        private IRoleRepo? _roleRepo;
        public IRoleRepo RoleRepo => _roleRepo ??= new RoleRepo(_context);

        public async Task<int> SaveChangesAsync()
        {
           return  await _context.SaveChangesAsync();
        }
    }
}
