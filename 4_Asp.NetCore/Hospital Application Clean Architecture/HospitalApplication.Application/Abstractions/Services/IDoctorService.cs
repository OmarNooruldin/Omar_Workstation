using HospitalApplication.Application.Dtos;

namespace HospitalApplication.Service.Base
{
    public interface IDoctorService
    {
        IEnumerable<DoctorListDto> GetAllDoctors();
        IEnumerable<DepartmentListDto> GetAllDepartments();
        void CreateDoctor(DoctorCreateDto doctor);
        void UpdateDoctor(DoctorListDto doctor);
        void DeleteDoctor(int Id);
        DoctorListDto GetDoctorById(int Id);
        void SaveDoctors();
    }
}
