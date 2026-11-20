using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Domain.Models;

namespace HospitalApplication.Application.Abstractions.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Department> GetAllDepartments();

        Doctor GetDoctorWithDepartment(int Id);
    }
}
