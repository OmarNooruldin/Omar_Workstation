using HospitalApplication.Dtos;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;
using HospitalApplication.Service.Base;

namespace HospitalApplication.Service
{
    public class ElectronicHealthRecordService : IElectronicHealthRecordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ElectronicHealthRecordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateElectronicHealthRecord(ElectronicHealthRecordCreateDto electronicHealthRecord)
        {
            var ehr = new ElectronicHealthRecord
            {
                VisitDate = electronicHealthRecord.VisitDate,
                Diagnosis = electronicHealthRecord.Diagnosis,
                Symptoms = electronicHealthRecord.Symptoms,
                Notes = electronicHealthRecord?.Notes,
                PatientId = electronicHealthRecord?.PatientId,
            };
            _unitOfWork.ElectronicHealthRecords.Add(ehr);
        }

        public void DeleteElectronicHealthRecord(int Id)
        {
            var ehr = _unitOfWork.ElectronicHealthRecords.GetById(Id);
            if (ehr == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.ElectronicHealthRecords.Delete(ehr);
        }

        public IEnumerable<ElectronicHealthRecordListDto> GetAllElectronicHealthRecords()
        {
            var ehr = _unitOfWork.ElectronicHealthRecords.GetAll();
            return ehr.Select(e => new ElectronicHealthRecordListDto
            {
                Id = e.Id,
                VisitDate = e.VisitDate,
                Diagnosis = e.Diagnosis,
                Symptoms = e.Symptoms,
                Notes = e?.Notes,
                PatientId= e?.PatientId,
            });
        }

        public ElectronicHealthRecordListDto GetElectronicHealthRecordById(int Id)
        {
            var ehr = _unitOfWork.ElectronicHealthRecords.GetById(Id);
            if (ehr == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new ElectronicHealthRecordListDto
            {
                Id = ehr.Id,
                VisitDate = ehr.VisitDate,
                Diagnosis = ehr.Diagnosis,
                Symptoms = ehr.Symptoms,
                Notes = ehr?.Notes, 
                PatientId = ehr?.PatientId,
            };
        }

        public void SaveElectronicHealthRecords()
        {
            _unitOfWork.Save();
        }

        public void UpdateElectronicHealthRecord(ElectronicHealthRecordListDto electronicHealthRecord)
        {
            var ehr = _unitOfWork.ElectronicHealthRecords.GetById(electronicHealthRecord.Id);
            if (ehr == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            ehr.VisitDate = electronicHealthRecord.VisitDate;
            ehr.Diagnosis = electronicHealthRecord.Diagnosis;
            ehr.Symptoms = electronicHealthRecord.Symptoms;
            ehr.Notes = electronicHealthRecord?.Notes;
            ehr.PatientId = electronicHealthRecord?.PatientId;

            _unitOfWork.ElectronicHealthRecords.Update(ehr);
        }
    }
}
