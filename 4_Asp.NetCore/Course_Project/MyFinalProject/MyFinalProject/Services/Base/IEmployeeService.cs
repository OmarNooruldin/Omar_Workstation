using MyFinalProject.dtos;
using MyFinalProject.Dtos;
using MyFinalProject.Models;

namespace MyFinalProject.Services.Base
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeListDto> GetAllEmployees();

        EmployeeUpdateDto GetEmployeeById(int id);

        void AddEmployees(EmployeeCreateDto employeeDto);

        void UpdateEmployees(EmployeeUpdateDto employeeDto);

        void DeleteEmployees(int id);

        IEnumerable<DepartmentDto> GetAllDepartment();

        int SaveEmployee();
    }
}
