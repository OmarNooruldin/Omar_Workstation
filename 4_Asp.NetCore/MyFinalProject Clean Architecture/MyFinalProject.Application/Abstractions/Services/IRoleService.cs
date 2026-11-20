using MyFinalProject.Application.Dtos;
using MyFinalProject.Domain;


namespace MyFinalProject.Application.Abstractions.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAllRoles();
        IEnumerable<PermissionDto> GetAllPermissions();
        IEnumerable<Permission> GetAllPermission();
        Role GetRoleWithPermission(int Id);

        void CreateRole(RoleCreateDto role);
        void UpdateRole(RoleUpdateDto role);
        void UpdateRoleWithPermissions(Role role);
        void DeleteRole(int Id);

        RoleUpdateDto GetRoleById(int Id);

        int SaveRoles();
    }
}
