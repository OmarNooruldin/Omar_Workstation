using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Infrastructure.Persistences.Repositories
{
    public class DoctorRepository : Repository<Doctor> ,IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Doctor GetDoctorWithDepartment(int Id)
        {
            return _context.Doctors.Include(d => d.Department).FirstOrDefault(d => d.Id == Id);
        }
    }
}
