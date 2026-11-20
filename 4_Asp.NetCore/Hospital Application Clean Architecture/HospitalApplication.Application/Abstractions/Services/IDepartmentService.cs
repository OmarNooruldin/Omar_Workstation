using HospitalApplication.Application.Dtos;

namespace HospitalApplication.Service.Base
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentListDto> GetAllDepartments();
        void CreateDepartment(DepartmentCreateDto department);
        void UpdateDepartment(DepartmentListDto department);
        void DeleteDepartment(int Id);
        DepartmentListDto GetDepartmentById(int Id);
        void SaveDepartments();
    }
}
