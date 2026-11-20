using HospitalApp.Dtos;
using HospitalApp.Models;

namespace HospitalApp.Service.Base
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        IEnumerable<RoleDto> GetAllRoles();
        User GetUserWithRoles(int Id);
        void CreateUser(UserCreateDto user);
        void UpdateUser(UserUpdateDto user);
        void DeleteUser(int Id);
        UserUpdateDto GetUserById(int Id);
        int SaveUsers();
        void UpdateUserWithRole(int userId, List<int> rolesIds);
    }
}
