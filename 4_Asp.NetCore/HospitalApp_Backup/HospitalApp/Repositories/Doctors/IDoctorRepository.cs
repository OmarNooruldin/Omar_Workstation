using HospitalApp.Models;
using HospitalApp.Repositories.Base;

namespace HospitalApp.Repositories.Doctors
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Department> GetAllDepartments();

        IEnumerable<Doctor> GetDoctorsWithDepartment();

        Doctor GetDoctorWithDepartment(int Id);
    }
}
