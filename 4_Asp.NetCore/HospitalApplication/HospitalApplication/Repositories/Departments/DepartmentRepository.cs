using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;

namespace HospitalApplication.Repositories.Departments
{
    public class DepartmentRepository : Repository<Department> , IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context) : base(context) { }
    }
}
