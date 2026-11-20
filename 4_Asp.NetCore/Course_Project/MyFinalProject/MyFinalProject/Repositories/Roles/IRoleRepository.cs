using MyFinalProject.Dtos;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;

namespace MyFinalProject.Repositories.Roles
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetRoleWithPermissions(int Id);
        IEnumerable<Permission> GetAllPermissions();
        IEnumerable<Permission> GetPermissionsByIds(List<int> Id);
    }
}
