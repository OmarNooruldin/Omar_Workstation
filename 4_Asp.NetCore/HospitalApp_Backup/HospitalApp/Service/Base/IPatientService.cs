using HospitalApp.Dtos;

namespace HospitalApp.Service.Base
{
    public interface IPatientService
    {
        IEnumerable<PatientListDto> GetAllPatients();
        void CreatePatient(PatientCreateDto patient);
        void UpdatePatient(PatientListDto patient);
        void DeletePatient(PatientListDto patient);
        PatientListDto GetPatientById(int Id);
        int SavePatients();
    }
}
