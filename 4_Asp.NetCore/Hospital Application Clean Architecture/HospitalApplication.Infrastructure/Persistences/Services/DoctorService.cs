using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Application.Dtos;
using HospitalApplication.Domain.Models;
using HospitalApplication.Service.Base;

namespace HospitalApplication.Infrastructure.Persistences.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateDoctor(DoctorCreateDto doctor)
        {
            var doctors = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                LicenseNumber = doctor.LicenseNumber,
                Speciality = doctor.Speciality,
                ConsultationFee = doctor?.ConsultationFee,
                DepartmentId = doctor.DepartmentId,
            };
            _unitOfWork.Doctors.Add(doctors);
        }

        public void DeleteDoctor(int Id)
        {
            var doctors = _unitOfWork.Doctors.GetById(Id);
            if (doctors == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.Doctors.Delete(doctors);
        }

        public IEnumerable<DepartmentListDto> GetAllDepartments()
        {
            var departments = _unitOfWork.Departments.GetAll();
            return departments.Select(d => new DepartmentListDto
            {
                Id = d.Id,
                Name = d.Name,
            });
        }

        public IEnumerable<DoctorListDto> GetAllDoctors()
        {
            var doctors = _unitOfWork.Doctors.GetAll();
            return doctors.Select(d => new DoctorListDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                LicenseNumber = d.LicenseNumber,
                Speciality = d.Speciality,
                ConsultationFee = d?.ConsultationFee,
                DepartmentName = d.DepartmentId,
            });
        }

        public DoctorListDto GetDoctorById(int Id)
        {
            var doctors = _unitOfWork.Doctors.GetById(Id);
            if (doctors == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new DoctorListDto
            {
                Id = doctors.Id,
                FirstName = doctors.FirstName,
                LastName = doctors.LastName,
                LicenseNumber = doctors.LicenseNumber,
                Speciality = doctors.Speciality,
                ConsultationFee = doctors?.ConsultationFee,
                DepartmentName = doctors.DepartmentId,
            };
        }

        public void SaveDoctors()
        {
            _unitOfWork.Save();
        }

        public void UpdateDoctor(DoctorListDto doctor)
        {
            var doctors = _unitOfWork.Doctors.GetById(doctor.Id);
            if (doctors == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            doctors.FirstName = doctor.FirstName;
            doctors.LastName = doctor.LastName;
            doctors.DepartmentId = doctor.DepartmentName;

            _unitOfWork.Doctors.Update(doctors);
        }
    }
}
