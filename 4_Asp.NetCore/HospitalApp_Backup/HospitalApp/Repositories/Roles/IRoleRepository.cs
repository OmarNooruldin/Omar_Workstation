using HospitalApp.Models;
using HospitalApp.Repositories.Base;

namespace HospitalApp.Repositories.Roles
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetRoleWithPermissions(int Id);
        IEnumerable<Permission> GetAllPermissions();
        IEnumerable<Permission> GetPermissionsByIds(List<int> Id);
    }
}
