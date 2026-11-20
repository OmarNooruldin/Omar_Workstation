using HospitalApp.Dtos;
using HospitalApp.Models;

namespace HospitalApp.Service.Base
{
    public interface INurseService
    {
        IEnumerable<NurseListDto> GetAllNurses();
        IEnumerable<DepartmentListDto> GetAllDepartments();
        void CreateNurse(NurseCreateDto nurse);
        void UpdateNurse(NurseUpdateDto nurse);
        void DeleteNurse(int Id);
        NurseListDto GetNurseById(int Id);
        int SaveNurses();
    }
}
