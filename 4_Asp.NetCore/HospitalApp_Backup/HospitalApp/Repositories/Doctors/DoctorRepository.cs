using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Repositories.Doctors;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Repositories.Doctors
{
    public class DoctorRepository : Repository<Doctor> ,IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public IEnumerable<Doctor> GetDoctorsWithDepartment()
        {
            return _context.Doctors.Include(d=>d.Department).ToList();
        }

        public Doctor GetDoctorWithDepartment(int Id)
        {
            return _context.Doctors.Include(d => d.Department).FirstOrDefault(d => d.Id == Id);
        }
    }
}
