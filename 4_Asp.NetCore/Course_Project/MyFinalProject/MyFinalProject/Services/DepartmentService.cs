using MyFinalProject.Dtos;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;
using MyFinalProject.Services.Base;

namespace MyFinalProject.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateDepartment(DepartmentCreateDto department)
        {
            var departments = new Department
            {
                Name = department.Name
            };
            _unitOfWork.Departments.Add(departments);
        }

        public void DeleteDepartment(int Id)
        {
            var departments = _unitOfWork.Departments.GetById(Id);
            if (departments == null)
            {
                throw new KeyNotFoundException("Category Not Found");
            }
            _unitOfWork.Departments.Delete(departments);
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.Departments.GetAll();
            return departments.Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name
            });
        }

        public DepartmentUpdateDto GetDepartmentById(int Id)
        {
            var departments = _unitOfWork.Departments.GetById(Id);
            if (departments == null)
            {
                return null;
            }
            return new DepartmentUpdateDto
            {
                Id = departments.Id,
                Name = departments.Name,
            };
        }

        public int SaveDepartments()
        {
            return _unitOfWork.Save();
        }

        public void UpdateDepartment(DepartmentUpdateDto department)
        {
            var departments = _unitOfWork.Departments.GetById(department.Id);
            if (departments == null)
            {
                throw new KeyNotFoundException("Category Not Found");
            }
            departments.Name = department.Name;
            _unitOfWork.Departments.Update(departments);
        }
    }
}
