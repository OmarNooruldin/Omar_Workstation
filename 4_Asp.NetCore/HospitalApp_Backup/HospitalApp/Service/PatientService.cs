using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Service.Base;

namespace HospitalApp.Service
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePatient(PatientCreateDto patient)
        {
            var pat = new Patient
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                BloodGroup = patient.BloodGroup,
                ContactNumber = patient.ContactNumber,
                EmergencyContactName = patient.EmergencyContactName,
                EmergencyContactPhone = patient.EmergencyContactPhone,
                Email = patient?.Email,
                Address = patient?.Address,
            };
            _unitOfWork.Patients.Add(pat);
        }

        public void DeletePatient(PatientListDto patient)
        {
            var pat = _unitOfWork.Patients.GetById(patient.Id);
            if (pat == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.Patients.Delete(pat);
        }

        public IEnumerable<PatientListDto> GetAllPatients()
        {
            var patients = _unitOfWork.Patients.GetAll();
            return patients.Select(p=> new PatientListDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Gender = p.Gender,
                DateOfBirth = p.DateOfBirth,
                ContactNumber = p.ContactNumber,
                BloodGroup = p.BloodGroup,
                EmergencyContactName = p.EmergencyContactName,
                EmergencyContactPhone = p.EmergencyContactPhone,
                Email = p?.Email,
                Address = p?.Address,
            });
        }

        public PatientListDto GetPatientById(int Id)
        {
            var pat = _unitOfWork.Patients.GetById(Id);
            if (pat == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new PatientListDto
            {
                Id = pat.Id,
                FirstName = pat.FirstName,
                LastName = pat.LastName,
                Gender = pat.Gender,
                DateOfBirth = pat.DateOfBirth,
                ContactNumber = pat.ContactNumber,
                BloodGroup = pat.BloodGroup,
                EmergencyContactName = pat.EmergencyContactName,
                EmergencyContactPhone = pat.EmergencyContactPhone,
                Email = pat?.Email,
                Address = pat?.Address,
            };
        }

        public int SavePatients()
        {
            return _unitOfWork.Save();
        }

        public void UpdatePatient(PatientListDto patient)
        {
            var pat = _unitOfWork.Patients.GetById(patient.Id);
            if (pat == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            pat.FirstName = patient.FirstName;
            pat.LastName = patient.LastName;
            pat.ContactNumber = patient.ContactNumber;
            pat.EmergencyContactName = patient.EmergencyContactName;
            pat.EmergencyContactPhone = patient.EmergencyContactPhone;
            pat.Email = patient?.Email;

            _unitOfWork.Patients.Update(pat);
        }
    }
}
