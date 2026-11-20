

using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;

namespace HospitalApplication.Infrastructure.Persistences.Repositories
{
    public class DepartmentRepository : Repository<Department> , IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context) : base(context) { }
    }
}
