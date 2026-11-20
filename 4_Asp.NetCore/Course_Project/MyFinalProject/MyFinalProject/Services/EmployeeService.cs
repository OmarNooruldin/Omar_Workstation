using MyFinalProject.dtos;
using MyFinalProject.Dtos;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;
using MyFinalProject.Services.Base;

namespace MyFinalProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddEmployees(EmployeeCreateDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary,
                Phone = employeeDto.Phone,
                DepartmentId = employeeDto.DepartmentId,
                City = "Riyadh",
            };
            _unitOfWork.Employees.Add(employee);
        }

        public void DeleteEmployees(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            if (employee == null)
            {
               ;
            }
            _unitOfWork.Employees.Delete(employee);
        }

        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
            var department = _unitOfWork.Departments.GetAll();
            return department.Select(d=>new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
            });
        }

        public IEnumerable<EmployeeListDto> GetAllEmployees()
        {
            var employees = _unitOfWork.Employees.GetAllEmployeeWithDepartments();
            return employees.Select(e => new EmployeeListDto
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                DepartmentName = e.Department?.Name, 
            });
        }

        public EmployeeUpdateDto GetEmployeeById(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            if (employee == null)
            {
                return null;
            }
            return new EmployeeUpdateDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            };

        }

        public int SaveEmployee()
        {
            return _unitOfWork.Save();
        }

        public void UpdateEmployees(EmployeeUpdateDto employeeDto)
        {
            var employee = _unitOfWork.Employees.GetById(employeeDto.Id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee Not Found");
            }
            employee.Name = employeeDto.Name;
            employee.Email = employeeDto.Email;
            employee.Salary = employeeDto.Salary;
            employee.Phone = employeeDto.Phone;
            employee.DepartmentId = employeeDto.DepartmentId;

            _unitOfWork.Employees.Update(employee);
        }
    }
}
