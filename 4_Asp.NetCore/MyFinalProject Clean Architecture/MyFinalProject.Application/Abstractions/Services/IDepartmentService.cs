using MyFinalProject.Application.Dtos;


namespace MyFinalProject.Application.Abstractions.Services
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetAllDepartments();

        void CreateDepartment(DepartmentCreateDto department);
        void UpdateDepartment(DepartmentUpdateDto department);
        void DeleteDepartment(int Id);

        DepartmentUpdateDto GetDepartmentById(int Id);

        int SaveDepartments();
    }
}
