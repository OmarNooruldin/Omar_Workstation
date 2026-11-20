using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;

namespace HospitalApplication.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithRoles(int Id);
        IEnumerable<Role> GetRoleByIds(List<int> Id);
        IEnumerable<Role> GetAllRoles();
    }
}
