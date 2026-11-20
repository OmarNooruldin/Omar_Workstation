using MyFinalProject.Application.Abstractions.Repositories.Base;
using MyFinalProject.Domain;

namespace MyFinalProject.Application.Abstractions.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithRoles(int Id);
    }
}
