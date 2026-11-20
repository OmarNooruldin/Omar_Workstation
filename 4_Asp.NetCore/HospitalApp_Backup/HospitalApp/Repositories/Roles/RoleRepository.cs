using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Repositories.Roles;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Repositories.Roles
{
    public class RoleRepository : Repository<Role> ,IRoleRepository
    {

        public RoleRepository(ApplicationDbContext context) : base(context) { }

        public Role GetRoleWithPermissions(int Id)
        {
            return _context.Roles.Include(r => r.Permissions).FirstOrDefault(r => r.Id == Id);
        }


        public IEnumerable<Permission> GetAllPermissions()
        {
            return _context.Permissions.ToList();
        }

        public IEnumerable<Permission> GetPermissionsByIds(List<int> Id)
        {
            return _context.Permissions.Where(p => Id.Contains(p.Id)).ToList();
        }
    }
}
