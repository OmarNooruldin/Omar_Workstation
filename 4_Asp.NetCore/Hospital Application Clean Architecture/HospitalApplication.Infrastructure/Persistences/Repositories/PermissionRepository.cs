using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Infrastructure.Data;

namespace HospitalApplication.Infrastructure.Persistences.Repositories
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
