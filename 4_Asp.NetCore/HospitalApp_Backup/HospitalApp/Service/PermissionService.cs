using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Service.Base;

namespace HospitalApp.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePermission(PermissionCreateDto permission)
        {
            var permissions = new Permission
            {
                Name = permission.Name,
            };
            _unitOfWork.Permissions.Add(permissions);
        }

        public void DeletePermission(int Id)
        {
            var permission = _unitOfWork.Permissions.GetById(Id);
            if (permission == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.Permissions.Delete(permission);
        }

        public IEnumerable<PermissionDto> GetAllPermissions()
        {
            var permissions = _unitOfWork.Permissions.GetAll();
            return permissions.Select(p => new PermissionDto
            {
                Id = p.Id,
                Name = p.Name
            });
        }

        public PermissionDto GetPermissionById(int Id)
        {
            var permission = _unitOfWork.Permissions.GetById(Id);
            if (permission == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new PermissionDto
            {
                Id = permission.Id,
                Name = permission.Name
            };
        }

        public int SavePermission()
        {
            return _unitOfWork.Save();
        }

        public void UpdatePermission(PermissionUpdateDto permission)
        {
            var permissions = _unitOfWork.Permissions.GetById(permission.Id);
            if (permissions == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            permissions.Name = permission.Name;
            _unitOfWork.Permissions.Update(permissions);
        }
    }
}
