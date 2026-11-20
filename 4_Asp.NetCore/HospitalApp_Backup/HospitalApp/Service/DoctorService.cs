using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Service.Base;

namespace HospitalApp.Service
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
                Salary = doctor.Salary,
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
            var doctors = _unitOfWork.Doctors.GetDoctorsWithDepartment();
            return doctors.Select(d => new DoctorListDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                LicenseNumber = d.LicenseNumber,
                Salary = d.Salary,
                Speciality = d.Speciality,
                ConsultationFee = d?.ConsultationFee,
                DepartmentName = d.Department.Name,
            });
        }

        public DoctorListDto GetDoctorById(int Id)
        {
            var doctors = _unitOfWork.Doctors.GetDoctorWithDepartment(Id);
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
                Salary = doctors.Salary,
                Speciality = doctors.Speciality,
                ConsultationFee = doctors?.ConsultationFee,
                DepartmentName = doctors.Department.Name, 
            };
        }

        public int SaveDoctors()
        {
            return _unitOfWork.Save();
        }

        public void UpdateDoctor(DoctorUpdateDto doctor)
        {
            var doctors = _unitOfWork.Doctors.GetById(doctor.Id);
            if (doctors == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            doctors.FirstName = doctor.FirstName;
            doctors.LastName = doctor.LastName;
            doctors.Salary = doctor.Salary;

            _unitOfWork.Doctors.Update(doctors);
        }
    }
}
