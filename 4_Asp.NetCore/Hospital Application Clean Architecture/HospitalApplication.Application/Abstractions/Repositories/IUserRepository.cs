using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Domain.Models;

namespace HospitalApplication.Application.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithRoles(int Id);
        IEnumerable<Role> GetRoleByIds(List<int> Id);
        IEnumerable<Role> GetAllRoles();
    }
}
