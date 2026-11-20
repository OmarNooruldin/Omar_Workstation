using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Repositories.Nurses;
using HospitalApp.Service.Base;
using System.Numerics;

namespace HospitalApp.Service
{
    public class NurseService : INurseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NurseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateNurse(NurseCreateDto nurse)
        {
            var nurses = new Nurse
            {
                FirstName = nurse.FirstName,
                LastName = nurse.LastName,
                LicenseNumber = nurse.LicenseNumber,
                Salary = nurse.Salary,
                Speciality = nurse.Speciality,
                DepartmentId = nurse.DepartmentId,
            };
            _unitOfWork.Nurses.Add(nurses);
        }

        public void DeleteNurse(int Id)
        {
            var nurses = _unitOfWork.Nurses.GetById(Id);
            if (nurses == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.Nurses.Delete(nurses);
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

        public IEnumerable<NurseListDto> GetAllNurses()
        {
            var nurses = _unitOfWork.Nurses.GetNursesWithDepartment();
            return nurses.Select(n => new NurseListDto
            {
                Id = n.Id,
                FirstName = n.FirstName,
                LastName = n.LastName,
                LicenseNumber = n.LicenseNumber,
                Salary = n.Salary,
                Speciality = n.Speciality,
                DepartmentName = n.Department.Name,
            });
        }

        public NurseListDto GetNurseById(int Id)
        {
            var nurses = _unitOfWork.Nurses.GetNurseWithDepartment(Id);
            if (nurses == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new NurseListDto
            {
                Id = nurses.Id,
                FirstName = nurses.FirstName,
                LastName = nurses.LastName,
                LicenseNumber = nurses.LicenseNumber,
                Salary = nurses.Salary,
                Speciality = nurses.Speciality,
                DepartmentName= nurses.Department.Name,
            };
        }

        public int SaveNurses()
        {
            return _unitOfWork.Save();
        }

        public void UpdateNurse(NurseUpdateDto nurse)
        {
            var nurses = _unitOfWork.Nurses.GetById(nurse.Id);
            if (nurses == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            nurses.FirstName = nurse.FirstName;
            nurses.LastName = nurse.LastName;
            nurses.Salary = nurse.Salary;
            nurses.DepartmentId = nurse.DepartmentId;

            _unitOfWork.Nurses.Update(nurses);
        }
    }
}
