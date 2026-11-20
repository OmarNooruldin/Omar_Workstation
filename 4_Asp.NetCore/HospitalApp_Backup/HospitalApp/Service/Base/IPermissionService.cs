using HospitalApp.Dtos;

namespace HospitalApp.Service.Base
{
    public interface IPermissionService
    {
        IEnumerable<PermissionDto> GetAllPermissions();

        void CreatePermission(PermissionCreateDto permission);
        void UpdatePermission(PermissionUpdateDto permission);
        void DeletePermission(int Id);

        PermissionDto GetPermissionById(int Id);

        int SavePermission();
    }
}
