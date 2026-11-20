using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;

namespace HospitalApplication.Repositories.Roles
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetRoleWithPermissions(int Id);
        IEnumerable<Permission> GetAllPermissions();
        IEnumerable<Permission> GetPermissionsByIds(List<int> Id);
    }
}
