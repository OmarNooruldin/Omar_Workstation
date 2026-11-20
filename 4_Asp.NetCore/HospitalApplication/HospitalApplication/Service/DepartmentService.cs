using HospitalApplication.Dtos;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;
using HospitalApplication.Service.Base;

namespace HospitalApplication.Service
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
                Name = department.Name,
            };
            _unitOfWork.Departments.Add(departments);
        }

        public void DeleteDepartment(int Id)
        {
            var departments = _unitOfWork.Departments.GetById(Id);
            if (departments == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.Departments.Delete(departments);
        }

        public IEnumerable<DepartmentListDto> GetAllDepartments()
        {
            var departments = _unitOfWork.Departments.GetAll();
            return departments.Select(d => new DepartmentListDto
            {
                Id = d.Id,
                Name = d.Name,
            });
        }

        public DepartmentListDto GetDepartmentById(int Id)
        {
            var departments = _unitOfWork.Departments.GetById(Id);
            if (departments == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new DepartmentListDto
            {
                Id = departments.Id,
                Name = departments.Name,
            };
        }

        public void SaveDepartments()
        {
            _unitOfWork.Save();
        }

        public void UpdateDepartment(DepartmentListDto department)
        {
            var departments = _unitOfWork.Departments.GetById(department.Id);
            if (departments == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            departments.Name = department.Name;

            _unitOfWork.Departments.Update(departments);
        }
    }
}
