using HospitalApp.Dtos;

namespace HospitalApp.Service.Base
{
    public interface IElectronicHealthRecordService
    {
        IEnumerable<ElectronicHealthRecordListDto> GetAllElectronicHealthRecords();
        void CreateElectronicHealthRecord(ElectronicHealthRecordCreateDto electronicHealthRecord);
        void UpdateElectronicHealthRecord(ElectronicHealthRecordUpdateDto electronicHealthRecord);
        void DeleteElectronicHealthRecord(int Id);
        ElectronicHealthRecordListDto GetElectronicHealthRecordById(int Id);
        int SaveElectronicHealthRecords();
    }
}
