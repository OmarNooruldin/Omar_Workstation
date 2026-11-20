using HospitalApp.Dtos;

namespace HospitalApp.Service.Base
{
    public interface IPrescriptionService
    {
        IEnumerable<PrescriptionListDto> GetAllPrescriptions();
        IEnumerable<ElectronicHealthRecordListDto> GetAllEHRs();
        void CreatePrescription(PrescriptionCreateDto prescription);
        void UpdatePrescription(PrescriptionUpdateDto prescription);
        void DeletePrescription(int Id);
        PrescriptionListDto GetPrescriptionById(int Id);
        int SavePrescriptions();
    }
}
