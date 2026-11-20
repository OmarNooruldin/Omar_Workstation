using HospitalApplication.Application.Dtos;
using HospitalApplication.Domain.Models;

namespace HospitalApplication.Service.Base
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
        void SaveRoles();
        void UpdateRoleWithPermissions(int roleId, List<int> permissionsIds);

    }
}
