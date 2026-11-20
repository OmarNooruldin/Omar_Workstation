using HospitalApplication.Application.Dtos;

namespace HospitalApplication.Service.Base
{
    public interface IPermissionService
    {
        IEnumerable<PermissionDto> GetAllPermissions();

        void CreatePermission(PermissionCreateDto permission);
        void UpdatePermission(PermissionUpdateDto permission);
        void DeletePermission(int Id);

        PermissionUpdateDto GetPermissionById(int Id);

        void SavePermission();
    }
}
