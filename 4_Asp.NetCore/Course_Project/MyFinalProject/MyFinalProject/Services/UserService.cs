using MyFinalProject.Dtos;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;
using MyFinalProject.Services.Base;
using System.Data;

namespace MyFinalProject.Services
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

        public IEnumerable<RoleDto> GetAllRoles()
        {
            var role = _unitOfWork.Roles.GetAll();
            return role.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            });
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

        public User GetUserWithRoles(int Id)
        {
            return _unitOfWork.Users.GetUserWithRoles(Id);
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

        public void UpdateUserWithRole(int userId, List<int> rolesIds)
        {
            var user = _unitOfWork.Users.GetUserWithRoles(userId);
            if (user == null) return;

            user.Roles.Clear();

            var selectRole = _unitOfWork.Users.GetRoleByIds(rolesIds);
            foreach (var role in selectRole)
            {
                user.Roles.Add(role);
            }

            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();
        }
    }
}
