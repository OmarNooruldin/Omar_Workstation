using MyFinalProject.Application.Abstractions.Repositories.Base;
using MyFinalProject.Application.Abstractions.Services;
using MyFinalProject.Application.Dtos;
using MyFinalProject.Domain;

namespace MyFinalProject.Infrastructure.implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateUser(UserCreateDto user)
        {
            var users = new User
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Username = user.Name,
                Password = user.Password,
            };
            _unitOfWork.Users.Add(users);
        }

        public void DeleteUser(int Id)
        {
            var user = _unitOfWork.Users.GetById(Id);
            if (user == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.Users.Delete(user);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var user = _unitOfWork.Users.GetAll();
            return user.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Phone = u.Phone,
                Username = u.Name,
                Password = u.Password,
            });
        }

        public UserUpdateDto GetUserById(int Id)
        {
            var user = _unitOfWork.Users.GetById(Id);
            if (user == null)
            {
                throw new KeyNotFoundException("Not found");
            }
            return new UserUpdateDto
            {
                Name = user.Name,
                Email = user?.Email,
                Phone = user?.Phone,
                Username = user.Username,
                Password = user.Password,
            };
        }

        public int SaveUsers()
        {
            return _unitOfWork.Save();
        }

        public void UpdateUser(UserUpdateDto user)
        {
            var users = _unitOfWork.Users.GetById(user.Id);
            if (users == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            users.Name = user.Name;
            users.Email = user.Email;
            users.Phone = user.Phone;
            users.Username = user.Username;
            users.Password = user.Password;

            _unitOfWork.Users.Update(users);
        }
    }
}
