using MyFinalProject.Application.Abstractions.Repositories.Base;
using MyFinalProject.Domain;

namespace MyFinalProject.Application.Abstractions.Repositories.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAllEmployeeWithDepartments();
    }
}
