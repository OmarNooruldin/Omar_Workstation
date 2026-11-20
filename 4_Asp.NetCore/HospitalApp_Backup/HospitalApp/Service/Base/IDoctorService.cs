using HospitalApp.Dtos;
using HospitalApp.Models;

namespace HospitalApp.Service.Base
{
    public interface IDoctorService
    {
        IEnumerable<DoctorListDto> GetAllDoctors();
        IEnumerable<DepartmentListDto> GetAllDepartments();
        void CreateDoctor(DoctorCreateDto doctor);
        void UpdateDoctor(DoctorUpdateDto doctor);
        void DeleteDoctor(int Id);
        DoctorListDto GetDoctorById(int Id);
        int SaveDoctors();
    }
}
