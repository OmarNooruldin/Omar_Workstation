using System.ComponentModel.DataAnnotations;

namespace MyFinalProject.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserCreateDto
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserUpdateDto : UserCreateDto
    {
        public int Id { get; set; }
    }
}
