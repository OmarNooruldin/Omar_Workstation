using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Service.Base;

namespace HospitalApp.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateRole(RoleCreateDto role)
        {
            var roles = new Role
            {
                Name = role.Name,
            };
            _unitOfWork.Roles.Add(roles);
        }


        public void DeleteRole(int Id)
        {
            var role = _unitOfWork.Roles.GetById(Id);
            if (role == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.Roles.Delete(role);
        }

        public IEnumerable<PermissionDto> GetAllPermissions()
        {
            var permission = _unitOfWork.Permissions.GetAll();
            return permission.Select(p => new PermissionDto
            {
                Id = p.Id,
                Name = p.Name,
            });
        }


        public IEnumerable<RoleDto> GetAllRoles()
        {
            var role = _unitOfWork.Roles.GetAll();
            return role.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
            });
        }


        public RoleUpdateDto GetRoleById(int Id)
        {
            var role = _unitOfWork.Roles.GetById(Id);
            if (role == null)
            {
                throw new KeyNotFoundException("Not found");
            }
            return new RoleUpdateDto
            {
                Name = role.Name,
            };
        }

        public Role GetRoleWithPermission(int Id)
        {
            return _unitOfWork.Roles.GetRoleWithPermissions(Id);
        }

        public int SaveRoles()
        {
            return _unitOfWork.Save();
        }

        public void UpdateRole(RoleUpdateDto role)
        {
            var roles = _unitOfWork.Roles.GetById(role.Id);
            if (roles == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            roles.Name = role.Name;

            _unitOfWork.Roles.Update(roles);
        }


        public void UpdateRoleWithPermissions(int roleId, List<int> permissionsIds)
        {
            var role = _unitOfWork.Roles.GetRoleWithPermissions(roleId);
            if (role == null) return;

            role?.Permissions?.Clear();

            var selectPermission = _unitOfWork.Roles.GetPermissionsByIds(permissionsIds);
            foreach (var permission in selectPermission)
            {
                role?.Permissions?.Add(permission);
            }

            _unitOfWork.Roles.Update(role);
            _unitOfWork.Save();

        }
    }
}
