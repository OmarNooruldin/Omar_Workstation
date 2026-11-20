using MyFinalProject.Application.Abstractions.Repositories.Base;
using MyFinalProject.Application.Abstractions.Services;
using MyFinalProject.Application.Dtos;
using MyFinalProject.Domain;

namespace MyFinalProject.Infrastructure.implementation.Services
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
            Role role = _unitOfWork.Roles.GetById(Id);
            if (role == null)
            {
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

        public IEnumerable<Permission> GetAllPermission()
        {
            var permission = _unitOfWork.Permissions.GetAll();
            return permission.Select(p => new Permission
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
            Role role = _unitOfWork.Roles.GetRoleWithPermissions(Id);
            return role;
        }

        public int SaveRoles()
        {
            return _unitOfWork.Save();
        }

        public void UpdateRole(RoleUpdateDto role)
        {
            var roles = _unitOfWork.Roles.GetById(role.Id);
            if(roles == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            roles.Name = role.Name;

            _unitOfWork.Roles.Update(roles);
        }

        public void UpdateRoleWithPermissions(Role role)
        {
            var roles = _unitOfWork.Roles.GetById(role.Id);
            if (roles == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            roles.Name = role.Name;
            roles.Permissions = role.Permissions;

            _unitOfWork.Roles.Update(roles);
        }
    }
}
