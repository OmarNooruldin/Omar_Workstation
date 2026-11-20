using HospitalApplication.Application.Dtos;

namespace HospitalApplication.Service.Base
{
    public interface IPatientService
    {
        IEnumerable<PatientListDto> GetAllPatients();
        void CreatePatient(PatientCreateDto patient);
        void UpdatePatient(PatientListDto patient);
        void DeletePatient(PatientListDto patient);
        PatientListDto GetPatientById(int Id);
        void SavePatients();
    }
}
