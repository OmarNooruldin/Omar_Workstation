using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Infrastructure.Persistences.Repositories
{
    public class RoleRepository : Repository<Role> ,IRoleRepository
    {
        private readonly ApplicationDbContext _context;

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
