using MyFinalProject.Application.Abstractions.Repositories.Departments;
using MyFinalProject.Infrastructure.Data;

namespace MyFinalProject.Infrastructure.implementation.Repositories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
