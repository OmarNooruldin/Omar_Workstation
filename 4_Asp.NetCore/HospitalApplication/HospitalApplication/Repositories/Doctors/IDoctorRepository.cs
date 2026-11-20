using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;

namespace HospitalApplication.Repositories.Doctors
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Department> GetAllDepartments();

        Doctor GetDoctorWithDepartment(int Id);
    }
}
