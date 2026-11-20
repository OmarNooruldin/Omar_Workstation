using MyFinalProject.Application.Dtos;


namespace MyFinalProject.Application.Abstractions.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();

        void CreateUser(UserCreateDto user);
        void UpdateUser(UserUpdateDto user);
        void DeleteUser(int Id);

        UserUpdateDto GetUserById(int Id);

        int SaveUsers();
    }
}
