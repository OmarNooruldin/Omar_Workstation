using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Domain.Models;

namespace HospitalApplication.Application.Abstractions.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetRoleWithPermissions(int Id);
        IEnumerable<Permission> GetAllPermissions();
        IEnumerable<Permission> GetPermissionsByIds(List<int> Id);
    }
}
