using HospitalApplication.Data;

namespace HospitalApplication.Repositories.Permissions
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
