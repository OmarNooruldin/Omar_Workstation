using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;

namespace HospitalApp.Repositories.Permissions
{
    public class PermissionRepository : Repository<Permission> ,IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context) : base(context) { }
    }
}
