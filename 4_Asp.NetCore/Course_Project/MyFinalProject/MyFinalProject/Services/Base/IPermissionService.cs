using MyFinalProject.Dtos;

namespace MyFinalProject.Services.Base
{
    public interface IPermissionService
    {
        IEnumerable<PermissionDto> GetAllPermissions();

        void CreatePermission(PermissionCreateDto permission);
        void UpdatePermission(PermissionUpdateDto permission);
        void DeletePermission(int Id);

        PermissionUpdateDto GetPermissionById(int Id);

        int SavePermission();
    }
}
