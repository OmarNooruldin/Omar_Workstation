using MyFinalProject.Application.Dtos;


namespace MyFinalProject.Application.Abstractions.Services
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
