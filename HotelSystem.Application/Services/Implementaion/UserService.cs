using AutoMapper;
using HotelSystem.Application.Exceptions;
using HotelSystem.Application.IRepository.IUnitOfWork;
using HotelSystem.Application.Request.User;
using HotelSystem.Application.Response.User;
using HotelSystem.Application.Services.Interfaces;
using HotelSystem.Domain.Models;

namespace HotelSystem.Application.Services.Implementaion
{
    public class UserService(IUnitOfWork _uow,IMapper _mapper,ICurrentUserService currentUserService) : IUserService
    {
        public async Task<Guid> Add(CreateUserRequest user)
        {
            var existUser = await _uow.UserRepo.FindByEmail(user.Email);
            if (existUser != null)
                throw new BadRequestException("User is Already Found");


            var MapUser = _mapper.Map<User>(user);
            MapUser.UserRoles = new List<UserRole>();
            MapUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var CurrentUserRole = await _uow.UserRoleRepo.GetByUserId(currentUserService.UserId); 
            if(CurrentUserRole.Contains(HotelSystem.Domain.Enums.Role.Manager.ToString()))
            {
                var existRole = await _uow.RoleRepo.GetRoleByName(HotelSystem.Domain.Enums.Role.Staff.ToString());
                if (existRole == null)
                    throw new NotFoundException("Default Role Not Found");
                MapUser.UserRoles.Add(new UserRole { RoleId = existRole.Id });
            }
            else 
            {
                if (user.Roles != null)
                {
                    var existRole = await _uow.RoleRepo.GetAll();
                    foreach (var role in user.Roles)
                    {
                        if (!existRole.Select(x => x.Name).Contains(role))
                            throw new NotFoundException("There is Role NotFound");
                        var _role = existRole.FirstOrDefault(x => x.Name == role);
                        MapUser.UserRoles.Add(new UserRole { RoleId = _role.Id });
                    }
                }
                else
                {
                    var existRole = await _uow.RoleRepo.GetRoleByName(HotelSystem.Domain.Enums.Role.User.ToString());
                    if (existRole == null)
                        throw new NotFoundException("Default Role Not Found");
                    MapUser.UserRoles.Add(new UserRole { RoleId = existRole.Id });
                }
            }


           

            await _uow.UserRepo.Add(MapUser);
            await _uow.SaveChangesAsync();
            return MapUser.Id; 
        }

        public async Task Delete(Guid Id)
        {
            var existUser = await _uow.UserRepo.FindById(Id);
            if (existUser == null)
                throw new NotFoundException("User Not Found");
              _uow.UserRepo.Delete(existUser);
              await _uow.SaveChangesAsync();

        }


        public async Task<UserResponse?> FindById(Guid id)
        {
            var user = await _uow.UserRepo.FindById(id);
            if (user == null)
                throw new NotFoundException("User Not Found");
            var mapUser = _mapper.Map<UserResponse>(user);
            return mapUser;

        }

        public async Task<List<UserResponse>> GetAll(int page = 1, int pageSize = 10)
        {
            var CurrentUser = await _uow.UserRepo.FindById(currentUserService.UserId); 
            var roles = await _uow.UserRoleRepo.GetByUserId(currentUserService.UserId);
            List<User> users; 
            if(roles.Contains(HotelSystem.Domain.Enums.Role.Manager.ToString()) && !roles.Contains(HotelSystem.Domain.Enums.Role.Admin.ToString()))
            {
                 users = await _uow.UserRepo.GetAll(HotelId:CurrentUser?.HotelId,page:page,pageSize:pageSize);
            }
            else
            {
                 users = await _uow.UserRepo.GetAll(page: page, pageSize: pageSize);
            }
            var mapUsers = _mapper.Map<List<UserResponse>>(users);
            return mapUsers;
        }

        public async Task Update(Guid id , UpdateUserRequest user)
        {
            var existUser = await  _uow.UserRepo.FindById(id);
            if (existUser == null)
                throw new NotFoundException("User Not Found");

              var mapUser = _mapper.Map<User>(user);
            mapUser.Id = id;
            await  _uow.UserRepo.Update(mapUser);
            await _uow.SaveChangesAsync();
        }
    }
}
