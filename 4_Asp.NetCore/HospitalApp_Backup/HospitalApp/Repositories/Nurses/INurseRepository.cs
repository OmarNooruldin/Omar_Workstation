using HospitalApp.Models;
using HospitalApp.Repositories.Base;

namespace HospitalApp.Repositories.Nurses
{
    public interface INurseRepository : IRepository<Nurse>
    {
        IEnumerable<Department> GetAllDepartments();

        IEnumerable<Nurse> GetNursesWithDepartment();

        Nurse GetNurseWithDepartment(int Id);
    }
}
