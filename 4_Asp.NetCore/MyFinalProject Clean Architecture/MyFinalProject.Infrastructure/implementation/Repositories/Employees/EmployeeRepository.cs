using Microsoft.EntityFrameworkCore;
using MyFinalProject.Application.Abstractions.Repositories.Employees;
using MyFinalProject.Domain;
using MyFinalProject.Infrastructure.Data;
using MyFinalProject.Infrastructure.implementation.Repositories.Base;

namespace MyFinalProject.Infrastructure.implementation.Repositories.Employees
{
    public class EmployeeRepository : Repository<Employee> ,IEmployeeRepository
    {

        public EmployeeRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Employee> GetAllEmployeeWithDepartments()
        {
            return _context.Employees.Include(e => e.Department).ToList();
        }
    }
}
