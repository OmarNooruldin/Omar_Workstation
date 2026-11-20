using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Application.Dtos;
using HospitalApplication.Domain.Models;
using HospitalApplication.Service.Base;

namespace HospitalApplication.Infrastructure.Persistences.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PrescriptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePrescription(PrescriptionCreateDto prescription)
        {
            var pre = new Prescription
            {
                MedicineName = prescription.MedicineName,
                Dosage = prescription.Dosage,
                Frequency = prescription.Frequency,
                DurationDays = prescription.DurationDays,
                ElectronicHealthRecordId = prescription.ElectronicHealthRecordId,
            };
            _unitOfWork.Prescriptions.Add(pre);
        }

        public void DeletePrescription(int Id)
        {
            var pre = _unitOfWork.Prescriptions.GetById(Id);
            if (pre == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.Prescriptions.Delete(pre);
        }

        public IEnumerable<ElectronicHealthRecordListDto> GetAllEHRs()
        {
            var ehr = _unitOfWork.ElectronicHealthRecords.GetAll();
            return ehr.Select(e => new ElectronicHealthRecordListDto
            {
                Id = e.Id,
                VisitDate = e.VisitDate,
                Diagnosis = e.Diagnosis,
                Symptoms = e.Symptoms,
                Notes = e?.Notes,
                PatientId = e?.PatientId,
            });
        }

        public IEnumerable<PrescriptionListDto> GetAllPrescriptions()
        {
            var prescriptions = _unitOfWork.Prescriptions.GetAllPrescriptionsWithEHR();
            return prescriptions.Select(p => new PrescriptionListDto
            {
                Id = p.Id,
                MedicineName = p.MedicineName,
                Dosage = p.Dosage,
                Frequency = p.Frequency,
                DurationDays = p.DurationDays,
                ElectronicHealthRecordId = p.ElectronicHealthRecordId
            });
        }

        public PrescriptionListDto GetPrescriptionById(int Id)
        {
            var pre = _unitOfWork.Prescriptions.GetPrescriptionWithEHR(Id);
            if (pre == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new PrescriptionListDto
            {
                Id = pre.Id,
                MedicineName = pre.MedicineName,
                Dosage = pre.Dosage,
                Frequency = pre.Frequency,
                DurationDays = pre.DurationDays,
                ElectronicHealthRecordId = pre.ElectronicHealthRecordId
            };
        }

        public void SavePrescriptions()
        {
             _unitOfWork.Save();
        }

        public void UpdatePrescription(PrescriptionListDto prescription)
        {
            var pre = _unitOfWork.Prescriptions.GetById(prescription.Id);
            if (pre == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            pre.MedicineName = prescription.MedicineName;
            pre.Dosage = prescription.Dosage;
            pre.Frequency = prescription.Frequency;
            pre.DurationDays = prescription.DurationDays;
            pre.ElectronicHealthRecordId = prescription.ElectronicHealthRecordId;

            _unitOfWork.Prescriptions.Update(pre);
        }
    }
}
