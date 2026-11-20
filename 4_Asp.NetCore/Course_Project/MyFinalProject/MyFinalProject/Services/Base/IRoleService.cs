using MyFinalProject.Dtos;
using MyFinalProject.Models;

namespace MyFinalProject.Services.Base
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAllRoles();
        IEnumerable<PermissionDto> GetAllPermissions();
        Role GetRoleWithPermission(int Id);
        void CreateRole(RoleCreateDto role);
        void UpdateRole(RoleUpdateDto role);
        void DeleteRole(int Id);
        RoleUpdateDto GetRoleById(int Id);
        int SaveRoles();
        void UpdateRoleWithPermissions(int roleId, List<int> permissionsIds);
        
    }
}
