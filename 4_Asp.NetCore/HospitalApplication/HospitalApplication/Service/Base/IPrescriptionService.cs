using HospitalApplication.Dtos;

namespace HospitalApplication.Service.Base
{
    public interface IPrescriptionService
    {
        IEnumerable<PrescriptionListDto> GetAllPrescriptions();
        IEnumerable<ElectronicHealthRecordListDto> GetAllEHRs();
        void CreatePrescription(PrescriptionCreateDto prescription);
        void UpdatePrescription(PrescriptionListDto prescription);
        void DeletePrescription(int Id);
        PrescriptionListDto GetPrescriptionById(int Id);
        void SavePrescriptions();
    }
}
