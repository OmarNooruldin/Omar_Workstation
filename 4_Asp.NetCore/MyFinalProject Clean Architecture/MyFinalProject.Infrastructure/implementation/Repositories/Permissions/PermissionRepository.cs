using MyFinalProject.Application.Abstractions.Repositories.Permissions;
using MyFinalProject.Infrastructure.Data;

namespace MyFinalProject.Infrastructure.implementation.Repositories.Permissions
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _context;

        public PermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
