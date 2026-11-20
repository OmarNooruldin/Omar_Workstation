using HospitalApp.Models;
using HospitalApp.Repositories.Base;

namespace HospitalApp.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithRoles(int Id);
        IEnumerable<Role> GetRoleByIds(List<int> Id);
        IEnumerable<Role> GetAllRoles();
    }
}
