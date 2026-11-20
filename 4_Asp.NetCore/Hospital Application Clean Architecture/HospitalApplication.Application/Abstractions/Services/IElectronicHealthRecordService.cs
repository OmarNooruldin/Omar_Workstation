using HospitalApplication.Application.Dtos;

namespace HospitalApplication.Service.Base
{
    public interface IElectronicHealthRecordService
    {
        IEnumerable<ElectronicHealthRecordListDto> GetAllElectronicHealthRecords();
        void CreateElectronicHealthRecord(ElectronicHealthRecordCreateDto electronicHealthRecord);
        void UpdateElectronicHealthRecord(ElectronicHealthRecordListDto electronicHealthRecord);
        void DeleteElectronicHealthRecord(int Id);
        ElectronicHealthRecordListDto GetElectronicHealthRecordById(int Id);
        void SaveElectronicHealthRecords();
    }
}
