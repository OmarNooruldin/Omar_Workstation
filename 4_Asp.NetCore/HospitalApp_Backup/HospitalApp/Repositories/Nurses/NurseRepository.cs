using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Repositories.Nurses
{
    public class NurseRepository : Repository<Nurse>, INurseRepository
    {
        private readonly ApplicationDbContext _context;

        public NurseRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public IEnumerable<Nurse> GetNursesWithDepartment()
        {
            return _context.Nurses.Include(n=>n.Department).ToList();
        }

        public Nurse GetNurseWithDepartment(int Id)
        {
            return _context.Nurses.Include(n => n.Department).FirstOrDefault(n => n.Id == Id);
        }
    }
}
