using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;

namespace MyFinalProject.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithRoles(int Id);
        IEnumerable<Role> GetAllRoles();
        IEnumerable<Role> GetRoleByIds(List<int> Id);
    }
}
