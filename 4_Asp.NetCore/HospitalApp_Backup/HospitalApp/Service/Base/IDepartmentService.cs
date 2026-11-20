using HospitalApp.Dtos;

namespace HospitalApp.Service.Base
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentListDto> GetAllDepartments();
        void CreateDepartment(DepartmentCreateDto department);
        void UpdateDepartment(DepartmentUpdateDto department);
        void DeleteDepartment(int Id);
        DepartmentUpdateDto GetDepartmentById(int Id);
        int SaveDepartments();
    }
}
