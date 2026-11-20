using Microsoft.EntityFrameworkCore;
using MyFinalProject.Application.Abstractions.Repositories.Roles;
using MyFinalProject.Domain;
using MyFinalProject.Infrastructure.Data;
using MyFinalProject.Infrastructure.implementation.Repositories.Base;

namespace MyFinalProject.Infrastructure.implementation.Repositories.Roles
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context) { }


        public Role GetRoleWithPermissions(int Id)
        {
            return _context.Roles.Include(r=>r.Permissions).FirstOrDefault(r=>r.Id == Id);
        }
    }
}
