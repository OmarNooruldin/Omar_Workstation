using HospitalApplication.Application.Dtos;
using HospitalApplication.Domain.Models;

namespace HospitalApplication.Service.Base
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        IEnumerable<RoleDto> GetAllRoles();
        User GetUserWithRoles(int Id);
        void CreateUser(UserCreateDto user);
        void UpdateUser(UserDto user);
        void DeleteUser(int Id);
        UserDto GetUserById(int Id);
        void SaveUsers();
        void UpdateUserWithRole(int userId, List<int> rolesIds);
    }
}
