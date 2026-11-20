using Microsoft.EntityFrameworkCore;
using MyFinalProject.Data;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;

namespace MyFinalProject.Repositories.Employees
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
